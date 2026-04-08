using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundDeck
{
    public static class TrackManager
    {
        public static float StartTrack(TrackMetaData.AudioTrack audio,ref AudioFileReader audioFileReader, ref WaveOutEvent waveOutEvent)
        {
            float previusAudioVolume = AppDefaults.DefaultTrackVolume;
            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                previusAudioVolume = StopTrack(ref audioFileReader, ref waveOutEvent);
            }

            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Paused)
            {
                waveOutEvent.Play();
                return -1;
            }

            try
            {
                audioFileReader = new AudioFileReader(audio.FilePath);
                waveOutEvent = new WaveOutEvent();
                waveOutEvent.Volume = audio.LastVolume;
                waveOutEvent.Init(audioFileReader);
                waveOutEvent.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante la riproduzione: " + ex.Message);
            }
            return previusAudioVolume;
            
        }

        public static float StopTrack(ref AudioFileReader audioFileReader,ref WaveOutEvent waveOutEvent)
        {
            float lastVolume = AppDefaults.DefaultTrackVolume;
            if (waveOutEvent != null)
            {
                lastVolume = waveOutEvent.Volume;
                waveOutEvent.Stop();
                waveOutEvent.Dispose();
                waveOutEvent = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            return lastVolume;
        }

        public static void PauseTrack(WaveOutEvent waveOutEvent)
        {
            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                waveOutEvent.Pause();
            }
        }
    }
}
