using GreenHouseFull.Common;
using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.UI.Dialog_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI
{
    public partial class FrmUrun : Form
    {
        bool alphabeticOrdering = false;
        UrunIcerikUrunListeDTO[] icerikListInRiskSeviyeOrder = null;
        UrunIcerikUrunListeDTO[] icerikListInAlphabeticOrder = null;
        Color[] textColorsByRiskSeviye;

        UrunDTO urunDTO;
        public FrmUrun(UrunDTO urunDTO)
        {
            InitializeComponent();
            this.urunDTO = urunDTO;
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;

            textColorsByRiskSeviye = ClientVariables.textColorsByRiskSeviye;

            lblKategori.Text = urunDTO.KategoriAdi;
            lblUretici.Text = urunDTO.UreticiAdi;
            lblUrunAdi.Text = urunDTO.Adi;
            lblUrunuEkleyen.Text += urunDTO.KullaniciAdi;
            lblKara.Text += urunDTO.IcerikList.Where(x => x.KaraListede).Count();
            lblRisk.Text += urunDTO.IcerikList.Where(x => x.RiskSeviyeId == Commons.RiskSeviye.Riskli).Count();
            lblOrtaRisk.Text += urunDTO.IcerikList.Where(x => x.RiskSeviyeId == Commons.RiskSeviye.Orta_Riskli).Count();
            lblAzRisk.Text += urunDTO.IcerikList.Where(x => x.RiskSeviyeId == Commons.RiskSeviye.Az_Riskli).Count();
            lblTemiz.Text += urunDTO.IcerikList.Where(x => x.RiskSeviyeId == Commons.RiskSeviye.Temiz).Count();

            //Bilesenler
            icerikListInRiskSeviyeOrder = urunDTO.IcerikList.OrderByDescending(x => x.KaraListede).ThenByDescending(x => x.RiskSeviyeId).ToArray();
            CreateListViewBilesen(icerikListInRiskSeviyeOrder);

            if (urunDTO.OnYuz != null)
            {
                ChangeImage(urunDTO.OnYuz);

                btnOnResim.Enabled = false;
            }
            else if (urunDTO.ArkaYuz != null)
            {
                ChangeImage(urunDTO.ArkaYuz);

                btnArkaResim.Enabled = false;
            }

            if (urunDTO.OnYuz == null)
                btnOnResim.Enabled = false;
            if (urunDTO.ArkaYuz == null)
                btnArkaResim.Enabled = false;
            if (urunDTO.Favoride)
                btnFavoriyeEkle.Enabled = false;
        }

        private void btnOnResim_Click(object sender, EventArgs e)
        {
            ChangeImage(urunDTO.OnYuz);

            btnOnResim.Enabled = false;

            if (urunDTO.ArkaYuz != null)
                btnArkaResim.Enabled = true;
        }

        private void btnArkaResim_Click(object sender, EventArgs e)
        {
            ChangeImage(urunDTO.ArkaYuz);

            if (urunDTO.OnYuz != null)
                btnOnResim.Enabled = true;
            btnArkaResim.Enabled = false;
        }

        private void ChangeImage(byte[] imageBytes)
        {
            Image picBoxImage;

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                picBoxImage = Image.FromStream(ms);
            }

            picBox.Image = picBoxImage;
        }

        private void listVBilesen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UrunIcerikUrunListeDTO urunIcerikDTO = listVBilesen.SelectedItems[0].Tag as UrunIcerikUrunListeDTO;
            try
            {
                UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();

                UrunSimpleListDTO urunSimpleListDTO = new UrunSimpleListDTO();
                urunSimpleListDTO.Id = urunDTO.Id;
                urunSimpleListDTO.Adi = urunDTO.Adi;

                FrmIcerik frmIcerik = new FrmIcerik(urunIcerikDAL.GetIcerikDTOById(urunIcerikDTO.Id, ClientVariables.LoggedInUserId), urunDTO);
                frmIcerik.MdiParent = this.MdiParent;
                frmIcerik.Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("İçerik bilgilrini alırken bir hata oluştu. " + ex.Message);
            }
        }

        private void btnDuzeltmeTalep_Click(object sender, EventArgs e)
        {
            FrmUrunDuzeltmeTalepAc frmUrun = new FrmUrunDuzeltmeTalepAc(new UrunSimpleListDTO()
            {
                Id = urunDTO.Id,
                Adi = urunDTO.Adi
            });
            frmUrun.MdiParent = this.MdiParent;
            frmUrun.Show();
            Close();
        }

        private void btnFavoriyeEkle_Click(object sender, EventArgs e)
        {
            FrmSelectListDialog frmSelectListDialog = new FrmSelectListDialog();

            if (frmSelectListDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();
                    bool result = kullaniciFavoriDAL.UrunuFavoriyeEkle(frmSelectListDialog.SelectedListId, urunDTO.Id, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Ürün favoriye eklendi.");
                        btnFavoriyeEkle.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ürün favoriye eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void btnOrdering_Click(object sender, EventArgs e)
        {
            ChangeOrdering();
        }

        void ChangeOrdering()
        {
            if (alphabeticOrdering)
            {
                CreateListViewBilesen(icerikListInRiskSeviyeOrder);

                btnOrdering.Text = "Alfabetik Sıralama";
                alphabeticOrdering = false;
            }
            else
            {
                if (icerikListInAlphabeticOrder == null)
                    icerikListInAlphabeticOrder = icerikListInRiskSeviyeOrder.OrderBy(x => x.Adi).ToArray();

                CreateListViewBilesen(icerikListInAlphabeticOrder);

                btnOrdering.Text = "Risk Seviyesine Göre Sıralama";
                alphabeticOrdering = true;
            }
        }

        void CreateListViewBilesen(UrunIcerikUrunListeDTO[] icerikList)
        {
            listVBilesen.Items.Clear();

            for (int i = 0; i < icerikList.Length; i++)
            {
                ListViewItem listViewItem = new ListViewItem(icerikList[i].ToString());
                listViewItem.Tag = icerikList[i];

                listViewItem.Font = new Font(listViewItem.Font, FontStyle.Bold);
                listViewItem.ForeColor = icerikList[i].KaraListede ? Color.Black : textColorsByRiskSeviye[(int)icerikList[i].RiskSeviyeId];
                listVBilesen.Items.Add(listViewItem);
            }
        }
    }
}
