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
            public string EchOnLoad;

            // ===== Percorsi =====
            public string BrowseAudioTracksInitialDirectory;
            public string BrowsePlaylistsInitialDirectory;

            // ===== Comportamento =====
            public bool DeleteOriginalAudioTrack;

            // ===== Riproduzione =====
            public Playback.PlaybackMode DefaultPlaybackMode;
            public float DefaultVolumeMultiplier;

            // ===== Naming file =====            
            public char SubstituteToSpaceInDirectoryOrFileName;

            // ===== Fallback metadata =====
            public string AudioTrackArtistNotAvailable;
            public string AudioTrackAlbumNotAvailable;

            // ===== Caratteri per messaggio di conferma =====
            public int ConfirmationStringLength;

        }
    }
}
