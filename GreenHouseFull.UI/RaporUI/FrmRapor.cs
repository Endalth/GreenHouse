using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.DTO.RaporDTOs;
using GreenHouseFull.UI.RaporUI;
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
    public partial class FrmRapor : Form
    {
        RaporDAL raporDAL = new RaporDAL();
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void btnUrunIcerikAdet_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunUrunIcerikAdetDTO> dto = raporDAL.GetAllUrunUrunIcerikAdetRapor(ClientVariables.LoggedInUserId);
                if (dto.Count > 0)
                    OpenDataGridViewRapor("Ürünlerin İçerik Adetleri Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnIcerikKullananUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGetValueDialog frmGetValueDialog = new FrmGetValueDialog("Kullanan ürünleri öğrenmek istediğiniz içeriğin adını giriniz:");
                if (frmGetValueDialog.ShowDialog() == DialogResult.OK)
                {
                    List<UrunIcerikKullananUrunlerDTO> dto = raporDAL.GetUrunIcerikKullananlarRapor(frmGetValueDialog.ReturnValue, ClientVariables.LoggedInUserId);

                    if (dto.Count > 0)
                    {
                        FrmSimpleListViewRapor frmSimpleListViewRapor = new FrmSimpleListViewRapor("Girilen İçeriği Kullanan Ürünler Raporu", dto);
                        frmSimpleListViewRapor.MdiParent = this.MdiParent;
                        frmSimpleListViewRapor.FormClosing += ChildFormClosingTrigger;
                        frmSimpleListViewRapor.Show();
                        Hide();
                    }
                    else
                        MessageBox.Show("Rapor listesi boş.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKullaniciUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                List<KullaniciUrunGirisSayiDTO> dto = raporDAL.GetAllKullaniciUrunSayisi(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("Kullanıcıların ürün Ekleme Sayıları Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnBekleyenOnay_Click(object sender, EventArgs e)
        {
            try
            {
                int result = raporDAL.GetAylikBekleyenOnaylarRapor(ClientVariables.LoggedInUserId);

                MessageBox.Show("Bu ay yaratılan onay bekleyen ürün sayısı: " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnIcerikKaraListeSayi_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGetValueDialog frmGetValueDialog = new FrmGetValueDialog("Kara listeye alınma sayısını öğrenmek istediğiniz içeriğin adını giriniz:");
                if (frmGetValueDialog.ShowDialog() == DialogResult.OK)
                {
                    int deger = raporDAL.GetIcerikKaralisteSayi(frmGetValueDialog.ReturnValue, ClientVariables.LoggedInUserId);
                    MessageBox.Show(frmGetValueDialog.ReturnValue + " içeriğine ait kara listeye alınma sayısı: " + deger);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnRiskliUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunEnCokRiskSayilariDTO> dto = raporDAL.GetEnCokRiskUrunSayilari(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Riskli Ürünler Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnFavoriUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunFavoriSayiDTO> dto = raporDAL.GetAllUrunEnFavoriSayi(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Favori Ürünler Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnFavoriUrunlerIlk3_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunFavoriSayiDTO> dto = raporDAL.GetAllUrunEnFavoriSayiIlk3(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Favori İlk 3 Ürün Raporu", dto);

                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnAlerjenUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunAlerjenSayiDTO> dto = raporDAL.GetUrunAlerjenSayi(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Çok Alerjene Sahip Ürünler Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void tnEnAzRiskUrun_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunEnAzRiskSayilariFavoriDTO> dto = raporDAL.GetEnAzRiskUrunFavori(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Az Riskli Ürünler Raporu", dto);

                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnRiskliUrunKullanici_Click(object sender, EventArgs e)
        {
            try
            {
                List<KullaniciRiskliUrunDTO> dto = raporDAL.GetKullaniciRiskliUrunTop3(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Çok Riskli Ürüne Sahip Kullanıcılar Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKullanıcıEnCokUrun_Click(object sender, EventArgs e)
        {
            try
            {
                List<KullaniciEnCokUrunSayisiDTO> dto = raporDAL.GetEnCokUrunKullaniciAdiEmailTop5(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("En Çok Ürün Eklemiş Kullanıcılar Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnEnAzMaddeUrun_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunIcerikSayilariDTO> dto = raporDAL.GetUrunIcerikSayilarLast10(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                {
                    FrmSimpleListViewRapor frmSimpleListViewRapor = new FrmSimpleListViewRapor("En Az Madde İçeren Ürünler Raporu", dto);
                    frmSimpleListViewRapor.MdiParent = this.MdiParent;
                    frmSimpleListViewRapor.FormClosing += ChildFormClosingTrigger;
                    frmSimpleListViewRapor.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnAylikFavoriUrunler_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = raporDAL.GetAylikFavoriAlinanUrunler(ClientVariables.LoggedInUserId);

                if (list.Count > 0)
                {
                    FrmSimpleListViewRapor frmSimpleListViewRapor = new FrmSimpleListViewRapor("Aylk Favoriye Eklenmiş Ürünlerin Listesi Raporu", list);
                    frmSimpleListViewRapor.MdiParent = this.MdiParent;
                    frmSimpleListViewRapor.FormClosing += ChildFormClosingTrigger;
                    frmSimpleListViewRapor.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKullaniciFavoriSayi_Click(object sender, EventArgs e)
        {
            try
            {
                List<KullaniciFavoriUrunSayiDTO> dto = raporDAL.GetKullaniciFavoriSayi(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("Kullanıcıların Favori Ürün Sayıları Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKullaniciTipSayi_Click(object sender, EventArgs e)
        {
            try
            {
                List<KullaniciTipSayiDTO> dto = raporDAL.GetAllKullanciTipSayi(ClientVariables.LoggedInUserId);

                if (dto.Count > 0)
                    OpenDataGridViewRapor("Hangi Rolde Kaç Kullanıcı Raporu", dto);
                else
                    MessageBox.Show("Rapor listesi boş.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void OpenDataGridViewRapor(string formAdi, object dto)
        {
            FrmSimpleDataGridRapor frmDataGridRapor = new FrmSimpleDataGridRapor(formAdi, dto);
            frmDataGridRapor.MdiParent = this.MdiParent;
            frmDataGridRapor.FormClosing += ChildFormClosingTrigger;
            frmDataGridRapor.Show();
            Hide();
        }

        private void ChildFormClosingTrigger(object sender, FormClosingEventArgs e)
        {
            Show();
        }
    }
}
