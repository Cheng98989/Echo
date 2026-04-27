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

namespace Echo
{
    public partial class ConfirmForm : PoisonForm
    {
        //Get e set sono i metodi di accesso di una proprieta'
        //get mette in sola lettura la proprieta Result e private set la rende modificale solo dall'interno della classe.
        public ConfirmForm(string ConfirmMessage, AppSettings.UserSettings userSettings)
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
                    "Il codice inserito non corrisponde. Verifica il testo e riprova.",
                    "Conferma non riuscita",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
