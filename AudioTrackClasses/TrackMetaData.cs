using NAudio.Wave;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
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
                TagLib.File fileTag = TagLib.File.Create(filePath);

                //Title
                newTrack.Title = !string.IsNullOrEmpty(fileTag.Tag.Title)
                    ? fileTag.Tag.Title.Trim()
                    : Path.GetFileNameWithoutExtension(filePath);
                //Artist
                newTrack.Artist = !string.IsNullOrEmpty(fileTag.Tag.FirstPerformer)
                    ? fileTag.Tag.FirstPerformer.Trim()
                    : AppDefaults.AudioTrackArtistNotAvailable;

                //Album
                newTrack.Album = !string.IsNullOrEmpty(fileTag.Tag.Album)
                    ? fileTag.Tag.Album.Trim()
                    : AppDefaults.AudioTrackAlbumNotAvailable;

                // Cover
                if (fileTag.Tag.Pictures.Length >= 1)
                {
                    //bin contains the raw bytes stream of the picture
                    byte[] bin = fileTag.Tag.Pictures[0].Data.Data;

                    //ms contains the bytes stream
                    using (MemoryStream ms = new MemoryStream(bin))
                    {
                        //Draw the image from the MemoryStream and put it into newTrack.AlbumArt
                        newTrack.AlbumArt = Image.FromStream(ms);
                    }
                }
                else
                {
                    newTrack.AlbumArt = null;
                }

                //Durata
                AudioFileReader audioFileReader = new AudioFileReader(filePath);
                newTrack.Duration = audioFileReader.TotalTime;
                audioFileReader = null;

                newTrack.VolumeMultiplier = safeDefaultVolume;
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
            if(!System.IO.File.Exists(mp3Path) || Path.GetExtension(mp3Path) != ".mp3")
                return false;
            try
            {
                TagLib.File mp3 = TagLib.File.Create(mp3Path);
                mp3.Tag.Title = audioTrack.Title;
                mp3.Tag.Performers = new string[] { audioTrack.Artist };
                mp3.Tag.Album = audioTrack.Album;
                mp3.Tag.Pictures = ImageHelper.BuildTagPicturesFromImage(audioTrack.AlbumArt);
                //Volume Multiplier
                // 1) Recupera il tag ID3v2 del file MP3; se non esiste lo crea (secondo parametro = true).
                var volumeMultiplierTag = (TagLib.Id3v2.Tag)mp3.GetTag(TagLib.TagTypes.Id3v2, true);

                // 2) Cerca (o crea) un frame testuale personalizzato (TXXX) con chiave "ECHO_VOLUME_MULTIPLIER".
                //ID3v2 e il contenitore di metadati dei mp3 e frame e'un campo di ID3v2 insiema ad autore...
                var frame = TagLib.Id3v2.UserTextInformationFrame.Get(
                    volumeMultiplierTag,
                    "ECHO_VOLUME_MULTIPLIER",
                    true);
    
                // 3) Scrive il valore del volume nel frame custom come stringa in formato invariabile (usa '.' come separatore decimale).
                frame.Text = new string[]
                {
                    audioTrack.VolumeMultiplier.ToString(System.Globalization.CultureInfo.InvariantCulture)
                };

                // 4) Salva fisicamente su disco tutte le modifiche dei metadati.
                mp3.Save();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
