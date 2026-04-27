using Echo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo
{
    public static class SettingService
    {
        public static AppSettings.UserSettings Load(out bool error)
        {
            error = false;
            AppSettings.UserSettings settings = AppDefaults.defaultUserSettings;

            if (!Directory.Exists(AppDefaults.ConfigDirectory))
                Directory.CreateDirectory(AppDefaults.ConfigDirectory);

            if (!File.Exists(AppDefaults.ConfigFilePath))
                return settings;

            try
            {
                using (StreamReader reader = new StreamReader(AppDefaults.ConfigFilePath))
                {
                    string line;

                    line = reader.ReadLine();
                    if(!string.IsNullOrWhiteSpace(line))
                        settings.EchOnLoad = line;

                    line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                        settings.BrowseAudioTracksInitialDirectory = line;

                    line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                        settings.BrowsePlaylistsInitialDirectory = line;

                    line = reader.ReadLine();
                    bool deleteOriginal;
                    if (bool.TryParse(line, out deleteOriginal))
                        settings.DeleteOriginalAudioTrack = deleteOriginal;

                    line = reader.ReadLine();
                    Playback.PlaybackMode mode;
                    if (Enum.TryParse(line, true, out mode))
                        settings.DefaultPlaybackMode = mode;

                    line = reader.ReadLine();
                    float volumeMultiplier;
                    if (float.TryParse(line, out volumeMultiplier))
                        settings.DefaultVolumeMultiplier = volumeMultiplier;

                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                        settings.SubstituteToSpaceInDirectoryOrFileName = line[0];

                    line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                        settings.AudioTrackArtistNotAvailable = line;

                    line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                        settings.AudioTrackAlbumNotAvailable = line;

                    line = reader.ReadLine();
                    int confirmationStringLength;
                    if (int.TryParse(line, out confirmationStringLength))
                        settings.ConfirmationStringLength = confirmationStringLength;
                    
                }
            }
            catch
            {
                error = true;
            }

            return settings;
        }

        public static void Save(AppSettings.UserSettings settings, out bool error)
        {
            error = false;
            if(!Directory.Exists(AppDefaults.ConfigDirectory))
                Directory.CreateDirectory(AppDefaults.ConfigDirectory);
            StreamWriter writer = new StreamWriter(AppDefaults.ConfigFilePath + "_tmp");
            try
            {
                writer.WriteLine(settings.EchOnLoad);

                writer.WriteLine(settings.BrowseAudioTracksInitialDirectory);
                writer.WriteLine(settings.BrowsePlaylistsInitialDirectory);

                writer.WriteLine(settings.DeleteOriginalAudioTrack);

                writer.WriteLine(settings.DefaultPlaybackMode);
                writer.WriteLine(settings.DefaultVolumeMultiplier);

                writer.WriteLine(settings.SubstituteToSpaceInDirectoryOrFileName);

                writer.WriteLine(settings.AudioTrackArtistNotAvailable);
                writer.WriteLine(settings.AudioTrackAlbumNotAvailable);

                writer.WriteLine(settings.ConfirmationStringLength);
            }
            catch
            {
                error = true;
            }
            writer.Close();
            if(!error)
            {
                try
                {
                    File.Delete(AppDefaults.ConfigFilePath);
                    File.Move(AppDefaults.ConfigFilePath + "_tmp", AppDefaults.ConfigFilePath);
                }
                catch
                {
                }
            }
            else
                File.Delete(AppDefaults.ConfigFilePath + "_tmp");
        }
    }
}
