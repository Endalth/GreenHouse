using GreenHouseFull.Common;
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
    public partial class FrmBigImage : Form
    {
        byte[] image;
        public FrmBigImage(byte[] image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void FrmBigImage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = UsefulMethods.ImageFromByteArray(image);
        }
    }
}
