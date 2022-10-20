using GreenHouseFull.Common;
using GreenHouseFull.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI.Dialog_Forms
{
    public partial class FrmUrunOnayGuncelleDialog : Form
    {
        public Commons.OnayDurum ReturnOnayDurum { get; set; }
        public string ReturnAciklama { get; set; }

        private Commons.OnayDurum onayDurum;
        private string aciklama;
        public FrmUrunOnayGuncelleDialog(Commons.OnayDurum onayDurum, string aciklama)
        {
            InitializeComponent();
            this.onayDurum = onayDurum;
            this.aciklama = aciklama;
        }

        private void FrmUrunOnayGuncelleDialog_Load(object sender, EventArgs e)
        {
            foreach(string enumName in Enum.GetNames(typeof(Commons.OnayDurum)))
                cbxOnayDurum.Items.Add(enumName.Replace("_", " "));

            for (int i = 0; i < cbxOnayDurum.Items.Count; i++)
            {
                if (cbxOnayDurum.Items[i].ToString() == onayDurum.ToString().Replace("_", " "))
                {
                    cbxOnayDurum.SelectedIndex = i;
                    break;
                }
            }

            txtAciklama.Text = aciklama;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtAciklama.Text == "" || txtAciklama.Text.Length > 300)
            {
                MessageBox.Show("Açıklama boş yada 300 karakterden uzun.");
                return;
            }

            ReturnOnayDurum = (Commons.OnayDurum)(cbxOnayDurum.SelectedIndex + 1);
            ReturnAciklama = txtAciklama.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
