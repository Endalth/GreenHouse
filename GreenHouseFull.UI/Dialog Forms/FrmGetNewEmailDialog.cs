using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GreenHouseFull.UI.Dialog_Forms
{
    public partial class FrmGetNewEmailDialog : Form
    {
        public string NewEmail { get; set; }
        public FrmGetNewEmailDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Match emailFormatCheck = Regex.Match(txtEmail.Text, @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");
            if (!emailFormatCheck.Success)
            {
                string errorMessage = "Email formatı yanlış sadece harf, rakam yada \"-\", \"_\", \".\" karakterlerini kullanabilirsiniz. Örnek: ornek@email.com";
                MessageBox.Show(errorMessage);
            }
            else
            {
                NewEmail = txtEmail.Text;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
