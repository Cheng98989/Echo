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
            // ===== Percorsi =====
            public string BrowseAudioTracksInitialDirectory;
            public string AudioTrackSavePath;

            // ===== Comportamento =====
            public bool DeleteOriginalAudioTrack;

            // ===== Riproduzione =====
            public Playback.PlaybackMode PlaybackMode;
            public float DefaultVolumeMultiplier;

            // ===== Limiti (potrebbero interessare) =====
            public int MaxLoadedTracks;

            // ===== Naming file =====            
            public char SubstituteToSpaceInDirectoryOrFileName;

            // ===== Fallback metadata =====
            public string AudioTrackArtistNotAvailable;
            public string AudioTrackAlbumNotAvailable;

        }
    }
}
