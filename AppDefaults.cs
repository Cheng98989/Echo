using System;
using System.Drawing;
using TagLib.Matroska;

namespace SoundDeck
{
    /// <summary>
    /// Parametri di default condivisi dall'applicazione.
    /// </summary>
    public static class AppDefaults
    {
        public const int MinVolume = 0;
        public const int MaxVolume = 1;
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
        public static Image NullImage = SoundDeck.Properties.Resources.AlbumArtNotAvailable;

    }
}