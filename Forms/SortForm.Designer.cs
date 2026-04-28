namespace Echo.Forms
{
    partial class SortForm
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
            this.pbtOrdina = new ReaLTaiizor.Controls.PoisonButton();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.pcbSortType = new ReaLTaiizor.Controls.PoisonComboBox();
            this.pcbReference = new ReaLTaiizor.Controls.PoisonComboBox();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonCheckBox1 = new ReaLTaiizor.Controls.PoisonCheckBox();
            this.poisonLabel3 = new ReaLTaiizor.Controls.PoisonLabel();
            this.SuspendLayout();
            // 
            // pbtOrdina
            // 
            this.pbtOrdina.Location = new System.Drawing.Point(25, 181);
            this.pbtOrdina.Name = "pbtOrdina";
            this.pbtOrdina.Size = new System.Drawing.Size(197, 32);
            this.pbtOrdina.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pbtOrdina.TabIndex = 0;
            this.pbtOrdina.Text = "ORDINA";
            this.pbtOrdina.UseSelectable = true;
            this.pbtOrdina.Click += new System.EventHandler(this.pbtOrdina_Click);
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.Location = new System.Drawing.Point(23, 73);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(88, 19);
            this.poisonLabel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel1.TabIndex = 22;
            this.poisonLabel1.Text = "Ordinamento";
            // 
            // pcbSortType
            // 
            this.pcbSortType.DropDownHeight = 100;
            this.pcbSortType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pcbSortType.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
            this.pcbSortType.FormattingEnabled = true;
            this.pcbSortType.IntegralHeight = false;
            this.pcbSortType.ItemHeight = 19;
            this.pcbSortType.Items.AddRange(new object[] {
            "Crescente",
            "Decrescente"});
            this.pcbSortType.Location = new System.Drawing.Point(117, 67);
            this.pcbSortType.Name = "pcbSortType";
            this.pcbSortType.Size = new System.Drawing.Size(105, 25);
            this.pcbSortType.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pcbSortType.TabIndex = 23;
            this.pcbSortType.UseSelectable = true;
            this.pcbSortType.UseStyleColors = true;
            // 
            // pcbReference
            // 
            this.pcbReference.DropDownHeight = 100;
            this.pcbReference.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pcbReference.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
            this.pcbReference.FormattingEnabled = true;
            this.pcbReference.IntegralHeight = false;
            this.pcbReference.ItemHeight = 19;
            this.pcbReference.Items.AddRange(new object[] {
            "Titolo",
            "Autore",
            "Durata",
            "Filepath",
            "Volume Multiplier"});
            this.pcbReference.Location = new System.Drawing.Point(117, 102);
            this.pcbReference.Name = "pcbReference";
            this.pcbReference.Size = new System.Drawing.Size(105, 25);
            this.pcbReference.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pcbReference.TabIndex = 25;
            this.pcbReference.UseSelectable = true;
            this.pcbReference.UseStyleColors = true;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.Location = new System.Drawing.Point(23, 108);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(77, 19);
            this.poisonLabel2.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel2.TabIndex = 24;
            this.poisonLabel2.Text = "Riferimento";
            // 
            // poisonCheckBox1
            // 
            this.poisonCheckBox1.Location = new System.Drawing.Point(117, 138);
            this.poisonCheckBox1.Name = "poisonCheckBox1";
            this.poisonCheckBox1.Size = new System.Drawing.Size(21, 24);
            this.poisonCheckBox1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonCheckBox1.TabIndex = 26;
            this.poisonCheckBox1.UseSelectable = true;
            // 
            // poisonLabel3
            // 
            this.poisonLabel3.AutoSize = true;
            this.poisonLabel3.Location = new System.Drawing.Point(23, 143);
            this.poisonLabel3.Name = "poisonLabel3";
            this.poisonLabel3.Size = new System.Drawing.Size(48, 19);
            this.poisonLabel3.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel3.TabIndex = 27;
            this.poisonLabel3.Text = "Stabile";
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 232);
            this.Controls.Add(this.poisonLabel3);
            this.Controls.Add(this.poisonCheckBox1);
            this.Controls.Add(this.pcbReference);
            this.Controls.Add(this.poisonLabel2);
            this.Controls.Add(this.pcbSortType);
            this.Controls.Add(this.poisonLabel1);
            this.Controls.Add(this.pbtOrdina);
            this.Name = "SortForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.Text = "SortForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonButton pbtOrdina;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonComboBox pcbSortType;
        private ReaLTaiizor.Controls.PoisonComboBox pcbReference;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel2;
        private ReaLTaiizor.Controls.PoisonCheckBox poisonCheckBox1;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel3;
    }
}