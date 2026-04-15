using ReaLTaiizor.Child.Poison;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundDeck
{
    public partial class ConfirmForm : PoisonForm
    {
        public bool? Result;
        public ConfirmForm(string ConfirmMessage)
        {
            InitializeComponent();
            plbConfirmMessage.Text = ConfirmMessage;
        }
        private void pbtConferma_Click(object sender, EventArgs e)
        {
            if(ptxConfirmMessage.Text != plbConfirmMessage.Text)
            {
                PoisonMessageBox.Show(
                    this,
                    "Il testo non corrisponde",
                    "Conferma Fallita"
                );
                Result = false;
                return;
            }

            Result = true;
            this.Close();
        }
    }
}
