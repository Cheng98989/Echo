using System.Drawing;

namespace Echo
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pcbPlaybackMode = new ReaLTaiizor.Controls.PoisonComboBox();
            this.plbSelectedAudioPositionTime = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonPanel1 = new ReaLTaiizor.Controls.PoisonPanel();
            this.plbSelectedAudioArtist = new ReaLTaiizor.Controls.PoisonLabel();
            this.picSelectedAudioAlbumArt = new System.Windows.Forms.PictureBox();
            this.plbSelectedAudioTitle = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbSelectedAudioPositionTrackTime = new ReaLTaiizor.Controls.PoisonLabel();
            this.ptlSelectedAudioVolumePct = new ReaLTaiizor.Controls.PoisonTile();
            this.psbSelectedAudioVolume = new ReaLTaiizor.Controls.PoisonScrollBar();
            this.ptbSelectedAudioPosition = new ReaLTaiizor.Controls.PoisonTrackBar();
            this.pbtBrowseAddAudio = new ReaLTaiizor.Controls.PoisonButton();
            this.plvPlaylist = new ReaLTaiizor.Controls.PoisonListView();
            this.colAudioTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAudioArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAudioDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pcmDeleteAudio = new ReaLTaiizor.Controls.PoisonContextMenuStrip(this.components);
            this.tspDeleteAudioAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSelectedAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSelectedAudioDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tspSelectedAudioModify = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsiPlaylistSave = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptxPlaylistName = new ReaLTaiizor.Controls.PoisonTextBox();
            this.audioPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.ptlSelectedAudioPlay = new ReaLTaiizor.Controls.PoisonTile();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbPlayingAudioName = new ReaLTaiizor.Controls.PoisonLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picPlayIcon = new System.Windows.Forms.PictureBox();
            this.picPauseIcon = new System.Windows.Forms.PictureBox();
            this.poisonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedAudioAlbumArt)).BeginInit();
            this.pcmDeleteAudio.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPauseIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbPlaybackMode
            // 
            this.pcbPlaybackMode.DropDownHeight = 100;
            this.pcbPlaybackMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pcbPlaybackMode.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
            this.pcbPlaybackMode.FormattingEnabled = true;
            this.pcbPlaybackMode.IntegralHeight = false;
            this.pcbPlaybackMode.ItemHeight = 19;
            this.pcbPlaybackMode.Location = new System.Drawing.Point(616, 496);
            this.pcbPlaybackMode.Name = "pcbPlaybackMode";
            this.pcbPlaybackMode.Size = new System.Drawing.Size(105, 25);
            this.pcbPlaybackMode.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pcbPlaybackMode.TabIndex = 20;
            this.pcbPlaybackMode.UseSelectable = true;
            this.pcbPlaybackMode.UseStyleColors = true;
            // 
            // plbSelectedAudioPositionTime
            // 
            this.plbSelectedAudioPositionTime.AutoSize = true;
            this.plbSelectedAudioPositionTime.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioPositionTime.Location = new System.Drawing.Point(416, 528);
            this.plbSelectedAudioPositionTime.Name = "plbSelectedAudioPositionTime";
            this.plbSelectedAudioPositionTime.Size = new System.Drawing.Size(84, 19);
            this.plbSelectedAudioPositionTime.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbSelectedAudioPositionTime.TabIndex = 19;
            this.plbSelectedAudioPositionTime.Text = "00:00 / 02:00";
            this.plbSelectedAudioPositionTime.UseCustomBackColor = true;
            // 
            // poisonPanel1
            // 
            this.poisonPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioArtist);
            this.poisonPanel1.Controls.Add(this.picSelectedAudioAlbumArt);
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioTitle);
            this.poisonPanel1.HorizontalScrollbarBarColor = true;
            this.poisonPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.HorizontalScrollbarSize = 10;
            this.poisonPanel1.Location = new System.Drawing.Point(408, 96);
            this.poisonPanel1.Name = "poisonPanel1";
            this.poisonPanel1.Size = new System.Drawing.Size(312, 360);
            this.poisonPanel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonPanel1.TabIndex = 19;
            this.poisonPanel1.UseCustomBackColor = true;
            this.poisonPanel1.VerticalScrollbarBarColor = false;
            this.poisonPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.VerticalScrollbarSize = 10;
            // 
            // plbSelectedAudioArtist
            // 
            this.plbSelectedAudioArtist.AutoSize = true;
            this.plbSelectedAudioArtist.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioArtist.Location = new System.Drawing.Point(24, 328);
            this.plbSelectedAudioArtist.Name = "plbSelectedAudioArtist";
            this.plbSelectedAudioArtist.Size = new System.Drawing.Size(49, 19);
            this.plbSelectedAudioArtist.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbSelectedAudioArtist.TabIndex = 17;
            this.plbSelectedAudioArtist.Text = "Autore";
            this.plbSelectedAudioArtist.UseCustomBackColor = true;
            // 
            // picSelectedAudioAlbumArt
            // 
            this.picSelectedAudioAlbumArt.Cursor = System.Windows.Forms.Cursors.Default;
            this.picSelectedAudioAlbumArt.InitialImage = global::Echo.Properties.Resources.AlbumArtNotAvailable;
            this.picSelectedAudioAlbumArt.Location = new System.Drawing.Point(16, 16);
            this.picSelectedAudioAlbumArt.Name = "picSelectedAudioAlbumArt";
            this.picSelectedAudioAlbumArt.Size = new System.Drawing.Size(280, 280);
            this.picSelectedAudioAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectedAudioAlbumArt.TabIndex = 2;
            this.picSelectedAudioAlbumArt.TabStop = false;
            // 
            // plbSelectedAudioTitle
            // 
            this.plbSelectedAudioTitle.AutoSize = true;
            this.plbSelectedAudioTitle.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioTitle.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.plbSelectedAudioTitle.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            this.plbSelectedAudioTitle.Location = new System.Drawing.Point(24, 296);
            this.plbSelectedAudioTitle.Name = "plbSelectedAudioTitle";
            this.plbSelectedAudioTitle.Size = new System.Drawing.Size(57, 25);
            this.plbSelectedAudioTitle.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbSelectedAudioTitle.TabIndex = 15;
            this.plbSelectedAudioTitle.Text = "Titolo";
            this.plbSelectedAudioTitle.UseCustomBackColor = true;
            // 
            // plbSelectedAudioPositionTrackTime
            // 
            this.plbSelectedAudioPositionTrackTime.AutoSize = true;
            this.plbSelectedAudioPositionTrackTime.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioPositionTrackTime.Location = new System.Drawing.Point(536, 544);
            this.plbSelectedAudioPositionTrackTime.Name = "plbSelectedAudioPositionTrackTime";
            this.plbSelectedAudioPositionTrackTime.Size = new System.Drawing.Size(40, 19);
            this.plbSelectedAudioPositionTrackTime.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbSelectedAudioPositionTrackTime.TabIndex = 18;
            this.plbSelectedAudioPositionTrackTime.Text = "00:00";
            this.plbSelectedAudioPositionTrackTime.UseCustomBackColor = true;
            this.plbSelectedAudioPositionTrackTime.Visible = false;
            // 
            // ptlSelectedAudioVolumePct
            // 
            this.ptlSelectedAudioVolumePct.ActiveControl = null;
            this.ptlSelectedAudioVolumePct.Enabled = false;
            this.ptlSelectedAudioVolumePct.Location = new System.Drawing.Point(736, 640);
            this.ptlSelectedAudioVolumePct.Name = "ptlSelectedAudioVolumePct";
            this.ptlSelectedAudioVolumePct.Size = new System.Drawing.Size(48, 40);
            this.ptlSelectedAudioVolumePct.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.ptlSelectedAudioVolumePct.TabIndex = 8;
            this.ptlSelectedAudioVolumePct.Text = "100%";
            this.ptlSelectedAudioVolumePct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioVolumePct.TileTextFontSize = ReaLTaiizor.Extension.Poison.PoisonTileTextSize.Small;
            this.ptlSelectedAudioVolumePct.TileTextFontWeight = ReaLTaiizor.Extension.Poison.PoisonTileTextWeight.Regular;
            this.ptlSelectedAudioVolumePct.UseCustomForeColor = true;
            this.ptlSelectedAudioVolumePct.UseSelectable = true;
            // 
            // psbSelectedAudioVolume
            // 
            this.psbSelectedAudioVolume.LargeChange = 4;
            this.psbSelectedAudioVolume.Location = new System.Drawing.Point(736, 96);
            this.psbSelectedAudioVolume.Maximum = 100;
            this.psbSelectedAudioVolume.Minimum = 0;
            this.psbSelectedAudioVolume.MouseWheelBarPartitions = 100;
            this.psbSelectedAudioVolume.Name = "psbSelectedAudioVolume";
            this.psbSelectedAudioVolume.Orientation = ReaLTaiizor.Enum.Poison.ScrollOrientationType.Vertical;
            this.psbSelectedAudioVolume.ScrollbarSize = 50;
            this.psbSelectedAudioVolume.Size = new System.Drawing.Size(50, 528);
            this.psbSelectedAudioVolume.TabIndex = 7;
            this.psbSelectedAudioVolume.UseBarColor = true;
            this.psbSelectedAudioVolume.UseSelectable = true;
            this.psbSelectedAudioVolume.Scroll += new System.Windows.Forms.ScrollEventHandler(this.psbSelectedAudioVolume_Scroll);
            // 
            // ptbSelectedAudioPosition
            // 
            this.ptbSelectedAudioPosition.BackColor = System.Drawing.Color.Transparent;
            this.ptbSelectedAudioPosition.Location = new System.Drawing.Point(424, 568);
            this.ptbSelectedAudioPosition.Name = "ptbSelectedAudioPosition";
            this.ptbSelectedAudioPosition.Size = new System.Drawing.Size(280, 16);
            this.ptbSelectedAudioPosition.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.ptbSelectedAudioPosition.TabIndex = 3;
            this.ptbSelectedAudioPosition.Text = "poisonTrackBar1";
            this.ptbSelectedAudioPosition.UseCustomBackColor = true;
            this.ptbSelectedAudioPosition.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ptbSelectedAudioPosition_Scroll);
            this.ptbSelectedAudioPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbSelectedAudioPosition_MouseDown);
            this.ptbSelectedAudioPosition.MouseLeave += new System.EventHandler(this.ptbSelectedAudioPosition_MouseLeave);
            this.ptbSelectedAudioPosition.MouseHover += new System.EventHandler(this.ptbSelectedAudioPosition_MouseHover);
            this.ptbSelectedAudioPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbSelectedAudioPosition_MouseUp);
            // 
            // pbtBrowseAddAudio
            // 
            this.pbtBrowseAddAudio.Location = new System.Drawing.Point(24, 128);
            this.pbtBrowseAddAudio.Name = "pbtBrowseAddAudio";
            this.pbtBrowseAddAudio.Size = new System.Drawing.Size(368, 32);
            this.pbtBrowseAddAudio.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pbtBrowseAddAudio.TabIndex = 9;
            this.pbtBrowseAddAudio.Text = "AGGIUNGI TRACCIA";
            this.pbtBrowseAddAudio.UseCustomBackColor = true;
            this.pbtBrowseAddAudio.UseSelectable = true;
            this.pbtBrowseAddAudio.UseStyleColors = true;
            this.pbtBrowseAddAudio.Click += new System.EventHandler(this.pbtBrowseAddAudio_Click);
            // 
            // plvPlaylist
            // 
            this.plvPlaylist.BackgroundImageTiled = true;
            this.plvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAudioTitle,
            this.colAudioArtist,
            this.colAudioDuration});
            this.plvPlaylist.ContextMenuStrip = this.pcmDeleteAudio;
            this.plvPlaylist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.plvPlaylist.FullRowSelect = true;
            this.plvPlaylist.GridLines = true;
            this.plvPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.plvPlaylist.Location = new System.Drawing.Point(24, 167);
            this.plvPlaylist.MultiSelect = false;
            this.plvPlaylist.Name = "plvPlaylist";
            this.plvPlaylist.OwnerDraw = true;
            this.plvPlaylist.Size = new System.Drawing.Size(368, 513);
            this.plvPlaylist.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plvPlaylist.TabIndex = 4;
            this.plvPlaylist.UseCompatibleStateImageBehavior = false;
            this.plvPlaylist.UseSelectable = true;
            this.plvPlaylist.View = System.Windows.Forms.View.Details;
            this.plvPlaylist.SelectedIndexChanged += new System.EventHandler(this.plvPlaylist_SelectedIndexChanged);
            // 
            // colAudioTitle
            // 
            this.colAudioTitle.Text = "Titolo";
            this.colAudioTitle.Width = 200;
            // 
            // colAudioArtist
            // 
            this.colAudioArtist.Text = "Artista";
            this.colAudioArtist.Width = 80;
            // 
            // colAudioDuration
            // 
            this.colAudioDuration.Text = "Durata";
            // 
            // pcmDeleteAudio
            // 
            this.pcmDeleteAudio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspDeleteAudioAll,
            this.tspSelectedAudio});
            this.pcmDeleteAudio.Name = "pcmDeleteAudio";
            this.pcmDeleteAudio.Size = new System.Drawing.Size(170, 48);
            // 
            // tspDeleteAudioAll
            // 
            this.tspDeleteAudioAll.Name = "tspDeleteAudioAll";
            this.tspDeleteAudioAll.Size = new System.Drawing.Size(169, 22);
            this.tspDeleteAudioAll.Text = "Svuota Playlist";
            this.tspDeleteAudioAll.Click += new System.EventHandler(this.tspDeleteAudioAll_Click);
            // 
            // tspSelectedAudio
            // 
            this.tspSelectedAudio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSelectedAudioDelete,
            this.tspSelectedAudioModify});
            this.tspSelectedAudio.Name = "tspSelectedAudio";
            this.tspSelectedAudio.Size = new System.Drawing.Size(169, 22);
            this.tspSelectedAudio.Text = "Audio Selezionato";
            // 
            // tspSelectedAudioDelete
            // 
            this.tspSelectedAudioDelete.Name = "tspSelectedAudioDelete";
            this.tspSelectedAudioDelete.Size = new System.Drawing.Size(121, 22);
            this.tspSelectedAudioDelete.Text = "Elimina";
            this.tspSelectedAudioDelete.Click += new System.EventHandler(this.tspSelectedAudioDelete_Click);
            // 
            // tspSelectedAudioModify
            // 
            this.tspSelectedAudioModify.Name = "tspSelectedAudioModify";
            this.tspSelectedAudioModify.Size = new System.Drawing.Size(121, 22);
            this.tspSelectedAudioModify.Text = "Modifica";
            this.tspSelectedAudioModify.Click += new System.EventHandler(this.tspSelectedAudioModify_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiPlaylistSave,
            this.opzioniToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(20, 60);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(760, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsiPlaylistSave
            // 
            this.tsiPlaylistSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvaToolStripMenuItem,
            this.caricaToolStripMenuItem,
            this.playlistsToolStripMenuItem});
            this.tsiPlaylistSave.Name = "tsiPlaylistSave";
            this.tsiPlaylistSave.Size = new System.Drawing.Size(56, 20);
            this.tsiPlaylistSave.Text = "Playlist";
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // caricaToolStripMenuItem
            // 
            this.caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            this.caricaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.caricaToolStripMenuItem.Text = "Carica";
            this.caricaToolStripMenuItem.Click += new System.EventHandler(this.caricaToolStripMenuItem_Click);
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.playlistsToolStripMenuItem.Text = "Cartella Playlists";
            this.playlistsToolStripMenuItem.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaToolStripMenuItem});
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.opzioniToolStripMenuItem.Text = "Impostazioni";
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // ptxPlaylistName
            // 
            // 
            // 
            // 
            this.ptxPlaylistName.CustomButton.Image = null;
            this.ptxPlaylistName.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.ptxPlaylistName.CustomButton.Name = "";
            this.ptxPlaylistName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxPlaylistName.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxPlaylistName.CustomButton.TabIndex = 1;
            this.ptxPlaylistName.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxPlaylistName.CustomButton.UseSelectable = true;
            this.ptxPlaylistName.CustomButton.Visible = false;
            this.ptxPlaylistName.Lines = new string[0];
            this.ptxPlaylistName.Location = new System.Drawing.Point(104, 96);
            this.ptxPlaylistName.MaxLength = 32767;
            this.ptxPlaylistName.Name = "ptxPlaylistName";
            this.ptxPlaylistName.PasswordChar = '\0';
            this.ptxPlaylistName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxPlaylistName.SelectedText = "";
            this.ptxPlaylistName.SelectionLength = 0;
            this.ptxPlaylistName.SelectionStart = 0;
            this.ptxPlaylistName.ShortcutsEnabled = true;
            this.ptxPlaylistName.Size = new System.Drawing.Size(288, 23);
            this.ptxPlaylistName.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.ptxPlaylistName.TabIndex = 12;
            this.ptxPlaylistName.UseSelectable = true;
            this.ptxPlaylistName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxPlaylistName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // audioPositionTimer
            // 
            this.audioPositionTimer.Interval = 1000;
            this.audioPositionTimer.Tick += new System.EventHandler(this.audioPositionTimer_Tick);
            // 
            // ptlSelectedAudioPlay
            // 
            this.ptlSelectedAudioPlay.ActiveControl = null;
            this.ptlSelectedAudioPlay.BackColor = System.Drawing.Color.Transparent;
            this.ptlSelectedAudioPlay.DisplayFocusBorder = false;
            this.ptlSelectedAudioPlay.Location = new System.Drawing.Point(512, 584);
            this.ptlSelectedAudioPlay.Name = "ptlSelectedAudioPlay";
            this.ptlSelectedAudioPlay.Size = new System.Drawing.Size(96, 96);
            this.ptlSelectedAudioPlay.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.ptlSelectedAudioPlay.TabIndex = 50;
            this.ptlSelectedAudioPlay.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioPlay.UseCustomBackColor = true;
            this.ptlSelectedAudioPlay.UseSelectable = true;
            this.ptlSelectedAudioPlay.UseTileImage = true;
            this.ptlSelectedAudioPlay.Click += new System.EventHandler(this.ptlSelectedAudioPlay_Click);
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel1.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            this.poisonLabel1.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            this.poisonLabel1.Location = new System.Drawing.Point(24, 96);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(78, 25);
            this.poisonLabel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel1.TabIndex = 21;
            this.poisonLabel1.Text = "Playlist:";
            this.poisonLabel1.UseCustomBackColor = true;
            this.poisonLabel1.UseStyleColors = true;
            // 
            // plbPlayingAudioName
            // 
            this.plbPlayingAudioName.BackColor = System.Drawing.Color.Transparent;
            this.plbPlayingAudioName.Location = new System.Drawing.Point(408, 464);
            this.plbPlayingAudioName.Name = "plbPlayingAudioName";
            this.plbPlayingAudioName.Size = new System.Drawing.Size(312, 24);
            this.plbPlayingAudioName.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbPlayingAudioName.TabIndex = 22;
            this.plbPlayingAudioName.Text = "Titolo";
            this.plbPlayingAudioName.UseCustomBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.InitialImage = global::Echo.Properties.Resources.AlbumArtNotAvailable;
            this.pictureBox2.Location = new System.Drawing.Point(416, 592);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // picPlayIcon
            // 
            this.picPlayIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.picPlayIcon.Enabled = false;
            this.picPlayIcon.Image = global::Echo.Properties.Resources.PlayAudio;
            this.picPlayIcon.InitialImage = global::Echo.Properties.Resources.PlayAudio;
            this.picPlayIcon.Location = new System.Drawing.Point(520, 592);
            this.picPlayIcon.Name = "picPlayIcon";
            this.picPlayIcon.Size = new System.Drawing.Size(80, 80);
            this.picPlayIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPlayIcon.TabIndex = 23;
            this.picPlayIcon.TabStop = false;
            // 
            // picPauseIcon
            // 
            this.picPauseIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.picPauseIcon.Enabled = false;
            this.picPauseIcon.Image = global::Echo.Properties.Resources.PauseAudio;
            this.picPauseIcon.InitialImage = global::Echo.Properties.Resources.PauseAudio;
            this.picPauseIcon.Location = new System.Drawing.Point(520, 592);
            this.picPauseIcon.Name = "picPauseIcon";
            this.picPauseIcon.Size = new System.Drawing.Size(80, 80);
            this.picPauseIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPauseIcon.TabIndex = 24;
            this.picPauseIcon.TabStop = false;
            this.picPauseIcon.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.picPauseIcon);
            this.Controls.Add(this.picPlayIcon);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.plbPlayingAudioName);
            this.Controls.Add(this.poisonLabel1);
            this.Controls.Add(this.ptxPlaylistName);
            this.Controls.Add(this.pcbPlaybackMode);
            this.Controls.Add(this.plbSelectedAudioPositionTime);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.poisonPanel1);
            this.Controls.Add(this.pbtBrowseAddAudio);
            this.Controls.Add(this.plbSelectedAudioPositionTrackTime);
            this.Controls.Add(this.plvPlaylist);
            this.Controls.Add(this.ptlSelectedAudioVolumePct);
            this.Controls.Add(this.psbSelectedAudioVolume);
            this.Controls.Add(this.ptbSelectedAudioPosition);
            this.Controls.Add(this.ptlSelectedAudioPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "MainForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.Text = "Echo";
            this.poisonPanel1.ResumeLayout(false);
            this.poisonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedAudioAlbumArt)).EndInit();
            this.pcmDeleteAudio.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPauseIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.PoisonListView plvPlaylist;
        private ReaLTaiizor.Controls.PoisonTrackBar ptbSelectedAudioPosition;
        private System.Windows.Forms.PictureBox picSelectedAudioAlbumArt;
        private ReaLTaiizor.Controls.PoisonScrollBar psbSelectedAudioVolume;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioVolumePct;
        private ReaLTaiizor.Controls.PoisonButton pbtBrowseAddAudio;
        private System.Windows.Forms.ColumnHeader colAudioArtist;
        private System.Windows.Forms.ColumnHeader colAudioDuration;
        private System.Windows.Forms.ColumnHeader colAudioTitle;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioPlay;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioArtist;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioTitle;
        private ReaLTaiizor.Controls.PoisonPanel poisonPanel1;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioPositionTrackTime;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioPositionTime;
        private System.Windows.Forms.MenuStrip menuStrip;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip pcmDeleteAudio;
        private System.Windows.Forms.ToolStripMenuItem tspDeleteAudioAll;
        private System.Windows.Forms.ToolStripMenuItem tspSelectedAudio;
        private System.Windows.Forms.ToolStripMenuItem tspSelectedAudioDelete;
        private System.Windows.Forms.ToolStripMenuItem tspSelectedAudioModify;
        private System.Windows.Forms.ToolStripMenuItem tsiPlaylistSave;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private ReaLTaiizor.Controls.PoisonTextBox ptxPlaylistName;
        private System.Windows.Forms.ToolStripMenuItem caricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.Timer audioPositionTimer;
        private ReaLTaiizor.Controls.PoisonComboBox pcbPlaybackMode;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonLabel plbPlayingAudioName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picPlayIcon;
        private System.Windows.Forms.PictureBox picPauseIcon;
    }
}

