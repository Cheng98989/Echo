namespace Echo
{
    partial class ConfirmForm
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptxConfirmMessage = new ReaLTaiizor.Controls.PoisonTextBox();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbConfirmMessage = new ReaLTaiizor.Controls.PoisonLabel();
            this.pbtConferma = new ReaLTaiizor.Controls.PoisonButton();
            this.SuspendLayout();
            // 
            // ptxConfirmMessage
            // 
            // 
            // 
            // 
            this.ptxConfirmMessage.CustomButton.Image = null;
            this.ptxConfirmMessage.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.ptxConfirmMessage.CustomButton.Name = "";
            this.ptxConfirmMessage.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ptxConfirmMessage.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.ptxConfirmMessage.CustomButton.TabIndex = 1;
            this.ptxConfirmMessage.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            this.ptxConfirmMessage.CustomButton.UseSelectable = true;
            this.ptxConfirmMessage.CustomButton.Visible = false;
            this.ptxConfirmMessage.Lines = new string[0];
            this.ptxConfirmMessage.Location = new System.Drawing.Point(29, 74);
            this.ptxConfirmMessage.MaxLength = 32767;
            this.ptxConfirmMessage.Name = "ptxConfirmMessage";
            this.ptxConfirmMessage.PasswordChar = '\0';
            this.ptxConfirmMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ptxConfirmMessage.SelectedText = "";
            this.ptxConfirmMessage.SelectionLength = 0;
            this.ptxConfirmMessage.SelectionStart = 0;
            this.ptxConfirmMessage.ShortcutsEnabled = true;
            this.ptxConfirmMessage.Size = new System.Drawing.Size(298, 23);
            this.ptxConfirmMessage.TabIndex = 0;
            this.ptxConfirmMessage.UseSelectable = true;
            this.ptxConfirmMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ptxConfirmMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.Location = new System.Drawing.Point(29, 22);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(298, 19);
            this.poisonLabel1.TabIndex = 1;
            this.poisonLabel1.Text = "Inserisci il seguente testo per confermare l\'azione.";
            // 
            // plbConfirmMessage
            // 
            this.plbConfirmMessage.AutoSize = true;
            this.plbConfirmMessage.Location = new System.Drawing.Point(29, 41);
            this.plbConfirmMessage.Name = "plbConfirmMessage";
            this.plbConfirmMessage.Size = new System.Drawing.Size(18, 19);
            this.plbConfirmMessage.TabIndex = 2;
            this.plbConfirmMessage.Text = "...";
            // 
            // pbtConferma
            // 
            this.pbtConferma.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Tall;
            this.pbtConferma.Location = new System.Drawing.Point(29, 104);
            this.pbtConferma.MaximumSize = new System.Drawing.Size(298, 23);
            this.pbtConferma.MinimumSize = new System.Drawing.Size(298, 23);
            this.pbtConferma.Name = "pbtConferma";
            this.pbtConferma.Size = new System.Drawing.Size(298, 23);
            this.pbtConferma.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pbtConferma.TabIndex = 3;
            this.pbtConferma.Text = "CONFERMO";
            this.pbtConferma.UseSelectable = true;
            this.pbtConferma.UseStyleColors = true;
            this.pbtConferma.Click += new System.EventHandler(this.pbtConferma_Click);
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 150);
            this.Controls.Add(this.pbtConferma);
            this.Controls.Add(this.plbConfirmMessage);
            this.Controls.Add(this.poisonLabel1);
            this.Controls.Add(this.ptxConfirmMessage);
            this.Name = "ConfirmForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonTextBox ptxConfirmMessage;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonLabel plbConfirmMessage;
        private ReaLTaiizor.Controls.PoisonButton pbtConferma;
    }
}
