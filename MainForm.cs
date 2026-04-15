using NAudio.Wave;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Matroska;

namespace SoundDeck
{
    public partial class MainForm : PoisonForm
    {
        public MainForm()
        {
            InitializeComponent();

            // Imposta lo stile per la Form principale (opzionale)
            // this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;

            // Applica lo stile a tutti i controlli della form specificando la famiglia
            // Puoi sostituire "Poison" con "Crown" o la famiglia che desideri
            UIHelper.SetReaLTaiizorControlsStyle(this, "Poison", this.Style);
            psbSelectedAudioVolume.Value = 100;


            //Default Image for albul art
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;

            //Resizing Play,Pause,Stop images to 32x32
            ptlSelectedAudioPlay.TileImage = ImageHelper.ResizeImage(
                ptlSelectedAudioPlay.TileImage,
                ptlSelectedAudioPlay.Width,
                ptlSelectedAudioPlay.Height
                );
            ptlSelectedAudioPause.TileImage = ImageHelper.ResizeImage(
                ptlSelectedAudioPause.TileImage,
                ptlSelectedAudioPause.Width,
                ptlSelectedAudioPause.Height
                );
            ptlSelectedAudioStop.TileImage = ImageHelper.ResizeImage(
                ptlSelectedAudioStop.TileImage,
                ptlSelectedAudioStop.Width,
                ptlSelectedAudioStop.Height
                );

            //Metto in posizione il time tracker
            plbSelectedAudioPositionTrackTime.Location = UIHelper.GetTrackTimeLabelPosition(
                value: ptbSelectedAudioPosition.Value,
                min: ptbSelectedAudioPosition.Minimum,
                max: ptbSelectedAudioPosition.Maximum,
                trackLocation: ptbSelectedAudioPosition.Location,
                trackWidth: ptbSelectedAudioPosition.Width,
                labelWidth: plbSelectedAudioPositionTrackTime.Width
            );

            plbSelectedAudioPositionTrackTime.Text = TrackMetaData.FormatTrackTime(ptbSelectedAudioPosition.Value);
        }


        //Global
        private TrackMetaData.AudioTrack[] playlist = new TrackMetaData.AudioTrack[AppDefaults.MaxLoadedTracks];
        private int playlistCount = default;
        private int currentPlayingAudio = -1;
        
        private WaveOutEvent waveOutDevice;
        private AudioFileReader audioFileReader;

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
            base.OnFormClosed(e);
        }








        private void psbSelectedAudioVolume_Scroll(object sender, ScrollEventArgs e)
        {
            //Sottrago value a 100 perche' la scroll bar parte dall'alto
            ptlSelectedAudioVolumePct.Text = (100 - psbSelectedAudioVolume.Value) + "%";

            //Controllo volume
            if (waveOutDevice != null)
                waveOutDevice.Volume = UIHelper.psbValueTowaveOutEventVolume(psbSelectedAudioVolume.Value);
        }

        private void pbtBrowseAudio_Click(object sender, EventArgs e)
        {
            //Select File
            OpenFileDialog openFileManager = new OpenFileDialog();
            openFileManager.Filter = "File MP3|*.mp3";
            openFileManager.Title = "Seleziona un audio";

            if (openFileManager.ShowDialog() == DialogResult.OK)
            {
                ptxAudioFilePath.Text = openFileManager.FileName;
            }
        }

        private void pbtAddAudio_Click(object sender, EventArgs e)
        {
            //Overflow Prevention
            if (playlistCount >= AppDefaults.MaxLoadedTracks)
            {
                MessageBox.Show("Limite massimo playlist raggiunto");
                return;
            }

            //File verification
            string filePath = ptxAudioFilePath.Text;
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("File Inesistente");
                return;
            }

            //Repetition verification
            TrackMetaData.AudioTrack newTrack = TrackMetaData.FromFile(filePath);
            int findResult = TrackMetaData.FindTrackIndexByTitleAndArtist(newTrack.Title, newTrack.Artist, playlist, playlistCount);
            if(findResult != -1)
            {
                DialogResult result = PoisonMessageBox.Show(
                this,
                $"È già presente nella playlist un brano con lo stesso titolo \"{newTrack.Title}\" " +
                $"e lo stesso autore \"{newTrack.Artist}\".\n\n" +
                "Vuoi aggiungerlo comunque?",
                "Brano duplicato",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                    return;
            } 

            playlist[playlistCount] = newTrack;
            playlistCount++;

            UIHelper.PopulatePlaylistListView(playlist,playlistCount,plvPlaylist);
        }
        private void ptbSelectedAudioPosition_MouseHover(object sender, EventArgs e)
        {
            plbSelectedAudioPositionTrackTime.Visible = true;
        }

        private void ptbSelectedAudioPosition_Scroll(object sender, ScrollEventArgs e)
        {
            plbSelectedAudioPositionTrackTime.Location = UIHelper.GetTrackTimeLabelPosition(
                value: ptbSelectedAudioPosition.Value,
                min: ptbSelectedAudioPosition.Minimum,
                max: ptbSelectedAudioPosition.Maximum,
                trackLocation: ptbSelectedAudioPosition.Location,
                trackWidth: ptbSelectedAudioPosition.Width,
                labelWidth: plbSelectedAudioPositionTrackTime.Width
            );

            plbSelectedAudioPositionTrackTime.Text = TrackMetaData.FormatTrackTime(ptbSelectedAudioPosition.Value);
        
        }

        private void plvPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null) return;

            int audioIndex = plvPlaylist.FocusedItem.Index;
            plbSelectedAudioTitle.Text = playlist[audioIndex].Title;
            plbSelectedAudioArtist.Text = playlist[audioIndex].Artist;
            picSelectedAudioAlbumArt.Image = playlist[audioIndex].AlbumArt;
        }

        private void ptbSelectedAudioPosition_MouseLeave(object sender, EventArgs e)
        {
            plbSelectedAudioPositionTrackTime.Visible = false;
        }

        private void ptlSelectedAudioPlay_Click(object sender, EventArgs e)
        {
            if (playlistCount <= 0)
            {
                MessageBox.Show("Playlist Vuota");
                return;
            }

            int audioIndex = default;
            if (plvPlaylist.FocusedItem == null)
                audioIndex = TrackMetaData.FindTrackIndexByTitleAndArtist(plbSelectedAudioTitle.Text, plbSelectedAudioArtist.Text, playlist, playlistCount);
            else
                audioIndex = plvPlaylist.FocusedItem.Index;

            if (audioIndex == -1)
            {
                MessageBox.Show("Audio non trovato");
                return;
            }

            if (currentPlayingAudio == -1)
                TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader,ref waveOutDevice);
            else
                playlist[currentPlayingAudio].LastVolume = TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader, ref waveOutDevice);

            psbSelectedAudioVolume.Value = UIHelper.waveOutEventVolumeTopsbValue(playlist[audioIndex].LastVolume);



            currentPlayingAudio = audioIndex;
        }

        private void ptlSelectedAudioPause_Click(object sender, EventArgs e)
        {
            TrackManager.PauseTrack(waveOutDevice);
        }

        private void ptlSelectedAudioStop_Click(object sender, EventArgs e)
        {
            if (currentPlayingAudio == -1)
                return;
            playlist[currentPlayingAudio].LastVolume = TrackManager.StopTrack(ref audioFileReader,ref waveOutDevice);
        }

        //ContextMenuStrip Tabella playlist
        private void tspDeleteAudioSelected_Click(object sender, EventArgs e)
        {
            if(plvPlaylist.FocusedItem == null)
            {
                PoisonMessageBox.Show(this,"Nessun Audio Selezionato");
                return;
            }
            int selectedIndex = plvPlaylist.FocusedItem.Index;

            TrackMetaData.DeleteAudioTrackFromArray(selectedIndex, playlist, ref playlistCount, true);

            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);

            plbSelectedAudioTitle.Text = "Non disponibile";
            plbSelectedAudioArtist.Text = "Non disponibile";
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;
        }

        private void tspDeleteAudioAll_Click(object sender, EventArgs e)
        {
            DialogResult result = PoisonMessageBox.Show(
                this,
                $"Sei sicuro di voler eliminare tutta la playlist?\n" +
                $"Tale azione non è reversibile.",
                "Svuota Playlist",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
                );

            if (result != DialogResult.Yes)
                return;

            ConfirmForm uc = new ConfirmForm("CONFERMO");
            uc.ShowDialog();
            if (uc.Result != true)
                return;

            playlistCount = 0;

            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);

            plbSelectedAudioTitle.Text = "Non disponibile";
            plbSelectedAudioArtist.Text = "Non disponibile";
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;
        }
    }
}
