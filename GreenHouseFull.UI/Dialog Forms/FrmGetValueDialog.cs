using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI.RaporUI
{
    public partial class FrmGetValueDialog : Form
    {
        public string ReturnValue { get; set; }

        public FrmGetValueDialog(string lblAciklamaText)
        {
            InitializeComponent();

            lblAciklama.Text = lblAciklamaText;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReturnValue = txtCevap.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
