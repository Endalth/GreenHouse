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
    public partial class FrmIcerik : Form
    {
        private UrunIcerikDTO urunIcerikDTO;

        UrunDTO urunDTO;

        public FrmIcerik(UrunIcerikDTO urunIcerikDTO, UrunDTO urunDTO = null)
        {
            InitializeComponent();
            this.urunIcerikDTO = urunIcerikDTO;

            this.urunDTO = urunDTO;

            if (urunDTO == null)
                btnGoBack.Visible = false;
            else
                btnGoBack.Text = urunDTO.Adi + " Adlı Ürüne Geri Dön"; 
        }

        private void FrmIcerik_Load(object sender, EventArgs e)
        {
            lblIcerikAdi.ForeColor = ClientVariables.textColorsByRiskSeviye[(int)urunIcerikDTO.RiskSeviyeId];
            lblIcerikAdi.Text = urunIcerikDTO.Adi;
            lblKaraListe.Visible = urunIcerikDTO.KaraListede;
            lblUsedInCount.Text = "Bu içerik " + urunIcerikDTO.UsedInCount + " ürünün bileşenleri arasında yer almaktadır.";
            lblAciklama.Text = urunIcerikDTO.Aciklama;

            btnKaraListeyeEkle.Enabled = !urunIcerikDTO.KaraListede;
        }

        private void btnKaraListeyeEkle_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciKaraListeDAL karaListeDAL = new KullaniciKaraListeDAL();
                bool result = karaListeDAL.AddIcerikToKaraList(urunIcerikDTO.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("İçerik kara listeye eklendi.");
                    lblKaraListe.Visible = true;
                    btnKaraListeyeEkle.Enabled = false;

                    if (urunDTO != null)
                    {
                        UrunIcerikUrunListeDTO changeBlacklist = urunDTO.IcerikList.Find(x => x.Id == urunIcerikDTO.Id);
                        changeBlacklist.KaraListede = true;
                    }
                }
                else
                    MessageBox.Show("İçerik kara listeye eklenemedi.");
            }
            catch (ExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            if(urunDTO != null)
            {
                FrmUrun frmUrun = new FrmUrun(urunDTO);
                frmUrun.MdiParent = this.MdiParent;
                frmUrun.Show();
                Close();
            }
        }
    }
}
