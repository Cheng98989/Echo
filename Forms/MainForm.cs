using Echo.AudioTrackClasses;
using Echo.Helpers;
using Microsoft.VisualBasic.Logging;
using NAudio.Utils;
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
        // Stato form
        private TrackMetaData.AudioTrack[] playlist = new TrackMetaData.AudioTrack[AppDefaults.MaxLoadedTracks];
        private int playlistCount = default;
        private Playback.PlaybackMode mode = AppDefaults.DefaultPlaybackMode;

        private WaveOutEvent waveOutDevice;
        private AudioFileReader audioFileReader;

        
        // Indica se l'utente sta cercando manualmente un punto nella traccia
        private bool isUserSeeking = false;

        // Inizializzazione form
        public MainForm()
        {
            InitializeComponent();

            // Stile controlli
            // this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            UIHelper.SetReaLTaiizorControlsStyle(this, "Poison", this.Style);
            psbSelectedAudioVolume.Value = 100;

            // Immagine default
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;

            // Resize icone controlli player
            ptlSelectedAudioPlay.TileImage = ImageHelper.ResizeImage(
                ptlSelectedAudioPlay.TileImage,
                ptlSelectedAudioPlay.Width,
                ptlSelectedAudioPlay.Height
                );

            // Posizione iniziale label tempo
            plbSelectedAudioPositionTrackTime.Location = UIHelper.GetTrackTimeLabelPosition(
                value: ptbSelectedAudioPosition.Value,
                min: ptbSelectedAudioPosition.Minimum,
                max: ptbSelectedAudioPosition.Maximum,
                trackLocation: ptbSelectedAudioPosition.Location,
                trackWidth: ptbSelectedAudioPosition.Width,
                labelWidth: plbSelectedAudioPositionTrackTime.Width
            );
            
            plbSelectedAudioPositionTrackTime.Text = TrackMetaData.FormatTrackTime(ptbSelectedAudioPosition.Value);

            pcbPlaybackMode.Items.Clear();
            pcbPlaybackMode.Items.AddRange(Enum.GetNames(typeof(Playback.PlaybackMode)));
            pcbPlaybackMode.SelectedItem = mode.ToString();
        }

        // Chiusura form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
            base.OnFormClosed(e);
        }

        // Eventi UI
        private void psbSelectedAudioVolume_Scroll(object sender, ScrollEventArgs e)
        {
            // Aggiorno testo volume
            ptlSelectedAudioVolumePct.Text = (100 - psbSelectedAudioVolume.Value) + "%";

            // Aggiorno volume device
            if (waveOutDevice != null)
                waveOutDevice.Volume = UIHelper.psbValueTowaveOutEventVolume(psbSelectedAudioVolume.Value);
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

        private void ptbSelectedAudioPosition_MouseLeave(object sender, EventArgs e)
        {
            plbSelectedAudioPositionTrackTime.Visible = false;
        }

        private void plvPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null) return;
            int audioIndex = plvPlaylist.Items.IndexOf(plvPlaylist.FocusedItem); ;
            updateAudioTrackPanel(audioIndex);
        }
        private void updateAudioTrackPanel(int index)
        {
            plbSelectedAudioTitle.Text = playlist[index].Title;
            plbSelectedAudioArtist.Text = playlist[index].Artist;
            UIHelper.ShowImageInPictureBox(picSelectedAudioAlbumArt, playlist[index].AlbumArt);
        }

        // Gestione playlist
        private void pbtBrowseAddAudio_Click(object sender, EventArgs e)
        {
            // Limite brani
            
            // Selezione file
            OpenFileDialog openFileManager = new OpenFileDialog();
            openFileManager.Filter = "File MP3|*.mp3";
            openFileManager.Title = "Seleziona un audio";
            openFileManager.InitialDirectory = Directory.GetDirectoryRoot(AppDefaults.BrowseAudioTracksInitialDirectory);
            openFileManager.Multiselect = true;
            if (openFileManager.ShowDialog() != DialogResult.OK)
                return;

            foreach (string filePath in openFileManager.FileNames)
            {
                if (playlistCount >= AppDefaults.MaxLoadedTracks)
                {
                    PoisonMessageBox.Show(
                        this,
                        "Hai raggiunto il numero massimo di brani caricabili nella playlist.",
                        "Limite raggiunto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    break;
                }
                // Verifica file

                if (!System.IO.File.Exists(filePath))
                {
                    PoisonMessageBox.Show(
                        this,
                        "Il file selezionato non esiste o non è più disponibile.",
                        "File non trovato",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return;
                }
                
                // Evito duplicati per path
                TrackMetaData.AudioTrack newTrack = TrackMetaData.FromFile(filePath);
                int findResult = TrackMetaData.FindTrackIndexByFilePath(filePath, playlist, playlistCount);
                if (findResult != -1)
                {
                    DialogResult result = PoisonMessageBox.Show(
                    this,
                    $"È già presente nella playlist un brano dallo stesso percorso file \"{newTrack.Title}\"\n" +
                    $"Non verrà aggiunto nuovamente.",
                    "Brano duplicato",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    continue;
                }

                playlist[playlistCount] = newTrack;
                playlistCount++;  
            }
            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);
        }


        private void tspSelectedAudioModify_Click(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null)
            {
                PoisonMessageBox.Show(
                    this,
                    "Seleziona un brano dalla playlist prima di modificarne i dati.",
                    "Nessun brano selezionato",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return;
            }
            int selectedIndex = plvPlaylist.Items.IndexOf(plvPlaylist.FocusedItem); ;

            ModifyForm mf = new ModifyForm(playlist[selectedIndex]);
            mf.ShowDialog();

            if(mf.DialogResult == DialogResult.OK)
                playlist[selectedIndex] = mf.audioTrack;
        }

        private void tspSelectedAudioDelete_Click(object sender, EventArgs e)
        {
            if (plvPlaylist.FocusedItem == null)
            {
                PoisonMessageBox.Show(
                    this,
                    "Seleziona un brano dalla playlist prima di procedere.",
                    "Nessun brano selezionato",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return;
            }
            int selectedIndex = plvPlaylist.Items.IndexOf(plvPlaylist.FocusedItem); ;

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

            string confirmationString = StringHelper.GenerateString(AppDefaults.ConfirmationStringLeght);

            ConfirmForm uc = new ConfirmForm(confirmationString);
            uc.ShowDialog();
            if (uc.DialogResult != DialogResult.OK)
                return;
            TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
            playlistCount = 0;

            UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);

            plbSelectedAudioTitle.Text = "Non disponibile";
            plbSelectedAudioArtist.Text = "Non disponibile";
            picSelectedAudioAlbumArt.Image = picSelectedAudioAlbumArt.InitialImage;
        }

        // Riproduzione
        private void ptlSelectedAudioPlay_Click(object sender, EventArgs e)
        {

            // Verifica playlist
            if (playlistCount <= 0)
            {
                PoisonMessageBox.Show(
                    this,
                    "La playlist è vuota. Aggiungi almeno un brano prima di avviare la riproduzione.",
                    "Playlist vuota",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return;
            }

            // Recupero indice brano
            int audioIndex = default;
            
            if (plvPlaylist.FocusedItem == null)
                audioIndex = TrackMetaData.FindTrackIndexByTitleAndArtist(plbSelectedAudioTitle.Text, plbSelectedAudioArtist.Text, playlist, playlistCount);
            else
                audioIndex = plvPlaylist.Items.IndexOf(plvPlaylist.FocusedItem);

            // Brano non trovato
            if (audioIndex == -1)
            {
                PoisonMessageBox.Show(
                    this,
                    "Non è stato possibile trovare il brano selezionato nella playlist corrente.",
                    "Brano non trovato",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            if(audioFileReader != null)
            {
                string previusTrackFilePath = audioFileReader.FileName;
                //pause alla traccia se è  in riproduzione e index della traccia in riproduzione è uguale a quello del brano selezionato
                if (TrackStatus.IsTrackPlaying(waveOutDevice) && audioFileReader != null)
                {
                    
                    TrackManager.PauseTrack(waveOutDevice);
                    if (previusTrackFilePath == playlist[audioIndex].FilePath)
                    {
                        UIHelper.UpdateAudioPoisonTileState(waveOutDevice, audioFileReader, ptlSelectedAudioPlay);
                        return;
                    }
                        
                }
                if(TrackStatus.IsTrackPaused(waveOutDevice) && audioFileReader != null)
                {
                    if (previusTrackFilePath == playlist[audioIndex].FilePath)
                    {
                        TrackManager.ResumeTrack(waveOutDevice);
                        UIHelper.UpdateAudioPoisonTileState(waveOutDevice, audioFileReader, ptlSelectedAudioPlay);
                        audioPositionTimer.Start();
                        
                        return;
                    }
                }
            }

            // Avvio traccia
            float startVolume = UIHelper.psbValueTowaveOutEventVolume(psbSelectedAudioVolume.Value);
            TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader, ref waveOutDevice, startVolume);
            UIHelper.UpdateAudioPoisonTileState(waveOutDevice, audioFileReader, ptlSelectedAudioPlay);
            ptbSelectedAudioPosition.Maximum = (int)playlist[audioIndex].Duration.TotalSeconds;
            audioPositionTimer.Stop();
            audioPositionTimer.Start();
            
        }


        

        // Salvataggio playlist
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Playlist vuota
            if (playlistCount <= 0)
            {
                PoisonMessageBox.Show(
                    this,
                    "La playlist è vuota. Aggiungi almeno un brano prima di salvare.",
                    "Playlist vuota",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return;
            }

            // Nome playlist
            string playlistName = ptxPlaylistName.Text.Trim();
            if (string.IsNullOrEmpty(playlistName))
            {
                PoisonMessageBox.Show(
                    this,
                    "Nome della playlist mancante",
                    "Nome non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            if (!StringHelper.CanBeADirectoryOrFileName(playlistName))
            {
                PoisonMessageBox.Show(
                    this,
                    $"Il nome playlist (max: 30 caratteri) non può contenere i seguenti caratteri:\n" +
                    $"{string.Join(", ", AppDefaults.NotAllowedCharsInDirectoryOrFileName)}",
                    "Nome non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            // Conferma salvataggio
            DialogResult confirmSave = PoisonMessageBox.Show(
                this,
                $"Vuoi salvare la playlist \"{playlistName}\"?\n" +
                $"I file audio verranno copiati nella cartella di salvataggio.",
                "Conferma salvataggio",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
                );

            if (confirmSave != DialogResult.Yes)
                return;

            int result = TrackMetaData.SavePlaylistInEch(
                AppDefaults.AudioTrackSavePath,
                playlistName,
                playlist,
                playlistCount,
                out int[] errors);

            switch (result)
            {
                case 0:
                    PoisonMessageBox.Show(
                        this,
                        "Playlist salvata correttamente.",
                        "Salvataggio completato",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    break;

                case -1:
                    string missingFiles = string.Join(
                        "\n",
                        errors.Select(i => $"[{i}] {playlist[i].FilePath}"));

                    PoisonMessageBox.Show(
                        this,
                        "Impossibile salvare: alcuni file della playlist non esistono.\n\n" + missingFiles,
                        "File mancanti",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    break;

                case -2:
                    PoisonMessageBox.Show(
                        this,
                        $"Nome playlist non valido.\n" +
                        $"Max {AppDefaults.DirectoryOrFileNameMaxLenght} caratteri, " +
                        $"caratteri vietati: {string.Join(", ", AppDefaults.NotAllowedCharsInDirectoryOrFileName)}",
                        "Nome non valido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    break;

                case -3:
                    PoisonMessageBox.Show(
                        this,
                        "Si è verificato un errore durante il salvataggio della playlist.",
                        "Errore di salvataggio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    break;

                default:
                    PoisonMessageBox.Show(
                        this,
                        $"Codice di ritorno inatteso: {result}",
                        "Errore imprevisto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    break;
            }
        }

        // Caricamento playlist
        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Conferma caricamento
            if (playlistCount > 0)
            {
                DialogResult res = PoisonMessageBox.Show(
                    this,
                    "Sei sicuro di voler caricare una nuova playlist?",
                    "Conferma",
                    MessageBoxButtons.YesNoCancel
                    );
                if (res != DialogResult.Yes)
                    return;
            }
            TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);

            // Selezione file ech
            OpenFileDialog openFileManager = new OpenFileDialog();
            openFileManager.Filter = "File Echo|*.ech";
            openFileManager.Title = "Seleziona una playlist";
            if (!Directory.Exists(AppDefaults.AudioTrackSavePath))
                Directory.CreateDirectory(AppDefaults.AudioTrackSavePath);
            openFileManager.InitialDirectory = Path.GetFullPath(AppDefaults.AudioTrackSavePath);

            if (openFileManager.ShowDialog() != DialogResult.OK)
                return;

            string echPath = openFileManager.FileName;
            string loadedPlaylistName = string.Empty;
            TrackMetaData.AudioTrack[] loadedPlaylist = null;

            int result = TrackMetaData.LoadPlaylistFromEch(
                echPath,
                ref loadedPlaylistName,
                ref loadedPlaylist);

            switch (result)
            {
                case 0:
                    playlist = loadedPlaylist ?? new TrackMetaData.AudioTrack[AppDefaults.MaxLoadedTracks];
                    playlistCount = Math.Min(
                        (loadedPlaylist != null ? loadedPlaylist.Length : 0),
                        AppDefaults.MaxLoadedTracks);

                    ptxPlaylistName.Text = loadedPlaylistName;
                    UIHelper.PopulatePlaylistListView(playlist, playlistCount, plvPlaylist);
                    break;

                case -1:
                    PoisonMessageBox.Show(
                        this,
                        "Il file selezionato non è una playlist valida (.ech) o la struttura associata non è corretta.",
                        "Playlist non valida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    break;

                case -2:
                    PoisonMessageBox.Show(
                        this,
                        "Si è verificato un errore durante il caricamento della playlist.",
                        "Errore di caricamento",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    break;

                default:
                    PoisonMessageBox.Show(
                        this,
                        $"Codice di ritorno inatteso: {result}",
                        "Errore imprevisto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    break;
            }
        }

        // Utility menu
        private void playlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetFullPath(AppDefaults.AudioTrackSavePath);
            openFileDialog.ShowDialog();
        }

        private void ptbSelectedAudioPosition_MouseDown(object sender, MouseEventArgs e)
        {
            isUserSeeking = true;
            audioPositionTimer.Stop();
        }

        private void ptbSelectedAudioPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (audioFileReader == null)
                return;

            int targetSeconds = ptbSelectedAudioPosition.Value;

            audioFileReader.CurrentTime = TimeSpan.FromSeconds(targetSeconds);

            isUserSeeking = false;

            if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
                audioPositionTimer.Start();
        }

        private void audioPositionTimer_Tick(object sender, EventArgs e)
        {
            if(!TrackStatus.IsInitialized(waveOutDevice, audioFileReader))
            {
                audioPositionTimer.Stop();
                UIHelper.ResetPoisonTrackBar(ptbSelectedAudioPosition);
                plbSelectedAudioPositionTime.Text = $"{TrackMetaData.FormatTrackTime(0)}/{TrackMetaData.FormatTrackTime(0)}";
                return;
            }
            //fine riproduzione canzone
            if (TrackStatus.IsTrackStopped(waveOutDevice) && audioFileReader != null)
            {
                audioPositionTimer.Stop();
                switch (pcbPlaybackMode.SelectedIndex)
                {
                    case 0://single
                        TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
                        UIHelper.ResetPoisonTrackBar(ptbSelectedAudioPosition);
                        plbSelectedAudioPositionTime.Text = $"{TrackMetaData.FormatTrackTime(0)}/{TrackMetaData.FormatTrackTime(0)}";
                        return;
                    case 1://loop
                        TrackManager.LoopTrack(ref audioFileReader, ref waveOutDevice);
                        audioPositionTimer.Start();
                        break;
                    case 2://shuffle
                        string previusTrackFilePath = audioFileReader.FileName;
                        TrackManager.StopTrack(ref audioFileReader, ref waveOutDevice);
                        //Chosing random trackn not equal to the previus one
                        Random rand = new Random();
                        int audioIndex;
                        do
                        {
                            audioIndex = rand.Next(0, playlistCount);
                        }
                        while(previusTrackFilePath == playlist[audioIndex].FilePath);
                        plvPlaylist.FocusedItem = plvPlaylist.Items[audioIndex];
                        updateAudioTrackPanel(audioIndex);
                        UIHelper.UpdateAudioPoisonTileState(waveOutDevice, audioFileReader, ptlSelectedAudioPlay);
                        float startVolume = UIHelper.psbValueTowaveOutEventVolume(psbSelectedAudioVolume.Value);
                        TrackManager.StartTrack(playlist[audioIndex], ref audioFileReader, ref waveOutDevice, startVolume);
                        ptbSelectedAudioPosition.Maximum = (int)playlist[audioIndex].Duration.TotalSeconds;
                        audioPositionTimer.Start();
                        break;
                }
            }
            //canzone in pausa
            if(TrackStatus.IsTrackPaused(waveOutDevice) && audioFileReader != null)
            {
                audioPositionTimer.Stop();
            }

            //aggiorno posizione canzone durante la riproduzione
            int seconds = (int)audioFileReader.CurrentTime.TotalSeconds;
            ptbSelectedAudioPosition.Value = seconds;
            plbSelectedAudioPositionTime.Text = $"{TrackMetaData.FormatTrackTime(seconds)}/{TrackMetaData.FormatTrackTime(ptbSelectedAudioPosition.Maximum)}";
        

        }
    }
}
