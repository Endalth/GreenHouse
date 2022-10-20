using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI
{
    public partial class FrmGetNewPasswordDialog : Form
    {
        public string YeniSifre { get; set; }
        public FrmGetNewPasswordDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtPass.Text == txtPass2.Text)
            {
                bool isValid = true;
                string errorMessage = "";
                //Karakter limit
                if (txtPass.Text.Length == 0 || txtPass.Text.Length > 100)
                {
                    isValid = false;
                    errorMessage += "Şifre uzunluğu 0dan büyük ve 100den küçük olmalı";
                }

                if (txtPass.Text.Contains(" "))
                {
                    isValid = false;
                    if (errorMessage != "")
                        errorMessage += "\n";
                    errorMessage += "Şifre boşluk içeremez.";
                }

                if(isValid)
                {
                    YeniSifre = txtPass.Text;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Şifreler aynı değil.");
            }
        }
    }
}
