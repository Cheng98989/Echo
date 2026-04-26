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
        public static AppSettings Load()
        {
            StreamReader reader = new StreamReader(AppDefaults.ConfigFilePath);
            try
            {
                reader.ReadLine();
            }
            catch
            {
                
            }

            return new AppSettings();
        }

        public static bool Save(AppSettings.UserSettings settings)
        {
            bool error = false;
            StreamWriter writer = new StreamWriter(AppDefaults.ConfigFilePath + "_tmp");
            try
            {
                writer.WriteLine(settings.BrowseAudioTracksInitialDirectory);
                writer.WriteLine(settings.AudioTrackSavePath);

                writer.WriteLine(settings.DeleteOriginalAudioTrack);

                writer.WriteLine(settings.PlaybackMode);
                writer.WriteLine(settings.DefaultVolumeMultiplier);

                writer.WriteLine(settings.MaxLoadedTracks);

                writer.WriteLine(settings.SubstituteToSpaceInDirectoryOrFileName);

                writer.WriteLine(settings.AudioTrackArtistNotAvailable);
                writer.WriteLine(settings.AudioTrackAlbumNotAvailable);
                
            }
            catch
            {
                error = true;
            }
            finally
            {
                writer.Close();
            }
            if(!error)
            {
                try
                {
                    File.Delete(AppDefaults.ConfigFilePath);
                    File.Move(AppDefaults.ConfigFilePath + "_tmp", AppDefaults.ConfigFilePath);
                }
                catch
                {
                    return false;
                }
            }
            return !error;
        }
    }
}
