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
        public static void StartTrack(TrackMetaData.AudioTrack audio,ref AudioFileReader audioFileReader, ref WaveOutEvent waveOutEvent, float volume)
        {
            //Sto togliendo lastvolume e derivati
            //float previusAudioVolume = AppDefaults.DefaultVolumeMultiplier;
            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing)
                StopTrack(ref audioFileReader, ref waveOutEvent);

            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Paused)
                waveOutEvent.Play();
                //return -1;

            try
            {
                audioFileReader = new AudioFileReader(audio.FilePath);
                //Volume Brano
                audioFileReader.Volume = audio.VolumeMultiplier;
                //Volume del programma
                waveOutEvent = new WaveOutEvent();
                //Rimosso perche si ha cambiato da last volume a volume multiplier
                //waveOutEvent.Volume = audio.VolumeMultiplier;
                waveOutEvent.Volume = volume;
                waveOutEvent.Init(audioFileReader);
                waveOutEvent.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante la riproduzione: " + ex.Message);
            }
            //return previusAudioVolume;
            
        }

        public static void StopTrack(ref AudioFileReader audioFileReader,ref WaveOutEvent waveOutEvent)
        {
            //Tolto last volume
            //float lastVolume = AppDefaults.DefaultVolumeMultiplier;
            if (waveOutEvent != null)
            {
                waveOutEvent.Stop();
                waveOutEvent.Dispose();
                waveOutEvent = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        public static void PauseTrack(WaveOutEvent waveOutEvent)
        {
            if (waveOutEvent != null && waveOutEvent.PlaybackState == PlaybackState.Playing)
                waveOutEvent.Pause();
        }
    }
}
