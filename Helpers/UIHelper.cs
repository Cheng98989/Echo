using Echo.AudioTrackClasses;
using Echo.Helpers;
using NAudio.Wave;
using ReaLTaiizor.Child.Crown;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Matroska;

namespace Echo
{
    public static class UIHelper
    {
        public static ListViewItem CreateAudioListListItem(TrackMetaData.AudioTrack audio)
        {
            ListViewItem item = new ListViewItem(audio.Title);
            item.SubItems.Add(audio.Artist);
            item.SubItems.Add(audio.Duration.ToString("mm\\:ss"));
            return item;
        }

        public static void PopulatePlaylistListView(TrackMetaData.AudioTrack[] playlist, int playlistCount, PoisonListView poisonListView, bool append = false)
        {
            if (!append)
                poisonListView.Items.Clear();

            for (int i = 0; i < playlistCount; i++)
            {
                ListViewItem item = CreateAudioListListItem(playlist[i]);
                poisonListView.Items.Add(item);
            }

        }
        public static Point GetTrackTimeLabelPosition(
            int value,
            int min,
            int max,
            Point trackLocation,
            int trackWidth,
            int labelWidth,
            int trackPadding = 5,
            int yOffset = 20,
            int xOffset = 3
        )
        {
            int usableWidth = trackWidth - trackPadding;

            int mappedX = (int)MathHelper.LinearMapClamp(
                value,
                min,
                max,
                0,
                usableWidth
            );

            int x = trackLocation.X
                    + mappedX
                    - (labelWidth / 2)
                    + xOffset;

            int y = trackLocation.Y - yOffset;

            return new Point(x, y);
        }
        public static int waveOutEventVolumeTopsbValue(float volume)
        {
            return (int)MathHelper.LinearMapClamp(volume, 0, 1, 100, 0);
        }
        public static float psbValueTowaveOutEventVolume(int volume)
        {
            return (float)MathHelper.LinearMapClamp(volume, 100, 0, 0, 1);
        }

        public static void ShowImageInPictureBox(PictureBox pic, Image image)
        {
            if (pic == null)
                throw new ArgumentNullException(nameof(pic));

            if (image == null)
            {
                pic.Image = AppDefaults.NullImage;
                return;
            }
            pic.Image = image;
        }




        public static void ResetPoisonTrackBarAndTextWithTime(PoisonTrackBar trackbar, PoisonLabel label)
        {
            label.Text = $"{TrackMetaData.FormatTrackTime(0)}/{TrackMetaData.FormatTrackTime(0)}";
            trackbar.Minimum = 0;
            trackbar.Maximum = 1;
            trackbar.Value = 0;
        }

        public static void UpdateAudioPoisonIcon(WaveOutEvent waveOutDevice, AudioFileReader audioFileReader,PictureBox playIcon, PictureBox pauseIcon)
        {
            if (TrackStatus.IsInitialized(waveOutDevice, audioFileReader))
            {
                switch (waveOutDevice.PlaybackState)
                {
                    case PlaybackState.Playing:
                        pauseIcon.Visible = true;
                        playIcon.Visible = false; // Sostituisci con l'icona appropriata per lo stato "Playing"
                        break;
                    case PlaybackState.Paused:
                    case PlaybackState.Stopped:
                        playIcon.Visible = true;
                        pauseIcon.Visible = false;// Sostituisci con l'icona appropriata per lo stato "Stopped"
                        break;
                }
                return;
            }
            playIcon.Visible = true;
            pauseIcon.Visible = false;
        }


    }
}

