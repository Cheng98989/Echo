using Echo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo
{
    public class AppSettings
    {
        public struct UserSettings
        {
            public int VolumeOnLoad;
            public string EchOnLoad;

            public string BrowseAudioTracksInitialDirectory;
            public string BrowsePlaylistsInitialDirectory;

            public bool DeleteOriginalAudioTrack;

            public Playback.PlaybackMode DefaultPlaybackMode;
            public float DefaultVolumeMultiplier;
        
            public char SubstituteToSpaceInDirectoryOrFileName;

            public string AudioTrackArtistNotAvailable;
            public string AudioTrackAlbumNotAvailable;

            public int ConfirmationStringLength;

        }
    }
}
