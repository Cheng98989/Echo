namespace SoundDeck
{
    partial class ModifyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.poisonPanel1 = new ReaLTaiizor.Controls.PoisonPanel();
            this.pbtModify = new ReaLTaiizor.Controls.PoisonButton();
            this.ptxAutore = new ReaLTaiizor.Controls.PoisonTextBox();
            this.ptxTitolo = new ReaLTaiizor.Controls.PoisonTextBox();
            this.plbSelectedAudioArtist = new ReaLTaiizor.Controls.PoisonLabel();
            this.picAudioAlbumArt = new System.Windows.Forms.PictureBox();
            this.pbtBrowseAudio = new ReaLTaiizor.Controls.PoisonButton();
            this.pbtAddAudio = new ReaLTaiizor.Controls.PoisonButton();
            this.ptxAlbumFilePath = new ReaLTaiizor.Controls.PoisonTextBox();
            this.ptxAlbum = new ReaLTaiizor.Controls.PoisonTextBox();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel3 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel6 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel4 = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbDurata = new ReaLTaiizor.Controls.PoisonLabel();
            this.ptlSelectedAudioVolumePct = new ReaLTaiizor.Controls.PoisonTile();
            this.psbAudioVolume = new ReaLTaiizor.Controls.PoisonScrollBar();
            this.poisonLabel7 = new ReaLTaiizor.Controls.PoisonLabel();
            this.ptxVolumeMultiplier = new ReaLTaiizor.Controls.PoisonTextBox();
            this.poisonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudioAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // poisonPanel1
            // 
            this.poisonPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.poisonPanel1.Controls.Add(this.ptxVolumeMultiplier);
            this.poisonPanel1.Controls.Add(this.poisonLabel7);
            this.poisonPanel1.Controls.Add(this.ptlSelectedAudioVolumePct);
            this.poisonPanel1.Controls.Add(this.plbDurata);
            this.poisonPanel1.Controls.Add(this.poisonLabel4);
            this.poisonPanel1.Controls.Add(this.psbAudioVolume);
            this.poisonPanel1.Controls.Add(this.poisonLabel6);
            this.poisonPanel1.Controls.Add(this.poisonLabel3);
            this.poisonPanel1.Controls.Add(this.poisonLabel2);
            this.poisonPanel1.Controls.Add(this.poisonLabel1);
            this.poisonPanel1.Controls.Add(this.ptxAlbum);
            this.poisonPanel1.Controls.Add(this.pbtBrowseAudio);
            this.poisonPanel1.Controls.Add(this.pbtAddAudio);
            this.poisonPanel1.Controls.Add(this.ptxAlbumFilePath);
            this.poisonPanel1.Controls.Add(this.pbtModify);
            this.poisonPanel1.Controls.Add(this.ptxAutore);
            this.poisonPanel1.Controls.Add(this.ptxTitolo);
            this.poisonPanel1.Controls.Add(this.plbSelectedAudioArtist);
            this.poisonPanel1.Controls.Add(this.picAudioAlbumArt);
            this.poisonPanel1.HorizontalScrollbarBarColor = true;
            this.poisonPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.HorizontalScrollbarSize = 10;
            this.poisonPanel1.Location = new System.Drawing.Point(32, 64);
            this.poisonPanel1.Name = "poisonPanel1";
            this.poisonPanel1.Size = new System.Drawing.Size(736, 504);
            this.poisonPanel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonPanel1.TabIndex = 20;
            this.poisonPanel1.UseCustomBackColor = true;
            this.poisonPanel1.VerticalScrollbarBarColor = false;
            this.poisonPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.poisonPanel1.VerticalScrollbarSize = 10;
            // 
            // pbtModify
            // 
            this.pbtModify.Location = new System.Drawing.Point(16, 448);
            this.pbtModify.Name = "pbtModify";
            this.pbtModify.Size = new System.Drawing.Size(624, 37);
            this.pbtModify.TabIndex = 22;
            this.pbtModify.Text = "poisonButton1";
            this.pbtModify.UseSelectable = true;
            this.pbtModify.Click += new System.EventHandler(this.pbtModify_Click);
            // 
            // ptxAutore
            // 
            // 
            // 
            // 
            this.ptxAutore.CustomButton.Image = null;
            this.ptxAutore.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.ptxAutore.CustomButton.Name = "";
            this.ptxAutore.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxAutore.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxAutore.CustomButton.TabIndex = 1;
            this.ptxAutore.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxAutore.CustomButton.UseSelectable = true;
            this.ptxAutore.CustomButton.Visible = false;
            this.ptxAutore.Lines = new string[] {
        "ptxAutore"};
            this.ptxAutore.Location = new System.Drawing.Point(96, 48);
            this.ptxAutore.MaxLength = 32767;
            this.ptxAutore.Name = "ptxAutore";
            this.ptxAutore.PasswordChar = '\0';
            this.ptxAutore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxAutore.SelectedText = "";
            this.ptxAutore.SelectionLength = 0;
            this.ptxAutore.SelectionStart = 0;
            this.ptxAutore.ShortcutsEnabled = true;
            this.ptxAutore.Size = new System.Drawing.Size(75, 23);
            this.ptxAutore.TabIndex = 21;
            this.ptxAutore.Text = "ptxAutore";
            this.ptxAutore.UseSelectable = true;
            this.ptxAutore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxAutore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ptxTitolo
            // 
            // 
            // 
            // 
            this.ptxTitolo.CustomButton.Image = null;
            this.ptxTitolo.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.ptxTitolo.CustomButton.Name = "";
            this.ptxTitolo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxTitolo.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxTitolo.CustomButton.TabIndex = 1;
            this.ptxTitolo.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxTitolo.CustomButton.UseSelectable = true;
            this.ptxTitolo.CustomButton.Visible = false;
            this.ptxTitolo.Lines = new string[] {
        "ptxTitolo"};
            this.ptxTitolo.Location = new System.Drawing.Point(96, 16);
            this.ptxTitolo.MaxLength = 32767;
            this.ptxTitolo.Name = "ptxTitolo";
            this.ptxTitolo.PasswordChar = '\0';
            this.ptxTitolo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxTitolo.SelectedText = "";
            this.ptxTitolo.SelectionLength = 0;
            this.ptxTitolo.SelectionStart = 0;
            this.ptxTitolo.ShortcutsEnabled = true;
            this.ptxTitolo.Size = new System.Drawing.Size(75, 23);
            this.ptxTitolo.TabIndex = 20;
            this.ptxTitolo.Text = "ptxTitolo";
            this.ptxTitolo.UseSelectable = true;
            this.ptxTitolo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxTitolo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // plbSelectedAudioArtist
            // 
            this.plbSelectedAudioArtist.AutoSize = true;
            this.plbSelectedAudioArtist.BackColor = System.Drawing.Color.Transparent;
            this.plbSelectedAudioArtist.Location = new System.Drawing.Point(24, 48);
            this.plbSelectedAudioArtist.Name = "plbSelectedAudioArtist";
            this.plbSelectedAudioArtist.Size = new System.Drawing.Size(49, 19);
            this.plbSelectedAudioArtist.TabIndex = 17;
            this.plbSelectedAudioArtist.Text = "Autore";
            this.plbSelectedAudioArtist.UseCustomBackColor = true;
            // 
            // picAudioAlbumArt
            // 
            this.picAudioAlbumArt.Cursor = System.Windows.Forms.Cursors.Default;
            this.picAudioAlbumArt.InitialImage = global::SoundDeck.Properties.Resources.AlbumArtNotAvailable;
            this.picAudioAlbumArt.Location = new System.Drawing.Point(424, 24);
            this.picAudioAlbumArt.Name = "picAudioAlbumArt";
            this.picAudioAlbumArt.Size = new System.Drawing.Size(224, 224);
            this.picAudioAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAudioAlbumArt.TabIndex = 2;
            this.picAudioAlbumArt.TabStop = false;
            // 
            // pbtBrowseAudio
            // 
            this.pbtBrowseAudio.Location = new System.Drawing.Point(88, 120);
            this.pbtBrowseAudio.Name = "pbtBrowseAudio";
            this.pbtBrowseAudio.Size = new System.Drawing.Size(60, 24);
            this.pbtBrowseAudio.TabIndex = 23;
            this.pbtBrowseAudio.Text = "BROWSE";
            this.pbtBrowseAudio.UseCustomBackColor = true;
            this.pbtBrowseAudio.UseSelectable = true;
            this.pbtBrowseAudio.UseStyleColors = true;
            // 
            // pbtAddAudio
            // 
            this.pbtAddAudio.Location = new System.Drawing.Point(320, 120);
            this.pbtAddAudio.Name = "pbtAddAudio";
            this.pbtAddAudio.Size = new System.Drawing.Size(64, 24);
            this.pbtAddAudio.TabIndex = 25;
            this.pbtAddAudio.Text = "SELECT";
            this.pbtAddAudio.UseCustomBackColor = true;
            this.pbtAddAudio.UseSelectable = true;
            this.pbtAddAudio.UseStyleColors = true;
            // 
            // ptxAlbumFilePath
            // 
            // 
            // 
            // 
            this.ptxAlbumFilePath.CustomButton.Image = null;
            this.ptxAlbumFilePath.CustomButton.Location = new System.Drawing.Point(122, 2);
            this.ptxAlbumFilePath.CustomButton.Name = "";
            this.ptxAlbumFilePath.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.ptxAlbumFilePath.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxAlbumFilePath.CustomButton.TabIndex = 1;
            this.ptxAlbumFilePath.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxAlbumFilePath.CustomButton.UseSelectable = true;
            this.ptxAlbumFilePath.CustomButton.Visible = false;
            this.ptxAlbumFilePath.Lines = new string[] {
        "..."};
            this.ptxAlbumFilePath.Location = new System.Drawing.Point(160, 120);
            this.ptxAlbumFilePath.MaxLength = 32767;
            this.ptxAlbumFilePath.Name = "ptxAlbumFilePath";
            this.ptxAlbumFilePath.PasswordChar = '\0';
            this.ptxAlbumFilePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxAlbumFilePath.SelectedText = "";
            this.ptxAlbumFilePath.SelectionLength = 0;
            this.ptxAlbumFilePath.SelectionStart = 0;
            this.ptxAlbumFilePath.ShortcutsEnabled = true;
            this.ptxAlbumFilePath.Size = new System.Drawing.Size(144, 24);
            this.ptxAlbumFilePath.TabIndex = 24;
            this.ptxAlbumFilePath.Text = "...";
            this.ptxAlbumFilePath.UseSelectable = true;
            this.ptxAlbumFilePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxAlbumFilePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ptxAlbum
            // 
            // 
            // 
            // 
            this.ptxAlbum.CustomButton.Image = null;
            this.ptxAlbum.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.ptxAlbum.CustomButton.Name = "";
            this.ptxAlbum.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxAlbum.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxAlbum.CustomButton.TabIndex = 1;
            this.ptxAlbum.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxAlbum.CustomButton.UseSelectable = true;
            this.ptxAlbum.CustomButton.Visible = false;
            this.ptxAlbum.Lines = new string[] {
        "poisonTextBox4"};
            this.ptxAlbum.Location = new System.Drawing.Point(88, 88);
            this.ptxAlbum.MaxLength = 32767;
            this.ptxAlbum.Name = "ptxAlbum";
            this.ptxAlbum.PasswordChar = '\0';
            this.ptxAlbum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxAlbum.SelectedText = "";
            this.ptxAlbum.SelectionLength = 0;
            this.ptxAlbum.SelectionStart = 0;
            this.ptxAlbum.ShortcutsEnabled = true;
            this.ptxAlbum.Size = new System.Drawing.Size(75, 23);
            this.ptxAlbum.TabIndex = 26;
            this.ptxAlbum.Text = "poisonTextBox4";
            this.ptxAlbum.UseSelectable = true;
            this.ptxAlbum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxAlbum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel1.Location = new System.Drawing.Point(24, 24);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(42, 19);
            this.poisonLabel1.TabIndex = 27;
            this.poisonLabel1.Text = "Titolo";
            this.poisonLabel1.UseCustomBackColor = true;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel2.Location = new System.Drawing.Point(24, 88);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(48, 19);
            this.poisonLabel2.TabIndex = 28;
            this.poisonLabel2.Text = "Album";
            this.poisonLabel2.UseCustomBackColor = true;
            // 
            // poisonLabel3
            // 
            this.poisonLabel3.AutoSize = true;
            this.poisonLabel3.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel3.Location = new System.Drawing.Point(24, 160);
            this.poisonLabel3.Name = "poisonLabel3";
            this.poisonLabel3.Size = new System.Drawing.Size(48, 19);
            this.poisonLabel3.TabIndex = 34;
            this.poisonLabel3.Text = "Durata";
            this.poisonLabel3.UseCustomBackColor = true;
            // 
            // poisonLabel6
            // 
            this.poisonLabel6.AutoSize = true;
            this.poisonLabel6.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel6.Location = new System.Drawing.Point(32, 192);
            this.poisonLabel6.Name = "poisonLabel6";
            this.poisonLabel6.Size = new System.Drawing.Size(0, 0);
            this.poisonLabel6.TabIndex = 36;
            this.poisonLabel6.UseCustomBackColor = true;
            // 
            // poisonLabel4
            // 
            this.poisonLabel4.AutoSize = true;
            this.poisonLabel4.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel4.Location = new System.Drawing.Point(24, 120);
            this.poisonLabel4.Name = "poisonLabel4";
            this.poisonLabel4.Size = new System.Drawing.Size(68, 19);
            this.poisonLabel4.TabIndex = 37;
            this.poisonLabel4.Text = "Copertina";
            this.poisonLabel4.UseCustomBackColor = true;
            // 
            // plbDurata
            // 
            this.plbDurata.AutoSize = true;
            this.plbDurata.Location = new System.Drawing.Point(96, 160);
            this.plbDurata.Name = "plbDurata";
            this.plbDurata.Size = new System.Drawing.Size(86, 19);
            this.plbDurata.TabIndex = 38;
            this.plbDurata.Text = "poisonLabel7";
            // 
            // ptlSelectedAudioVolumePct
            // 
            this.ptlSelectedAudioVolumePct.ActiveControl = null;
            this.ptlSelectedAudioVolumePct.Enabled = false;
            this.ptlSelectedAudioVolumePct.Location = new System.Drawing.Point(664, 448);
            this.ptlSelectedAudioVolumePct.Name = "ptlSelectedAudioVolumePct";
            this.ptlSelectedAudioVolumePct.Size = new System.Drawing.Size(48, 40);
            this.ptlSelectedAudioVolumePct.TabIndex = 41;
            this.ptlSelectedAudioVolumePct.Text = "100%";
            this.ptlSelectedAudioVolumePct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptlSelectedAudioVolumePct.TileTextFontSize = ReaLTaiizor.Extension.Poison.PoisonTileTextSize.Small;
            this.ptlSelectedAudioVolumePct.TileTextFontWeight = ReaLTaiizor.Extension.Poison.PoisonTileTextWeight.Regular;
            this.ptlSelectedAudioVolumePct.UseCustomForeColor = true;
            this.ptlSelectedAudioVolumePct.UseSelectable = true;
            // 
            // psbAudioVolume
            // 
            this.psbAudioVolume.LargeChange = 10;
            this.psbAudioVolume.Location = new System.Drawing.Point(664, 24);
            this.psbAudioVolume.Maximum = 100;
            this.psbAudioVolume.Minimum = 0;
            this.psbAudioVolume.MouseWheelBarPartitions = 10;
            this.psbAudioVolume.Name = "psbAudioVolume";
            this.psbAudioVolume.Orientation = ReaLTaiizor.Enum.Poison.ScrollOrientationType.Vertical;
            this.psbAudioVolume.ScrollbarSize = 50;
            this.psbAudioVolume.Size = new System.Drawing.Size(50, 395);
            this.psbAudioVolume.TabIndex = 40;
            this.psbAudioVolume.UseBarColor = true;
            this.psbAudioVolume.UseSelectable = true;
            // 
            // poisonLabel7
            // 
            this.poisonLabel7.AutoSize = true;
            this.poisonLabel7.BackColor = System.Drawing.Color.Transparent;
            this.poisonLabel7.Location = new System.Drawing.Point(16, 208);
            this.poisonLabel7.Name = "poisonLabel7";
            this.poisonLabel7.Size = new System.Drawing.Size(112, 19);
            this.poisonLabel7.TabIndex = 42;
            this.poisonLabel7.Text = "Volume Multiplier";
            this.poisonLabel7.UseCustomBackColor = true;
            // 
            // ptxVolumeMultiplier
            // 
            // 
            // 
            // 
            this.ptxVolumeMultiplier.CustomButton.Image = null;
            this.ptxVolumeMultiplier.CustomButton.Location = new System.Drawing.Point(90, 1);
            this.ptxVolumeMultiplier.CustomButton.Name = "";
            this.ptxVolumeMultiplier.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxVolumeMultiplier.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxVolumeMultiplier.CustomButton.TabIndex = 1;
            this.ptxVolumeMultiplier.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxVolumeMultiplier.CustomButton.UseSelectable = true;
            this.ptxVolumeMultiplier.CustomButton.Visible = false;
            this.ptxVolumeMultiplier.Lines = new string[] {
        "poisonTextBox4"};
            this.ptxVolumeMultiplier.Location = new System.Drawing.Point(144, 208);
            this.ptxVolumeMultiplier.MaxLength = 32767;
            this.ptxVolumeMultiplier.Name = "ptxVolumeMultiplier";
            this.ptxVolumeMultiplier.PasswordChar = '\0';
            this.ptxVolumeMultiplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxVolumeMultiplier.SelectedText = "";
            this.ptxVolumeMultiplier.SelectionLength = 0;
            this.ptxVolumeMultiplier.SelectionStart = 0;
            this.ptxVolumeMultiplier.ShortcutsEnabled = true;
            this.ptxVolumeMultiplier.Size = new System.Drawing.Size(112, 23);
            this.ptxVolumeMultiplier.TabIndex = 43;
            this.ptxVolumeMultiplier.Text = "poisonTextBox4";
            this.ptxVolumeMultiplier.UseSelectable = true;
            this.ptxVolumeMultiplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxVolumeMultiplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.poisonPanel1);
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.poisonPanel1.ResumeLayout(false);
            this.poisonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAudioAlbumArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAudioAlbumArt;
        private ReaLTaiizor.Controls.PoisonPanel poisonPanel1;
        private ReaLTaiizor.Controls.PoisonLabel plbSelectedAudioArtist;
        private ReaLTaiizor.Controls.PoisonTextBox ptxAutore;
        private ReaLTaiizor.Controls.PoisonTextBox ptxTitolo;
        private ReaLTaiizor.Controls.PoisonButton pbtModify;
        private ReaLTaiizor.Controls.PoisonButton pbtBrowseAudio;
        private ReaLTaiizor.Controls.PoisonButton pbtAddAudio;
        private ReaLTaiizor.Controls.PoisonTextBox ptxAlbumFilePath;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel6;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel3;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel2;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonTextBox ptxAlbum;
        private ReaLTaiizor.Controls.PoisonLabel plbDurata;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel4;
        private ReaLTaiizor.Controls.PoisonTile ptlSelectedAudioVolumePct;
        private ReaLTaiizor.Controls.PoisonScrollBar psbAudioVolume;
        private ReaLTaiizor.Controls.PoisonTextBox ptxVolumeMultiplier;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel7;
    }
}