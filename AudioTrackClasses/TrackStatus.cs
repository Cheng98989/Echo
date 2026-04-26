using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace Echo.AudioTrackClasses
{
    public static class TrackStatus
    {
        public static bool IsInitialized(WaveOutEvent waveOutEvent, AudioFileReader audioFileReader)
        {
            return waveOutEvent != null && audioFileReader != null;
        }

        public static bool IsTrackPlaying(WaveOutEvent waveOutEvent)
        {
            return waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing;
        }

        public static bool IsTrackPaused(WaveOutEvent waveOutEvent)
        {
            return waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Paused;
        }

        public static bool IsTrackStopped(WaveOutEvent waveOutEvent)
        {
            return waveOutEvent == null || waveOutEvent.PlaybackState == PlaybackState.Stopped;
        }
    }
}
