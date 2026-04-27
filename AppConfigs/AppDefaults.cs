using Echo.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TagLib.Matroska;

namespace Echo
{
    /// <summary>
    /// Parametri di default condivisi dall'applicazione.
    /// </summary>
    public static class AppDefaults
    {
        #region Application settings file
        public const string ConfigFileName = "settings.echconfig";
        public static string ConfigDirectory = Path.Combine(".", "echoConfig");
        public static string ConfigFilePath = Path.Combine(ConfigDirectory, ConfigFileName);
        #endregion

        #region Default impostazioni utente
        public static string BrowseAudioTracksInitialDirectory = "C:";
        public static bool DeleteOriginalAudioTrack = false;
        public static string PlaylistSavePath = Path.Combine(".", "playlists");
        public static string BrowsePlaylistsInitialDirectory = PlaylistSavePath;

        public static readonly Playback.PlaybackMode DefaultPlaybackMode = Playback.PlaybackMode.Loop;
        public static readonly float DefaultVolumeMultiplier = 1f;
        public static readonly int MaxLoadedTracks = 500;

        public static char SubstituteToSpaceInDirectoryOrFileName = '-';

        public static readonly string AudioTrackArtistNotAvailable = "Not_Available";
        public static readonly string AudioTrackAlbumNotAvailable = "Not_Available";

        public const int ConfirmationStringLength = 5;
        #endregion

        public static readonly AppSettings.UserSettings defaultUserSettings = new AppSettings.UserSettings
        {
            EchOnLoad = "",
            BrowseAudioTracksInitialDirectory = BrowseAudioTracksInitialDirectory,
            BrowsePlaylistsInitialDirectory = BrowsePlaylistsInitialDirectory,
            DeleteOriginalAudioTrack = DeleteOriginalAudioTrack,
            DefaultPlaybackMode = DefaultPlaybackMode,
            DefaultVolumeMultiplier = DefaultVolumeMultiplier,
            SubstituteToSpaceInDirectoryOrFileName = SubstituteToSpaceInDirectoryOrFileName,
            AudioTrackArtistNotAvailable = AudioTrackArtistNotAvailable,
            AudioTrackAlbumNotAvailable = AudioTrackAlbumNotAvailable,
            ConfirmationStringLength = ConfirmationStringLength
        };


        #region Costanti interne non modificabili dall’utente
        public const int DirectoryOrFileNameMaxLenght = 30;
        private static readonly char[] _notAllowedCharsInDirectoryOrFileName = new char[]
        {
            '/', '\\', '<', '>', ':', '"', '|', '?', '*', '\0'
        };

        public static char[] NotAllowedCharsInDirectoryOrFileName
        {
            get { return (char[])_notAllowedCharsInDirectoryOrFileName.Clone(); }
        }

        public const int MinDeviceVolume = 0;
        public const int MaxDeviceVolume = 1;
        

        public const string AudioTrackError = "Error";
        public static string DefaultAudioTrackAlbumArtMessage = ".";//Testo che indica durante la modifica di mantenere l'immagine di album art originale
        public static Image NullImage = Echo.Properties.Resources.AlbumArtNotAvailable;
        #endregion
    }
}