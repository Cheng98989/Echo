using Echo.Helpers;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echo.Forms
{
    public partial class SettingsForm : PoisonForm
    {
        public AppSettings.UserSettings userSettings { get; private set; }

        public SettingsForm(AppSettings.UserSettings userSettings)
        {
            InitializeComponent();
            this.userSettings = userSettings;
            DisplayUserSettings(userSettings);
        }

        private void DisplayUserSettings(AppSettings.UserSettings settings)
        {
            ptxEchOnLoad.Text = settings.EchOnLoad;
            ptxBrowseAudioTracksInitialDirectory.Text = settings.BrowseAudioTracksInitialDirectory;
            ptxAudioTrackSavePath.Text = settings.BrowsePlaylistsInitialDirectory;
            pcbDeleteOriginalAudioTrack.Checked = settings.DeleteOriginalAudioTrack;
            pcbDefaultPlaybackMode.Items.Clear();
            pcbDefaultPlaybackMode.Items.AddRange(Enum.GetNames(typeof(Playback.PlaybackMode)));
            pcbDefaultPlaybackMode.SelectedItem = settings.DefaultPlaybackMode.ToString();
            ptxDefaultVolumeMultiplier.Text = settings.DefaultVolumeMultiplier.ToString(CultureInfo.InvariantCulture);
            ptxSubstituteToSpaceInDirectoryOrFileName.Text = settings.SubstituteToSpaceInDirectoryOrFileName.ToString();
            ptxAudioTrackArtistNotAvailable.Text = settings.AudioTrackArtistNotAvailable;
            ptxAudioTrackAlbumNotAvailable.Text = settings.AudioTrackAlbumNotAvailable;
            ptxConfirmationStringLength.Text = settings.ConfirmationStringLength.ToString();
        }

        private void pbtBrowseAudioTracksInitialDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Seleziona la directory iniziale per i brani audio";
            folderBrowser.SelectedPath = userSettings.BrowseAudioTracksInitialDirectory;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                ptxBrowseAudioTracksInitialDirectory.Text = folderBrowser.SelectedPath;
            }
        }

        private void pbtAudioTrackSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Seleziona la directory di salvataggio per i brani audio";
            folderBrowser.SelectedPath = userSettings.BrowsePlaylistsInitialDirectory;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                ptxAudioTrackSavePath.Text = folderBrowser.SelectedPath;
            }
        }

        private void pbtSave_Click(object sender, EventArgs e)
        {
            AppSettings.UserSettings tmp = userSettings;

            if (string.IsNullOrWhiteSpace(ptxBrowseAudioTracksInitialDirectory.Text) || string.IsNullOrWhiteSpace(ptxAudioTrackSavePath.Text))
            {
                PoisonMessageBox.Show(
                    this,
                    "Entrambi i percorsi devono essere validi e non vuoti.",
                    "Errore di validazione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!System.IO.Directory.Exists(ptxBrowseAudioTracksInitialDirectory.Text))
            {
                PoisonMessageBox.Show(
                    this,
                    "La directory iniziale per i brani audio specificata non esiste. Verifica il percorso e riprova.",
                    "Errore di validazione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (!System.IO.Directory.Exists(ptxAudioTrackSavePath.Text))
            {
                PoisonMessageBox.Show(
                    this,
                    "La directory di salvataggio per le playlist specificata non esiste. Verifica il percorso e riprova.",
                    "Errore di validazione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!float.TryParse(
                    ptxDefaultVolumeMultiplier.Text,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out float parsedVolume))
            {
                PoisonMessageBox.Show(
                    this,
                    "Il campo Default Volume Multiplier deve contenere un valore numerico valido.",
                    "Valore non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            if (ptxSubstituteToSpaceInDirectoryOrFileName.Text.Length > 1)
            {
                PoisonMessageBox.Show(
                    this,
                    "Il campo Substitute To Space In Directory Or File Name deve contenere massimo un carattere.",
                    "Valore non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            if (ptxAudioTrackAlbumNotAvailable.Text.Length > 20)
            {
                PoisonMessageBox.Show(
                    this,
                    "Il campo Audio Track Album Not Available deve contenere massimo 20 caratteri.",
                    "Valore non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            if (ptxAudioTrackArtistNotAvailable.Text.Length > 20)
            {
                PoisonMessageBox.Show(
                    this,
                    "Il campo Audio Track Artist Not Available deve contenere massimo 20 caratteri.",
                    "Valore non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            if (!int.TryParse(ptxConfirmationStringLength.Text, out int parsedConfirmationStringLength) || parsedConfirmationStringLength < 0)
            {
                PoisonMessageBox.Show(
                    this,
                    "Il campo Confirmation String Length deve contenere un numero intero positivo.",
                    "Valore non valido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            tmp.EchOnLoad = ptxEchOnLoad.Text;
            tmp.DeleteOriginalAudioTrack = pcbDeleteOriginalAudioTrack.Checked;
            tmp.DefaultPlaybackMode = (Playback.PlaybackMode)Enum.Parse(typeof(Playback.PlaybackMode), pcbDefaultPlaybackMode.SelectedItem.ToString());
            tmp.DefaultVolumeMultiplier = parsedVolume;
            tmp.SubstituteToSpaceInDirectoryOrFileName = ptxSubstituteToSpaceInDirectoryOrFileName.Text.Length > 0 ? ptxSubstituteToSpaceInDirectoryOrFileName.Text[0] : ' ';
            tmp.AudioTrackArtistNotAvailable = ptxAudioTrackArtistNotAvailable.Text;
            tmp.AudioTrackAlbumNotAvailable = ptxAudioTrackAlbumNotAvailable.Text;
            tmp.ConfirmationStringLength = parsedConfirmationStringLength;

            tmp.BrowseAudioTracksInitialDirectory = ptxBrowseAudioTracksInitialDirectory.Text;
            tmp.BrowsePlaylistsInitialDirectory = ptxAudioTrackSavePath.Text;

            DialogResult dialogResult = PoisonMessageBox.Show(
                this,
                "Sei sicuro di voler salvare le modifiche alle impostazioni?",
                "Conferma salvataggio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.Yes)
            {
                userSettings = tmp;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pbtResetAll_Click(object sender, EventArgs e)
        {
            DisplayUserSettings(userSettings);
        }

        private void pbtResetToDefault_Click(object sender, EventArgs e)
        {
            AppSettings.UserSettings defaultSettings = AppDefaults.defaultUserSettings;
            DisplayUserSettings(defaultSettings);
        }

        private void pbtBrowseEchOnLoad_Click(object sender, EventArgs e)
        {
            // Selezione file ech
            OpenFileDialog openFileManager = new OpenFileDialog();
            openFileManager.Filter = "File Echo|*.ech";
            openFileManager.Title = "Seleziona una playlist";
            if (!Directory.Exists(userSettings.BrowsePlaylistsInitialDirectory))
                Directory.CreateDirectory(userSettings.BrowsePlaylistsInitialDirectory);
            openFileManager.InitialDirectory = Path.GetFullPath(userSettings.BrowsePlaylistsInitialDirectory);

            if (openFileManager.ShowDialog() == DialogResult.OK)
            {
                ptxEchOnLoad.Text = openFileManager.FileName;
            }
                
        }

        private void pbtResetEch_Click(object sender, EventArgs e)
        {
            ptxEchOnLoad.Text = "";
        }
    }
}
