using NAudio.Dmo;
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
using System.Web;
using System.Windows.Forms;
using TagLib;
using TagLib.WavPack;
using static Echo.AppSettings;

namespace Echo
{
    public static class TrackMetaData
    {
        // Modello traccia
        public struct AudioTrack
        {
            // Metadati
            public string Title;
            public string Artist;
            public string Album;
            public Image AlbumArt;

            // Dati tecnici
            public string FilePath;
            public float VolumeMultiplier;
            public TimeSpan Duration;
        }

        // Lettura traccia da file
        public static AudioTrack FromFile(string filePath, float volume, AppSettings.UserSettings userSettings)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException();

            float defaultVolumeMultiplier = (float)MathHelper.Clamp(volume, AppDefaults.MinDeviceVolume, AppDefaults.MaxDeviceVolume);

            AudioTrack newTrack;
            newTrack.FilePath = filePath;

            try
            {
                // Lettura tag
                using (TagLib.File fileTag = TagLib.File.Create(filePath))
                {
                    // Metadati testuali
                    newTrack.Title = !string.IsNullOrEmpty(fileTag.Tag.Title)
                        ? fileTag.Tag.Title.Trim()
                        : Path.GetFileNameWithoutExtension(filePath);

                    newTrack.Artist = !string.IsNullOrEmpty(fileTag.Tag.FirstPerformer)
                        ? fileTag.Tag.FirstPerformer.Trim()
                        : userSettings.AudioTrackArtistNotAvailable;

                    newTrack.Album = !string.IsNullOrEmpty(fileTag.Tag.Album)
                        ? fileTag.Tag.Album.Trim()
                        : userSettings.AudioTrackAlbumNotAvailable;
                    // Copertina
                    if (fileTag.Tag.Pictures != null && fileTag.Tag.Pictures.Length >= 1)
                    {
                        byte[] bin = fileTag.Tag.Pictures[0].Data.Data;

                        using (var ms = new MemoryStream(bin))
                        using (var img = Image.FromStream(ms, true, true))
                        {
                            newTrack.AlbumArt = new Bitmap(img);
                        }
                    }
                    else
                    {
                        newTrack.AlbumArt = null;
                    }

                    // Volume iniziale
                    newTrack.VolumeMultiplier = defaultVolumeMultiplier;
                }

                // Durata audio
                using (AudioFileReader audioFileReader = new AudioFileReader(filePath))
                {
                    newTrack.Duration = audioFileReader.TotalTime;
                }
            }
            catch
            {
                // Fallback
                newTrack.Title = Path.GetFileNameWithoutExtension(filePath);
                newTrack.Artist = AppDefaults.AudioTrackError;
                newTrack.Album = AppDefaults.AudioTrackError;
                newTrack.Duration = TimeSpan.Zero;
                newTrack.AlbumArt = null;
                newTrack.VolumeMultiplier = defaultVolumeMultiplier;
            }

            return newTrack;
        }

        // Scrittura tag mp3
        public static bool OverwriteMP3MetaTags(string mp3Path, AudioTrack audioTrack)
        {
            if (!System.IO.File.Exists(mp3Path) || Path.GetExtension(mp3Path) != ".mp3")
                return false;

            try
            {
                using (TagLib.File mp3 = TagLib.File.Create(mp3Path))
                {
                    mp3.Tag.Title = audioTrack.Title;
                    mp3.Tag.Performers = new string[] { audioTrack.Artist };
                    mp3.Tag.Album = audioTrack.Album;
                    mp3.Tag.Pictures = ImageHelper.BuildTagPicturesFromImage(audioTrack.AlbumArt);

                    mp3.Save();
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        // Ricerca per titolo e artista
        public static int FindTrackIndexByTitleAndArtist(string title, string artist, AudioTrack[] audioTrackArray, int audioTrackArrayCount)
        {
            for (int i = 0; i < audioTrackArrayCount; i++)
            {
                if (audioTrackArray[i].Title == title && audioTrackArray[i].Artist == artist)
                    return i;
            }
            return -1;
        }

        // Ricerca per path
        public static int FindTrackIndexByFilePath(string filepath, AudioTrack[] audioTrackArray, int audioTrackArrayCount)
        {
            for (int i = 0; i < audioTrackArrayCount; i++)
            {
                if (audioTrackArray[i].FilePath == filepath)
                    return i;
            }
            return -1;
        }

        // Formattazione tempo
        public static string FormatTrackTime(int seconds)
        {
            return TimeSpan
                .FromSeconds(seconds)
                .ToString("mm\\:ss");
        }

        // Rimozione traccia da array
        public static void DeleteAudioTrackFromArray(int toDeleteIndex, AudioTrack[] array, ref int arrayCount, bool keepOrder = true)
        {
            if (array == null)
            {
                throw new NullReferenceException($"{nameof(array)} is null or empty");
            }
            if (keepOrder)
            {
                arrayCount--;
                array[toDeleteIndex] = array[arrayCount];
            }
            else
            {
                while (toDeleteIndex < arrayCount - 1)
                {
                    array[toDeleteIndex] = array[toDeleteIndex + 1];
                    toDeleteIndex++;
                }
            }
        }

        // Salvataggio playlist in .ech
        public static int SavePlaylistInEch(string softwareDirectory, string playlistName, AudioTrack[] playlist, int playlistCount, out int[] filePathError, AppSettings.UserSettings userSettings)
        {
            int errorsCount = 0;
            int[] errors = new int[playlistCount];
            for (int i = 0; i < playlistCount; i++)
            {
                if (!System.IO.File.Exists(playlist[i].FilePath))
                {
                    errors[errorsCount] = i;
                    errorsCount++;
                }
            }

            filePathError = new int[errorsCount];
            for (int i = 0; i < errorsCount; i++)
            {
                filePathError[i] = errors[i];
            }
            if (filePathError.Length > 0)
                return -1;

            if (!System.IO.Directory.Exists(softwareDirectory))
                Directory.CreateDirectory(softwareDirectory);
            if (!StringHelper.CanBeADirectoryOrFileName(ref playlistName, userSettings.SubstituteToSpaceInDirectoryOrFileName))
                return -2;

            string playlistDirectory = Path.Combine(softwareDirectory, playlistName);
            bool tempDirectory = false;
            string actPlaylistDirectory = playlistDirectory;
            if (System.IO.Directory.Exists(playlistDirectory))
            {
                actPlaylistDirectory = playlistDirectory + "_tmp";
                tempDirectory = true;
            }

            Directory.CreateDirectory(actPlaylistDirectory);
            string echPath = Path.Combine(actPlaylistDirectory, Path.ChangeExtension(playlistName, ".ech"));
            StreamWriter echFile = new StreamWriter(echPath);
            string audioTracksDirectory = Path.Combine(actPlaylistDirectory, "audioTracks");
            Directory.CreateDirectory(audioTracksDirectory);
            string realAudioTrackDirectory = tempDirectory ? Path.Combine(playlistDirectory, "audioTracks") : default;

            try
            {
                // Header playlist
                echFile.WriteLine(playlistName);
                echFile.WriteLine(playlistCount);

                for (int i = 0; i < playlistCount; i++)
                {
                    string fileName = Path.GetFileName(playlist[i].FilePath);
                    string destination = Path.Combine(audioTracksDirectory, fileName);

                    // Copia traccia
                    System.IO.File.Copy(playlist[i].FilePath, destination, true);

                    if(userSettings.DeleteOriginalAudioTrack)
                        System.IO.File.Delete(playlist[i].FilePath);
                    

                    // Salvo path traccia
                    if (tempDirectory)
                        echFile.WriteLine(Path.Combine(realAudioTrackDirectory, fileName));
                    else
                        echFile.WriteLine(destination);

                    // Salvo volume e metadati
                    echFile.WriteLine(playlist[i].VolumeMultiplier.ToString(CultureInfo.InvariantCulture));
                    OverwriteMP3MetaTags(destination, playlist[i]);
                }
                return 0;
            }
            catch
            {
                return -3;
            }
            finally
            {
                echFile.Close();
                if (tempDirectory)
                {
                    Directory.Delete(playlistDirectory, true);
                    Directory.Move(actPlaylistDirectory, playlistDirectory);
                }
            }
        }

        // Verifica file playlist
        public static bool IsPlaylist(string echPath)
        {
            if (Path.GetExtension(echPath) != ".ech")
                return false;
            if (!System.IO.File.Exists(echPath))
                return false;
            if (!System.IO.Directory.Exists(Path.Combine(Path.GetDirectoryName(echPath), "audioTracks")))
                return false;
            return true;
        }

        // Caricamento playlist da .ech
        public static int LoadPlaylistFromEch(string echPath, ref string playlistName, ref AudioTrack[] playlist, AppSettings.UserSettings userSettings)
        {
            playlist = new AudioTrack[0];
            if (!IsPlaylist(echPath))
                return -1;

            StreamReader reader = new StreamReader(echPath);
            try
            {
                playlistName = reader.ReadLine();
                int count = (int)MathHelper.Clamp(int.Parse(reader.ReadLine()), 0, AppDefaults.MaxLoadedTracks);
                AudioTrack[] tmp_playlist = new AudioTrack[count];

                for (int i = 0; i < count && !reader.EndOfStream; i++)
                {
                    string trackPath = reader.ReadLine();
                    string toParse = reader.ReadLine();
                    float volume = float.Parse(toParse, CultureInfo.InvariantCulture);
                    tmp_playlist[i] = FromFile(trackPath, volume, userSettings);
                }

                playlist = tmp_playlist;
                return 0;
            }
            catch
            {
                return -2;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
