using NAudio.Wave;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;
using TagLib.WavPack;

namespace Echo
{
    public static class TrackMetaData
    {
        public struct AudioTrack
        {
            //MetaDatas
            public string Title;
            public string Artist;
            public string Album;
            public Image AlbumArt;

            //Informazioni di servizio
            public string FilePath;
            public float VolumeMultiplier;
            public TimeSpan Duration;
        }

        /// <summary>
        /// Crea un <see cref="AudioTrack"/> leggendo metadati, copertina e durata da un file audio.
        /// Se alcuni campi non sono presenti o si verifica un errore, applica valori di fallback.
        /// </summary>
        /// <remarks>
        /// Fallback usati:
        /// <list type="bullet">
        /// <item><description>Titolo: nome file senza estensione.</description></item>
        /// <item><description>Artista: "Autore sconosciuto" (metadato mancante) oppure "Sconosciuto" (in caso di eccezione).</description></item>
        /// <item><description>Album: "Album sconosciuto" (metadato mancante) oppure "Sconosciuto" (in caso di eccezione).</description></item>
        /// <item><description>Copertina: <see langword="null"/> se assente o in caso di errore.</description></item>
        /// <item><description>Durata: <see cref="TimeSpan.Zero"/> in caso di eccezione.</description></item>
        /// <item><description>Volume iniziale: valore di <paramref name="defaultVolume"/>.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="filePath">Percorso del file audio da analizzare.</param>
        /// <param name="defaultVolume">Volume iniziale assegnato alla traccia caricata (default: <see cref="AppDefaults.DefaultVolumeMultiplier"/>).</param>
        /// <returns>Un <see cref="AudioTrack"/> popolato con le informazioni lette dal file.</returns>
        /// <exception cref="FileNotFoundException">Generata quando il file non esiste.</exception>
        public static AudioTrack FromFile(string filePath, float defaultVolume = AppDefaults.DefaultVolumeMultiplier)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException();

            float safeDefaultVolume = Math.Max(AppDefaults.MinDeviceVolume, Math.Min(AppDefaults.MaxDeviceVolume, defaultVolume));

            AudioTrack newTrack;
            newTrack.FilePath = filePath;

            try
            {
                // Nota: `TagLib.File` implementa `IDisposable`.
                // In .NET Framework conviene sempre racchiuderlo in `using` per rilasciare handle/file lock.
                using (TagLib.File fileTag = TagLib.File.Create(filePath))
                {
                    // ----------------------------
                    // Lettura metadati testuali
                    // ----------------------------
                    newTrack.Title = !string.IsNullOrEmpty(fileTag.Tag.Title)
                        ? fileTag.Tag.Title.Trim()
                        : Path.GetFileNameWithoutExtension(filePath);

                    newTrack.Artist = !string.IsNullOrEmpty(fileTag.Tag.FirstPerformer)
                        ? fileTag.Tag.FirstPerformer.Trim()
                        : AppDefaults.AudioTrackArtistNotAvailable;

                    newTrack.Album = !string.IsNullOrEmpty(fileTag.Tag.Album)
                        ? fileTag.Tag.Album.Trim()
                        : AppDefaults.AudioTrackAlbumNotAvailable;

                    

                    // ----------------------------
                    // Root cause reale del bug GDI+
                    // ----------------------------
                    // Errore originale:
                    //   System.Runtime.InteropServices.ExternalException
                    //   "Errore generico in GDI+."
                    // durante `albumArt.Save(ms, format)`.
                    //
                    // Causa profonda:
                    // - Se si usa `Image.FromStream(ms)` e poi si chiude `ms`,
                    //   l'oggetto `Image` può rimanere internamente legato allo stream sorgente.
                    // - In un momento successivo (qui durante salvataggio tag), GDI+ deve riaccedere ai dati
                    //   originali dell'immagine per ricodificarla e fallisce con errore generico.
                    //
                    // Soluzione robusta:
                    // - creare un'immagine "indipendente" dallo stream facendo una copia fisica (`new Bitmap(img)`).
                    // - in questo modo, quando il `MemoryStream` viene chiuso, `AlbumArt` resta perfettamente valida.
                    if (fileTag.Tag.Pictures != null && fileTag.Tag.Pictures.Length >= 1)
                    {
                        byte[] bin = fileTag.Tag.Pictures[0].Data.Data;

                        using (var ms = new MemoryStream(bin))
                        using (var img = Image.FromStream(ms, true, true))
                        {
                            // Copia disaccoppiata dallo stream: evita il classico ExternalException GDI+ in Save().
                            newTrack.AlbumArt = new Bitmap(img);
                        }
                    }
                    else
                    {
                        newTrack.AlbumArt = null;
                    }

                    // VolumeMultiplier custom tag (TXXX: ECHO_VOLUME_MULTIPLIER)
                    // Se assente/non valido resta il default sicuro.
                    float volumeFromTag = safeDefaultVolume;

                    TagLib.Id3v2.Tag id3v2 = (TagLib.Id3v2.Tag)fileTag.GetTag(TagLib.TagTypes.Id3v2, false);
                    if (id3v2 != null)
                    {
                        var frame = TagLib.Id3v2.UserTextInformationFrame.Get(
                            id3v2,
                            "ECHO_VOLUME_MULTIPLIER",
                            false);

                        if (frame != null && frame.Text != null && frame.Text.Length > 0)
                        {
                            string raw = frame.Text[0].Trim();

                            float parsed;

                            if (float.TryParse(raw, out parsed))
                                volumeFromTag = (float)MathHelper.Clamp(parsed, 0f, 1f);
                        }
                    }

                    newTrack.VolumeMultiplier = volumeFromTag;
                }

                // Nota: anche `AudioFileReader` è `IDisposable`.
                // Evita leak di handle file e comportamenti intermittenti.
                using (AudioFileReader audioFileReader = new AudioFileReader(filePath))
                {
                    newTrack.Duration = audioFileReader.TotalTime;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                newTrack.Title = Path.GetFileNameWithoutExtension(filePath);
                newTrack.Artist = AppDefaults.AudioTrackError;
                newTrack.Album = AppDefaults.AudioTrackError;
                newTrack.Duration = TimeSpan.Zero;
                newTrack.AlbumArt = null;
                newTrack.VolumeMultiplier = safeDefaultVolume;
            }

            return newTrack;
        }

        public static bool OverwriteMP3MetaTags(string mp3Path, AudioTrack audioTrack)
        {
            if (!System.IO.File.Exists(mp3Path) || Path.GetExtension(mp3Path) != ".mp3")
                return false;

            try
            {
                // Anche qui usare `using` è consigliato:
                // garantisce flush e rilascio corretto risorse native/file.
                using (TagLib.File mp3 = TagLib.File.Create(mp3Path))
                {
                    mp3.Tag.Title = audioTrack.Title;
                    mp3.Tag.Performers = new string[] { audioTrack.Artist };
                    mp3.Tag.Album = audioTrack.Album;

                    // Questo punto prima falliva quando `audioTrack.AlbumArt` proveniva da uno stream già chiuso.
                    // Dopo la correzione in `FromFile`, l'immagine è autonoma e serializzabile.
                    mp3.Tag.Pictures = ImageHelper.BuildTagPicturesFromImage(audioTrack.AlbumArt);

                    var customTags = (TagLib.Id3v2.Tag)mp3.GetTag(TagLib.TagTypes.Id3v2, true);

                    var frame = TagLib.Id3v2.UserTextInformationFrame.Get(
                        customTags,
                        "ECHO_VOLUME_MULTIPLIER",
                        true);

                    frame.Text = new string[]
                    {
                        audioTrack.VolumeMultiplier.ToString()
                    };

                    mp3.Save();
                }

                return true;
            }
            catch
            {
                // IMPORTANTISSIMO:
                // NON fare `throw new Exception(ex.Message);`
                // perché:
                // 1) perdi tipo eccezione originale (`ExternalException`, ecc.),
                // 2) perdi stack trace originale,
                // 3) rendi il debugging molto più difficile.
                //
                // `throw;` preserva integralmente il contesto reale del guasto.
                throw;
            }
        }

        public static int FindTrackIndexByTitleAndArtist(string title,  string artist, AudioTrack[] audioTrackArray, int audioTrackArrayCount)
        {
            for (int i = 0; i < audioTrackArrayCount; i++)
            {
                if (audioTrackArray[i].Title == title && audioTrackArray[i].Artist == artist)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Restituisce una stringa formattata "mm:ss" per il numero di secondi specificato.
        /// </summary>
        /// <param name="seconds">Numero di secondi da convertire.</param>
        /// <returns>Stringa formattata come "mm:ss".</returns>
        public static string FormatTrackTime(int seconds)
        {
            return TimeSpan
                .FromSeconds(seconds)
                .ToString("mm\\:ss");
        }


        public static void DeleteAudioTrackFromArray(int toDeleteIndex,AudioTrack[] array, ref int arrayCount, bool keepOrder = true)
        {
            if(array == null)
            {
                throw new NullReferenceException($"{nameof(array)} is null or empty");
            }
            if(keepOrder)
            {
                arrayCount--;
                array[toDeleteIndex] = array[arrayCount];
            }
            else
            {
                while(toDeleteIndex < arrayCount - 1)
                {
                    array[toDeleteIndex] = array[toDeleteIndex + 1];
                    toDeleteIndex++;
                }
            }
        }

        
    }
}
