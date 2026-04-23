using System;
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
        public const float DefaultVolumeMultiplier = 0.5f;
        public const int MaxLoadedTracks = 500;
        public const int ConfirmationStringLeght = 5;
    }
}