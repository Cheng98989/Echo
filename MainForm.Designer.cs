using System.Drawing;

namespace SoundDeck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.poisonTabControl1 = new ReaLTaiizor.Controls.PoisonTabControl();
            this.poisonTabPage1 = new ReaLTaiizor.Controls.PoisonTabPage();
            this.poisonPanel1 = new ReaLTaiizor.Controls.PoisonPanel();
            this.plbSelectedAudioPositionTime = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbSelectedAudioPositionTrackTime = new ReaLTaiizor.Controls.PoisonLabel();
            this.ptlSelectedAudioStop = new ReaLTaiizor.Controls.PoisonTile();
            this.plbSelectedAudioArtist = new ReaLTaiizor.Controls.PoisonLabel();
            this.ptlSelectedAudioPause = new ReaLTaiizor.Controls.PoisonTile();
            this.ptbSelectedAudioPosition = new ReaLTaiizor.Controls.PoisonTrackBar();
            this.ptlSelectedAudioPlay = new ReaLTaiizor.Controls.PoisonTile();
            this.picSelectedAudioAlbumArt = new System.Windows.Forms.PictureBox();
            this.plbSelectedAudioTitle = new ReaLTaiizor.Controls.PoisonLabel();
            this.pbtAddAudio = new ReaLTaiizor.Controls.PoisonButton();
            this.ptxAudioFilePath = new ReaLTaiizor.Controls.PoisonTextBox();
            this.pbtBrowseAudio = new ReaLTaiizor.Controls.PoisonButton();
            this.ptlSelectedAudioVolumePct = new ReaLTaiizor.Controls.PoisonTile();
            this.psbSelectedAudioVolume = new ReaLTaiizor.Controls.PoisonScrollBar();
            this.plvPlaylist = new ReaLTaiizor.Controls.PoisonListView();
            this.colAudioTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAudioArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAudioDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.poisonTabPage2 = new ReaLTaiizor.Controls.PoisonTabPage();
            this.poisonTabControl1.SuspendLayout();
            this.poisonTabPage1.SuspendLayout();
            this.poisonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedAudioAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // poisonTabControl1
            // 
            this.poisonTabControl1.Controls.Add(this.poisonTabPage1);
            this.poisonTabControl1.Controls.Add(this.poisonTabPage2);
            this.poisonTabControl1.Location = new System.Drawing.Point(8, 48);
            this.poisonTabControl1.Name = "poisonTabControl1";
            this.poisonTabControl1.SelectedIndex = 0;
            this.poisonTabControl1.Size = new System.Drawing.Size(784, 544);
            this.poisonTabControl1.TabIndex = 2;
            this.poisonTabControl1.UseSelectable = true;
            // 
            // poisonTabPage1
            // 
            this.poisonTabPage1.Controls.Add(this.poisonPanel1);
            this.poisonTabPage1.Controls.Add(this.pbtAddAudio);
            this.poisonTabPage1.Controls.Add(this.ptxAudioFilePath);
            this.poisonTabPage1.Controls.Add(this.pbtBrowseAudio);
            this.poisonTabPage1.Controls.Add(this.ptlSelectedAudioVolumePct);
            this.poisonTabPage1.Controls.Add(this.psbSelectedAudioVolume);
            this.poisonTabPage1.Controls.Add(this.plvPlaylist);
            this.poisonTabPage1.HorizontalScrollbarBarColor = true;
            this.poisonTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.poisonTabPage1.HorizontalScrollbarSize = 10;
            this.poisonTabPage1.Location = new System.Drawing.Point(4, 38);
            this.poisonTabPage1.Name = "poisonTabPage1";
            this.poisonTabPage1.Size = new System.Drawing.Size(776, 502);
            this.poisonTabPage1.TabIndex = 0;
            this.poisonTabPage1.Text = "poisonTabPage1";
            this.poisonTabPage1.VerticalScrollbarBarColor = true;
            this.poisonTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.poisonTabPage1.VerticalScrollbarSize = 10;
            // 
            // poisonPanel1
            // 
            this.poisonPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioPositionTime);
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioPositionTrackTime);
            this.poisonPanel1.Controls.Add(this.ptlSelectedAudioStop);
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioArtist);
            this.poisonPanel1.Controls.Add(this.ptlSelectedAudioPause);
            this.poisonPanel1.Controls.Add(this.ptbSelectedAudioPosition);
            this.poisonPanel1.Controls.Add(this.ptlSelectedAudioPlay);
            this.poisonPanel1.Controls.Add(this.picSelectedAudioAlbumArt);
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioTitle);
            this.poisonPanel1.HorizontalScrollbarBarColor = true;
            this.poisonPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.HorizontalScrollbarSize = 10;
            this.poisonPanel1.Location = new System.Drawing.Point(368, 8);
            this.poisonPanel1.Name = "poisonPanel1";
            this.poisonPanel1.Size = new System.Drawing.Size(328, 480);
            this.poisonPanel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonPanel1.TabIndex = 19;
            this.poisonPanel1.UseCustomBackColor = true;
            this.poisonPanel1.VerticalScrollbarBarColor = false;
            this.poisonPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.VerticalScrollbarSize = 10;
            // 
            // plbSelectedAudioPositionTime
            // 
            this.plbSelectedAudioPositionTime.AutoSize = true;
            this.plbSelectedAudioPositionTime.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioPositionTime.Location = new System.Drawing.Point(24, 352);
            this.plbSelectedAudioPositionTime.Name = "plbSelectedAudioPositionTime";
            this.plbSelectedAudioPositionTime.Size = new System.Drawing.Size(84, 19);
            this.plbSelectedAudioPositionTime.TabIndex = 19;
            this.plbSelectedAudioPositionTime.Text = "00:00 / 02:00";
            this.plbSelectedAudioPositionTime.UseCustomBackColor = true;
            // 
            // plbSelectedAudioPositionTrackTime
            // 
            this.plbSelectedAudioPositionTrackTime.AutoSize = true;
            this.plbSelectedAudioPositionTrackTime.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioPositionTrackTime.Location = new System.Drawing.Point(144, 376);
            this.plbSelectedAudioPositionTrackTime.Name = "plbSelectedAudioPositionTrackTime";
            this.plbSelectedAudioPositionTrackTime.Size = new System.Drawing.Size(40, 19);
            this.plbSelectedAudioPositionTrackTime.TabIndex = 18;
            this.plbSelectedAudioPositionTrackTime.Text = "00:00";
            this.plbSelectedAudioPositionTrackTime.UseCustomBackColor = true;
            this.plbSelectedAudioPositionTrackTime.Visible = false;
            // 
            // ptlSelectedAudioStop
            // 
            this.ptlSelectedAudioStop.ActiveControl = null;
            this.ptlSelectedAudioStop.BackColor = System.Drawing.Color.Transparent;
            this.ptlSelectedAudioStop.DisplayFocusBorder = false;
            this.ptlSelectedAudioStop.Location = new System.Drawing.Point(208, 424);
            this.ptlSelectedAudioStop.Name = "ptlSelectedAudioStop";
            this.ptlSelectedAudioStop.Size = new System.Drawing.Size(40, 40);
            this.ptlSelectedAudioStop.TabIndex = 14;
            this.ptlSelectedAudioStop.TileImage = global::SoundDeck.Properties.Resources.StopAudio;
            this.ptlSelectedAudioStop.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioStop.UseCustomBackColor = true;
            this.ptlSelectedAudioStop.UseSelectable = true;
            this.ptlSelectedAudioStop.UseTileImage = true;
            this.ptlSelectedAudioStop.Click += new System.EventHandler(this.ptlSelectedAudioStop_Click);
            // 
            // plbSelectedAudioArtist
            // 
            this.plbSelectedAudioArtist.AutoSize = true;
            this.plbSelectedAudioArtist.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioArtist.Location = new System.Drawing.Point(24, 328);
            this.plbSelectedAudioArtist.Name = "plbSelectedAudioArtist";
            this.plbSelectedAudioArtist.Size = new System.Drawing.Size(49, 19);
            this.plbSelectedAudioArtist.TabIndex = 17;
            this.plbSelectedAudioArtist.Text = "Autore";
            this.plbSelectedAudioArtist.UseCustomBackColor = true;
            // 
            // ptlSelectedAudioPause
            // 
            this.ptlSelectedAudioPause.ActiveControl = null;
            this.ptlSelectedAudioPause.BackColor = System.Drawing.Color.Transparent;
            this.ptlSelectedAudioPause.DisplayFocusBorder = false;
            this.ptlSelectedAudioPause.Location = new System.Drawing.Point(144, 424);
            this.ptlSelectedAudioPause.Name = "ptlSelectedAudioPause";
            this.ptlSelectedAudioPause.Size = new System.Drawing.Size(40, 40);
            this.ptlSelectedAudioPause.TabIndex = 13;
            this.ptlSelectedAudioPause.TileImage = global::SoundDeck.Properties.Resources.PauseAudio;
            this.ptlSelectedAudioPause.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioPause.UseCustomBackColor = true;
            this.ptlSelectedAudioPause.UseSelectable = true;
            this.ptlSelectedAudioPause.UseTileImage = true;
            this.ptlSelectedAudioPause.Click += new System.EventHandler(this.ptlSelectedAudioPause_Click);
            // 
            // ptbSelectedAudioPosition
            // 
            this.ptbSelectedAudioPosition.BackColor = System.Drawing.Color.Transparent;
            this.ptbSelectedAudioPosition.Location = new System.Drawing.Point(24, 400);
            this.ptbSelectedAudioPosition.Name = "ptbSelectedAudioPosition";
            this.ptbSelectedAudioPosition.Size = new System.Drawing.Size(280, 16);
            this.ptbSelectedAudioPosition.TabIndex = 3;
            this.ptbSelectedAudioPosition.Text = "poisonTrackBar1";
            this.ptbSelectedAudioPosition.UseCustomBackColor = true;
            this.ptbSelectedAudioPosition.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ptbSelectedAudioPosition_Scroll);
            this.ptbSelectedAudioPosition.MouseLeave += new System.EventHandler(this.ptbSelectedAudioPosition_MouseLeave);
            this.ptbSelectedAudioPosition.MouseHover += new System.EventHandler(this.ptbSelectedAudioPosition_MouseHover);
            // 
            // ptlSelectedAudioPlay
            // 
            this.ptlSelectedAudioPlay.ActiveControl = null;
            this.ptlSelectedAudioPlay.BackColor = System.Drawing.Color.Transparent;
            this.ptlSelectedAudioPlay.DisplayFocusBorder = false;
            this.ptlSelectedAudioPlay.Location = new System.Drawing.Point(80, 424);
            this.ptlSelectedAudioPlay.Name = "ptlSelectedAudioPlay";
            this.ptlSelectedAudioPlay.Size = new System.Drawing.Size(40, 40);
            this.ptlSelectedAudioPlay.TabIndex = 12;
            this.ptlSelectedAudioPlay.TileImage = global::SoundDeck.Properties.Resources.PlayAudio;
            this.ptlSelectedAudioPlay.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioPlay.UseCustomBackColor = true;
            this.ptlSelectedAudioPlay.UseSelectable = true;
            this.ptlSelectedAudioPlay.UseTileImage = true;
            this.ptlSelectedAudioPlay.Click += new System.EventHandler(this.ptlSelectedAudioPlay_Click);
            // 
            // picSelectedAudioAlbumArt
            // 
            this.picSelectedAudioAlbumArt.Cursor = System.Windows.Forms.Cursors.Default;
            this.picSelectedAudioAlbumArt.InitialImage = global::SoundDeck.Properties.Resources.AlbumArtNotAvailable;
            this.picSelectedAudioAlbumArt.Location = new System.Drawing.Point(24, 24);
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
            this.plbSelectedAudioTitle.Location = new System.Drawing.Point(24, 304);
            this.plbSelectedAudioTitle.Name = "plbSelectedAudioTitle";
            this.plbSelectedAudioTitle.Size = new System.Drawing.Size(57, 25);
            this.plbSelectedAudioTitle.TabIndex = 15;
            this.plbSelectedAudioTitle.Text = "Titolo";
            this.plbSelectedAudioTitle.UseCustomBackColor = true;
            // 
            // pbtAddAudio
            // 
            this.pbtAddAudio.Location = new System.Drawing.Point(320, 8);
            this.pbtAddAudio.Name = "pbtAddAudio";
            this.pbtAddAudio.Size = new System.Drawing.Size(40, 24);
            this.pbtAddAudio.TabIndex = 11;
            this.pbtAddAudio.Text = "ADD";
            this.pbtAddAudio.UseCustomBackColor = true;
            this.pbtAddAudio.UseSelectable = true;
            this.pbtAddAudio.UseStyleColors = true;
            this.pbtAddAudio.Click += new System.EventHandler(this.pbtAddAudio_Click);
            // 
            // ptxAudioFilePath
            // 
            // 
            // 
            // 
            this.ptxAudioFilePath.CustomButton.Image = null;
            this.ptxAudioFilePath.CustomButton.Location = new System.Drawing.Point(186, 2);
            this.ptxAudioFilePath.CustomButton.Name = "";
            this.ptxAudioFilePath.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.ptxAudioFilePath.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxAudioFilePath.CustomButton.TabIndex = 1;
            this.ptxAudioFilePath.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxAudioFilePath.CustomButton.UseSelectable = true;
            this.ptxAudioFilePath.CustomButton.Visible = false;
            this.ptxAudioFilePath.Lines = new string[] {
        "..."};
            this.ptxAudioFilePath.Location = new System.Drawing.Point(96, 8);
            this.ptxAudioFilePath.MaxLength = 32767;
            this.ptxAudioFilePath.Name = "ptxAudioFilePath";
            this.ptxAudioFilePath.PasswordChar = '\0';
            this.ptxAudioFilePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxAudioFilePath.SelectedText = "";
            this.ptxAudioFilePath.SelectionLength = 0;
            this.ptxAudioFilePath.SelectionStart = 0;
            this.ptxAudioFilePath.ShortcutsEnabled = true;
            this.ptxAudioFilePath.Size = new System.Drawing.Size(208, 24);
            this.ptxAudioFilePath.TabIndex = 10;
            this.ptxAudioFilePath.Text = "...";
            this.ptxAudioFilePath.UseSelectable = true;
            this.ptxAudioFilePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxAudioFilePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pbtBrowseAudio
            // 
            this.pbtBrowseAudio.Location = new System.Drawing.Point(16, 8);
            this.pbtBrowseAudio.Name = "pbtBrowseAudio";
            this.pbtBrowseAudio.Size = new System.Drawing.Size(60, 24);
            this.pbtBrowseAudio.TabIndex = 9;
            this.pbtBrowseAudio.Text = "BROWSE";
            this.pbtBrowseAudio.UseCustomBackColor = true;
            this.pbtBrowseAudio.UseSelectable = true;
            this.pbtBrowseAudio.UseStyleColors = true;
            this.pbtBrowseAudio.Click += new System.EventHandler(this.pbtBrowseAudio_Click);
            // 
            // ptlSelectedAudioVolumePct
            // 
            this.ptlSelectedAudioVolumePct.ActiveControl = null;
            this.ptlSelectedAudioVolumePct.Enabled = false;
            this.ptlSelectedAudioVolumePct.Location = new System.Drawing.Point(704, 448);
            this.ptlSelectedAudioVolumePct.Name = "ptlSelectedAudioVolumePct";
            this.ptlSelectedAudioVolumePct.Size = new System.Drawing.Size(48, 40);
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
            this.psbSelectedAudioVolume.LargeChange = 10;
            this.psbSelectedAudioVolume.Location = new System.Drawing.Point(704, 8);
            this.psbSelectedAudioVolume.Maximum = 100;
            this.psbSelectedAudioVolume.Minimum = 0;
            this.psbSelectedAudioVolume.MouseWheelBarPartitions = 10;
            this.psbSelectedAudioVolume.Name = "psbSelectedAudioVolume";
            this.psbSelectedAudioVolume.Orientation = ReaLTaiizor.Enum.Poison.ScrollOrientationType.Vertical;
            this.psbSelectedAudioVolume.ScrollbarSize = 50;
            this.psbSelectedAudioVolume.Size = new System.Drawing.Size(50, 432);
            this.psbSelectedAudioVolume.TabIndex = 7;
            this.psbSelectedAudioVolume.UseBarColor = true;
            this.psbSelectedAudioVolume.UseSelectable = true;
            this.psbSelectedAudioVolume.Scroll += new System.Windows.Forms.ScrollEventHandler(this.psbSelectedAudioVolume_Scroll);
            // 
            // plvPlaylist
            // 
            this.plvPlaylist.BackgroundImageTiled = true;
            this.plvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAudioTitle,
            this.colAudioArtist,
            this.colAudioDuration});
            this.plvPlaylist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.plvPlaylist.FullRowSelect = true;
            this.plvPlaylist.GridLines = true;
            this.plvPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.plvPlaylist.Location = new System.Drawing.Point(16, 40);
            this.plvPlaylist.MultiSelect = false;
            this.plvPlaylist.Name = "plvPlaylist";
            this.plvPlaylist.OwnerDraw = true;
            this.plvPlaylist.Size = new System.Drawing.Size(344, 448);
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
            // poisonTabPage2
            // 
            this.poisonTabPage2.HorizontalScrollbarBarColor = true;
            this.poisonTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.poisonTabPage2.HorizontalScrollbarSize = 10;
            this.poisonTabPage2.Location = new System.Drawing.Point(4, 38);
            this.poisonTabPage2.Name = "poisonTabPage2";
            this.poisonTabPage2.Size = new System.Drawing.Size(776, 502);
            this.poisonTabPage2.TabIndex = 1;
            this.poisonTabPage2.Text = "poisonTabPage2";
            this.poisonTabPage2.VerticalScrollbarBarColor = true;
            this.poisonTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.poisonTabPage2.VerticalScrollbarSize = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.poisonTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.Text = "SoundDeck";
            this.poisonTabControl1.ResumeLayout(false);
            this.poisonTabPage1.ResumeLayout(false);
            this.poisonPanel1.ResumeLayout(false);
            this.poisonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedAudioAlbumArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonTabControl poisonTabControl1;
        private ReaLTaiizor.Controls.PoisonTabPage poisonTabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.PoisonTabPage poisonTabPage1;
        private ReaLTaiizor.Controls.PoisonListView plvPlaylist;
        private ReaLTaiizor.Controls.PoisonTrackBar ptbSelectedAudioPosition;
        private System.Windows.Forms.PictureBox picSelectedAudioAlbumArt;
        private ReaLTaiizor.Controls.PoisonScrollBar psbSelectedAudioVolume;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioVolumePct;
        private ReaLTaiizor.Controls.PoisonButton pbtBrowseAudio;
        private ReaLTaiizor.Controls.PoisonButton pbtAddAudio;
        private ReaLTaiizor.Controls.PoisonTextBox ptxAudioFilePath;
        private System.Windows.Forms.ColumnHeader colAudioArtist;
        private System.Windows.Forms.ColumnHeader colAudioDuration;
        private System.Windows.Forms.ColumnHeader colAudioTitle;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioStop;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioPause;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioPlay;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioArtist;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioTitle;
        private ReaLTaiizor.Controls.PoisonPanel poisonPanel1;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioPositionTrackTime;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioPositionTime;
    }
}

