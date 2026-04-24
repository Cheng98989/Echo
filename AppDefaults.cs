using System;
using System.Drawing;
using System.IO;
using TagLib.Matroska;

namespace Echo
{
    /// <summary>
    /// Parametri di default condivisi dall'applicazione.
    /// </summary>
    public static class AppDefaults
    {
        //AudioTrack save path
        public static bool DeleteOriginalAudioTrack = false;
        public static string AudioTrackSavePath = Path.Combine(".","playlist");
        public const int DirectoryOrFileNameMaxLenght = 30;
        public static char[] NotAllowedCharsInDirectoryOrFileName = new char[]
        {
            '/',
            '\\',
            '<',
            '>',
            ':',
            '"',
            '|',
            '?',
            '*',
            '\0'
        };

        public static char SubstituteToSpaceInDirectoryOrFileName = '-';

        public const int MinDeviceVolume = 0;
        public const int MaxDeviceVolume = 1;
        public const float DefaultVolumeMultiplier = 1f;
        public const int MaxLoadedTracks = 500;
        public const int ConfirmationStringLeght = 5;

        //File con tag mancanti
        public const string AudioTrackArtistNotAvailable = "Not_Available";
        public const string AudioTrackAlbumNotAvailable = "Not_Available";

        //Errore durante lettura file
        public const string AudioTrackError = "Error";

        //AlbumArt
        public static string DefaultAudioTrackAlbumArtMessage = ".";
        public static Image NullImage = Echo.Properties.Resources.AlbumArtNotAvailable;

    }
}