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
using TagLib.WavPack;

namespace SoundDeck
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

            float safeDefaultVolume = Math.Max(AppDefaults.MinVolume, Math.Min(AppDefaults.MaxVolume, defaultVolume));

            AudioTrack newTrack;
            newTrack.FilePath = filePath;
            try
            {
                var fileTag = TagLib.File.Create(filePath);

                //Title
                newTrack.Title = !string.IsNullOrEmpty(fileTag.Tag.Title)
                    ? fileTag.Tag.Title.Trim()
                    : Path.GetFileNameWithoutExtension(filePath);
                //Artist
                newTrack.Artist = !string.IsNullOrEmpty(fileTag.Tag.FirstPerformer)
                    ? fileTag.Tag.FirstPerformer.Trim()
                    : "Autore sconosciuto";

                //Album
                newTrack.Album = !string.IsNullOrEmpty(fileTag.Tag.Album)
                    ? fileTag.Tag.Album.Trim()
                    : "Album sconosciuto";

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
                MessageBox.Show($"Errore: {ex.Message}");
                newTrack.Title = Path.GetFileNameWithoutExtension(filePath);
                newTrack.Artist = "Sconosciuto";
                newTrack.Album = "Sconosciuto";
                newTrack.Duration = TimeSpan.Zero;
                newTrack.AlbumArt = null;
                newTrack.VolumeMultiplier = safeDefaultVolume;
            }

            return newTrack;
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
