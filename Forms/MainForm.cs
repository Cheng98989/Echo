using Microsoft.VisualBasic.Logging;
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

namespace Echo
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
        //private int currentPlayingAudio = -1;
        
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
                //Forse per evitare problemi durante il salvataggio di file meglio togliere la possibilita di avere stesso nome
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
            UIHelper.ShowImageInPictureBox(picSelectedAudioAlbumArt, playlist[audioIndex].AlbumArt);
        }

        private void ptbSelectedAudioPosition_MouseLeave(object sender, EventArgs e)
        {
            plbSelectedAudioPositionTrackTime.Visible = false;
        }

        private void ptlSelectedAudioPlay_Click(object sender, EventArgs e)
        {
            //Controllo
            if (playlistCount <= 0)
            {
                MessageBox.Show("Playlist Vuota");
                return;
            }

            //Ricerca audio tramite index della poison list view o in base a una ricerca su titolo o autore
            int audioIndex = default;
            if (plvPlaylist.FocusedItem == null)
                audioIndex = TrackMetaData.FindTrackIndexByTitleAndArtist(plbSelectedAudioTitle.Text, plbSelectedAudioArtist.Text, playlist, playlistCount);
            else
                audioIndex = plvPlaylist.FocusedItem.Index;
            
            //Fallback in caso di audio non trovato
            if (audioIndex == -1)
            {
                MessageBox.Show("Audio non trovato");
                return;
            }
            //Elimino la variabile int current playing audio perche' mi serviva per salvare la canzone che stava girando e salvare il suo last volume (che sto togliendo)
            //Se sto un'altro audio e' in riproduzione mi salvo il suo volume (else) altrimenti nulla
            //if (currentPlayingAudio == -1)
            //    TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader,ref waveOutDevice);
            //else
            //    playlist[currentPlayingAudio].VolumeMultiplier = TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader, ref waveOutDevice);

            //psbSelectedAudioVolume.Value = UIHelper.waveOutEventVolumeTopsbValue(playlist[audioIndex].VolumeMultiplier);
            float startVolume = UIHelper.psbValueTowaveOutEventVolume(psbSelectedAudioVolume.Value);
            TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader, ref waveOutDevice, startVolume);

            //currentPlayingAudio = audioIndex;
        }

        private void ptlSelectedAudioPause_Click(object sender, EventArgs e)
        {
            TrackManager.PauseTrack(waveOutDevice);
        }

        private void ptlSelectedAudioStop_Click(object sender, EventArgs e)
        {
            //Eliminato perche' last volume lo sto togliendo
            //if (currentPlayingAudio == -1)
            //    return;
            //playlist[currentPlayingAudio].VolumeMultiplier = TrackManager.StopTrack(ref audioFileReader,ref waveOutDevice);
            TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
        }

        //ContextMenuStrip Tabella playlist

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

            string confirmationString = StringHelper.GenerateString(AppDefaults.ConfirmationStringLeght);

            ConfirmForm uc = new ConfirmForm(confirmationString);
            uc.ShowDialog();
            if (uc.DialogResult != DialogResult.OK)
                return;

            playlistCount = 0;

            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);

            plbSelectedAudioTitle.Text = "Non disponibile";
            plbSelectedAudioArtist.Text = "Non disponibile";
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;
        }

        private void tspSelectedAudioDelete_Click(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null)
            {
                PoisonMessageBox.Show(this, "Nessun Audio Selezionato");
                return;
            }
            int selectedIndex = plvPlaylist.FocusedItem.Index;

            TrackMetaData.DeleteAudioTrackFromArray(selectedIndex, playlist, ref playlistCount, true);

            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);

            plbSelectedAudioTitle.Text = "Non disponibile";
            plbSelectedAudioArtist.Text = "Non disponibile";
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;
        }

        private void tspSelectedAudioModify_Click(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null)
            {
                PoisonMessageBox.Show(this, "Nessun Audio Selezionato");
                return;
            }
            int selectedIndex = plvPlaylist.FocusedItem.Index;

            ModifyForm mf = new ModifyForm(playlist[selectedIndex]);
            mf.ShowDialog();

            if(mf.DialogResult == DialogResult.OK)
                playlist[selectedIndex] = mf.audioTrack;
        }

        //Salvataggio su file in cui le canzoni dal percorso file iniziale vengono copiate in una cartella e il percorso file viene anche modificato
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Controllo
            if (playlistCount <= 0)
            {
                MessageBox.Show("Playlist Vuota");
                return;
            }
            string playlistName = ptxPlaylistName.Text.Trim();
            if (string.IsNullOrEmpty(playlistName))
            {
                PoisonMessageBox.Show(
                    this,
                    "Nome della playlist mancante"
                    );
                return;
            }

            //Richiesta conferma via poisonmessagebox

            
            if (!StringHelper.CanBeADirectoryOrFileName(playlistName))
            {
                PoisonMessageBox.Show(
                    this,
                    $"Il titolo (max: 30 caratteri) non puo' contenere i seguenti caratteri \n" +
                    $"{string.Join(", ", AppDefaults.NotAllowedCharsInDirectoryOrFileName)}"
                    );
                return;
            }

            playlistName = playlistName.Replace(' ', AppDefaults.SubstituteToSpaceInDirectoryOrFileName);

            string playlistPath = Path.Combine(AppDefaults.AudioTrackSavePath, playlistName);

            if (!Directory.Exists(playlistPath))
            {
                Directory.CreateDirectory(playlistPath);
            }


            try
            {
                for (int i = 0; i < playlistCount; i++)
                {
                    if (!System.IO.File.Exists(playlist[i].FilePath))
                    {
                        PoisonMessageBox.Show(
                            this,
                            $"Errore durante il salvattaggio di {playlist[i].FilePath}, file non trovato"
                            );
                        return;
                    }
                    string audioTrackFileName = Path.GetFileName(playlist[i].FilePath);
                    string destination = Path.Combine(playlistPath, audioTrackFileName);
                    System.IO.File.Copy(playlist[i].FilePath,destination,true);
                    TrackMetaData.OverwriteMP3MetaTags(destination, playlist[i]);
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(
                            this,
                            $"Errore {ex.Message}"
                            );
            }
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Controllo
            if (playlistCount > 0)
            {
                DialogResult res = PoisonMessageBox.Show(
                    this,
                    "Sei sicuro di voler caricare una nuova playlist?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel
                    );
                if (res != DialogResult.Yes)
                    return;
            }

            //Select Directory
            FolderBrowserDialog openFileManager = new FolderBrowserDialog();
            string directoryPath;
            if (openFileManager.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            directoryPath = openFileManager.SelectedPath;
            playlistCount = 0;
            string[] mp3Paths = Directory.GetFiles(directoryPath);
            for (int i = 0; i < mp3Paths.Length && i < AppDefaults.MaxLoadedTracks; i++)
            {
                //Repetition verification
                if(System.IO.Path.GetExtension(mp3Paths[i]) != ".mp3")
                    continue;
                TrackMetaData.AudioTrack newTrack = TrackMetaData.FromFile(mp3Paths[i]);
                int findResult = TrackMetaData.FindTrackIndexByTitleAndArtist(newTrack.Title, newTrack.Artist, playlist, playlistCount);
                if (findResult != -1)
                {
                    //Forse per evitare problemi durante il salvataggio di file meglio togliere la possibilita di avere stesso nome
                    DialogResult result = PoisonMessageBox.Show(
                    this,
                    $"È già presente nella playlist un brano con lo stesso titolo \"{newTrack.Title}\" " +
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
            }
            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);
        }
    }
}
