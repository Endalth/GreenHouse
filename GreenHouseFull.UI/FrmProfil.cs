using GreenHouseFull.Common;
using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using GreenHouseFull.UI.Dialog_Forms;
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
    public partial class FrmProfil : Form
    {
        ProfilDTO profilDTO;
        public FrmProfil(ProfilDTO profilDTO)
        {
            InitializeComponent();
            this.profilDTO = profilDTO;
        }

        private void FrmProfil_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsername.Text = profilDTO.KullaniciAdi;
                lblRegisterDate.Text += profilDTO.KayitTarihi.Day + "/" + profilDTO.KayitTarihi.Month + "/" + profilDTO.KayitTarihi.Year;
                lblUrunSayisi.Text += profilDTO.UrunSayisi;

                btnPremium.Enabled = profilDTO.RolId == Commons.Rols.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgilerini çekerken bir hata oluştu. " + ex.Message);
                Hide();
            }

        }

        private void btnPremium_Click(object sender, EventArgs e)
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            try
            {
                bool result = kullaniciDAL.GoPremium(ClientVariables.LoggedInUserId);

                if (result)
                {
                    btnPremium.Enabled = false;
                    MessageBox.Show("Premium üye oldunuz.");
                }
                else
                {
                    MessageBox.Show("Üyelik değiştirilemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGetNewEmailDialog frmGetValueDialog = new FrmGetNewEmailDialog();

                if (frmGetValueDialog.ShowDialog() == DialogResult.OK)
                {
                    KullaniciDAL kullaniciDAL = new KullaniciDAL();
                    bool result = kullaniciDAL.ChangeEmail(frmGetValueDialog.NewEmail, ClientVariables.LoggedInUserId);
                    if (result)
                        MessageBox.Show("Email adresi değiştirildi.");
                    else
                        MessageBox.Show("Email adresi değiştirilemedi.");
                }
            }
            catch (SameValueException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGetNewPasswordDialog frmGetValueDialog = new FrmGetNewPasswordDialog();

                if (frmGetValueDialog.ShowDialog() == DialogResult.OK)
                {
                    KullaniciDAL kullaniciDAL = new KullaniciDAL();
                    bool result = kullaniciDAL.ChangePassword(frmGetValueDialog.YeniSifre, ClientVariables.LoggedInUserId);
                    if (result)
                        MessageBox.Show("Şire değiştirildi.");
                    else
                        MessageBox.Show("Şifre değiştirilemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnCleanHistory_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciGecmisAramaDAL gecmisAramaDAL = new KullaniciGecmisAramaDAL();
                bool result = gecmisAramaDAL.EraseSearchHistory(ClientVariables.LoggedInUserId);
                if (result)
                    MessageBox.Show("Geçmiş temizlendi.");
                else
                    MessageBox.Show("Geçmiş temizlenemedi.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Geçmişi silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void lblUrunSayisi_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                FrmKullaniciUrunList frmKullaniciUrunList = new FrmKullaniciUrunList(kullaniciDAL.GetProductsBelongingToTheUserWithStatus(ClientVariables.LoggedInUserId));
                frmKullaniciUrunList.MdiParent = this.MdiParent;
                frmKullaniciUrunList.Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ürünleri çekerken bir sorun oluştu. " + ex.Message);
            }
        }
    }
}
