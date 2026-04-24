using NAudio.Wave;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echo
{
    public partial class ModifyForm : PoisonForm
    {
        public ModifyForm(TrackMetaData.AudioTrack audio)
        {
            InitializeComponent();

            audioTrack = audio;
            if(!File.Exists( audioTrack.FilePath))
            {
                this.DialogResult = DialogResult.Cancel;
                PoisonMessageBox.Show(this, "Percorso file della traccia non valido");
                this.Close();
            }

            audioFile = new AudioFileReader(audioTrack.FilePath);
            displayAudioTrackInfo();
            
        }

        public TrackMetaData.AudioTrack audioTrack { get; private set; }
        AudioFileReader audioFile;
        private void pbtModify_Click(object sender, EventArgs e)
        {
            if (!File.Exists(audioTrack.FilePath))
            {
                this.DialogResult = DialogResult.Cancel;
                PoisonMessageBox.Show(this, "Percorso file della traccia originale non valido");
                this.Close();
            }
            TrackMetaData.AudioTrack a;
            //Parsare il volume multiplier e interpretare , o . in modo corretto
            if (!float.TryParse(
                    ptxVolumeMultiplier.Text,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out float parsedVolume))
            {
                PoisonMessageBox.Show(this, "Volume Multiplier dev'essere un numero");
                return;
            }

            a.VolumeMultiplier = (float)MathHelper.Clamp(parsedVolume, 0f, 1f);


            //Assegnazione immagine
            if (ptxAlbumFilePath.Text == AppDefaults.DefaultAudioTrackAlbumArtMessage)
                a.AlbumArt = audioTrack.AlbumArt;

            if (string.IsNullOrEmpty(ptxAlbumFilePath.Text) || !File.Exists(ptxAlbumFilePath.Text))
                a.AlbumArt = AppDefaults.NullImage;
            else
                a.AlbumArt = Image.FromFile(ptxAlbumFilePath.Text);

            //Inserimento titolo autore e album
            if (string.IsNullOrEmpty(ptxTitolo.Text.Trim()))
                a.Title = audioTrack.FilePath;
            else
                a.Title = ptxTitolo.Text.Trim();

            if (string.IsNullOrEmpty(ptxAutore.Text.Trim()))
                a.Artist = AppDefaults.AudioTrackArtistNotAvailable;
            else
                a.Artist = ptxAutore.Text.Trim();

            if (string.IsNullOrEmpty(ptxAlbum.Text.Trim()))
                a.Album = AppDefaults.AudioTrackAlbumNotAvailable;
            else
                a.Album = ptxAlbum.Text.Trim();

            a.Duration = audioTrack.Duration;
            a.FilePath = audioTrack.FilePath;

            DialogResult result = PoisonMessageBox.Show(
                this,
                "\nSei sicuro di voler apportare le seguenti modifiche alla traccia audio?\n\n" +

                $"FilePath: {audioTrack.FilePath}\n" +
                $"{"",-18}--> {a.FilePath}\n\n" +

                $"Titolo: {audioTrack.Title}\n" +
                $"{"",-18}--> {a.Title}\n\n" +

                $"Autore: {audioTrack.Artist}\n" +
                $"{"",-18}--> {a.Artist}\n\n" +

                $"Album: {audioTrack.Album}\n" +
                $"{"",-18}--> {a.Album}\n\n" +

                $"AlbumArt: (vecchia)\n" +
                $"{"",-18}--> {ptxAlbumFilePath.Text}\n\n" +

                $"VolumeMultiplier: {audioTrack.VolumeMultiplier}\n" +
                $"{"",-18}--> {a.VolumeMultiplier}\n\n" +

                $"Durata: {TrackMetaData.FormatTrackTime((int)audioTrack.Duration.TotalSeconds)}\n" +
                $"{"",-18}--> {TrackMetaData.FormatTrackTime((int)a.Duration.TotalSeconds)}",
                "Modify Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                600
                );

            if (result != DialogResult.Yes)
                return;

            audioTrack = a;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Funzione locale che mostra le informazioni riguardanti l'audio della form
        /// </summary>
        private void displayAudioTrackInfo()
        {

            ptxTitolo.Text = audioTrack.Title;
            ptxAutore.Text = audioTrack.Artist;
            ptxAlbum.Text = audioTrack.Album;
            ptxAlbumFilePath.Text = AppDefaults.DefaultAudioTrackAlbumArtMessage;
            UIHelper.ShowImageInPictureBox(picAudioAlbumArt, audioTrack.AlbumArt);
            plbDurata.Text = TrackMetaData.FormatTrackTime((int)audioTrack.Duration.TotalSeconds);
            ptxVolumeMultiplier.Text = audioFile.Volume.ToString();
        }

        private void pbtBrowseAudio_Click(object sender, EventArgs e)
        {
            //Select File
            OpenFileDialog openFileManager = new OpenFileDialog();
            openFileManager.Filter = "File JPEG|*.jpg|File PNG|*.png";
            openFileManager.Title = "Seleziona una copertina";

            if (openFileManager.ShowDialog() == DialogResult.OK)
            {
                ptxAlbumFilePath.Text = openFileManager.FileName;
            }
        }

        private void pbtResetAll_Click(object sender, EventArgs e)
        {
            DialogResult result = PoisonMessageBox.Show(
                this,
                $"Sei sicuro di voler resettare i tags relativi a questa Audio Track?"
                ,
                "Reset Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
                );

            if (result != DialogResult.Yes)
                return;
            displayAudioTrackInfo();
        }

        private void pbtShowAlbumArt_Click(object sender, EventArgs e)
        {
            //Assegnazione immagine
            if (string.IsNullOrEmpty(ptxAlbumFilePath.Text) || !File.Exists(ptxAlbumFilePath.Text))
                picAudioAlbumArt.Image = AppDefaults.NullImage;
            else
                picAudioAlbumArt.Image = Image.FromFile(ptxAlbumFilePath.Text);
        }
    }
}
