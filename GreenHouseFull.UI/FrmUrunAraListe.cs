using GreenHouseFull.Common;
using GreenHouseFull.DAL;
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

namespace GreenHouseFull.UI
{
    public partial class FrmUrunAraListe : Form
    {
        List<UrunSimpleListDTO> urunAdiAraDTOs;
        public FrmUrunAraListe(List<UrunSimpleListDTO> urunAdiAraDTOs)
        {
            InitializeComponent();
            this.urunAdiAraDTOs = urunAdiAraDTOs;
        }

        private void FrmUrunAdiAramaListe_Load(object sender, EventArgs e)
        {
            listBUruns.Items.AddRange(urunAdiAraDTOs.ToArray());
        }

        private void listBUruns_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBUruns.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                UrunSimpleListDTO urunSimpleListDTO = listBUruns.Items[listBUruns.SelectedIndex] as UrunSimpleListDTO;

                try
                {
                    UrunDAL urunDAL = new UrunDAL();
                    UrunDTO urunDTO = urunDAL.GetUrunDTO(urunSimpleListDTO.Id, ClientVariables.LoggedInUserId);

                    FrmUrun frmUrun = new FrmUrun(urunDTO);
                    frmUrun.MdiParent = this.MdiParent;
                    frmUrun.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürünü getirirken bir hata oluştu. " + ex.Message);
                }
            }
        }
    }
}
