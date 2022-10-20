using GreenHouseFull.Common;
using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
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
    public partial class FrmUrunAra : Form
    {
        public FrmUrunAra()
        {
            InitializeComponent();
        }

        private void FrmUrunAra_Load(object sender, EventArgs e)
        {
            radioBUrunAdi.Checked = true;
        }

        private void radioBUrunAdi_CheckedChanged(object sender, EventArgs e)
        {
            txtUrunAdi.Visible = radioBUrunAdi.Checked;
            mtxtBarkod.Visible = !radioBUrunAdi.Checked;
        }

        private void radioBBarkod_CheckedChanged(object sender, EventArgs e)
        {
            mtxtBarkod.Visible = radioBBarkod.Checked;
            txtUrunAdi.Visible = !radioBBarkod.Checked;
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            string errorMessage = "Ürün arama esnasında bir sorun oluştu.";
            if (radioBUrunAdi.Checked)
            {
                try
                {
                    UrunDAL urunDAL = new UrunDAL();
                    List<UrunSimpleListDTO> urunAdiAraDTOs = urunDAL.SearchProductName(txtUrunAdi.Text, ClientVariables.LoggedInUserId);

                    if (urunAdiAraDTOs.Count == 0)
                    {
                        MessageBox.Show("Herhangi bir ürün bulunamadı.");
                    }
                    else
                    {
                        FrmUrunAraListe frmUrunAdiAramaListe = new FrmUrunAraListe(urunAdiAraDTOs);
                        frmUrunAdiAramaListe.MdiParent = this.MdiParent;
                        frmUrunAdiAramaListe.Show();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorMessage + " : " + ex.Message);
                }
            }
            else if (radioBBarkod.Checked)
            {
                if (mtxtBarkod.MaskFull)
                {
                    try
                    {
                        UrunDAL urunDAL = new UrunDAL();
                        UrunDTO urunDTO = urunDAL.SearchBarcode(mtxtBarkod.Text, ClientVariables.LoggedInUserId);

                        if (urunDTO == null)
                        {
                            MessageBox.Show("Bu barkod da bir ürün yok.");
                        }
                        else
                        {
                            FrmUrun frmUrun = new FrmUrun(urunDTO);
                            frmUrun.MdiParent = this.MdiParent;
                            frmUrun.Show();
                            Close();
                        }
                    }
                    catch (ExistsException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(errorMessage + " : " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Barkodu tam giriniz.");
                }
            }
        }
    }
}
