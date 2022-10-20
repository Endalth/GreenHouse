using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.UI.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GreenHouseFull.UI
{
    public partial class FrmMainAdmin : Form
    {
        private FrmLogin loginScreen;
        private bool logout;

        public FrmMainAdmin(FrmLogin loginScreen)
        {
            InitializeComponent(); 
            this.loginScreen = loginScreen;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            logout = true;
            Close();
        }

        private void FrmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout)
                loginScreen.Show();
            else
                Application.Exit();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunAra frmUrunAra = new FrmUrunAra();
            frmUrunAra.MdiParent = this;
            frmUrunAra.Show();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunEkle frmUrunEkle = new FrmUrunEkle();
            frmUrunEkle.MdiParent = this;
            frmUrunEkle.Show();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRapor frmRapor = new FrmRapor();
            frmRapor.MdiParent = this;
            frmRapor.Show();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                ProfilDTO profilDTO = kullaniciDAL.GetProfil(ClientVariables.LoggedInUserId);
                FrmProfil frmProfil = new FrmProfil(profilDTO);
                frmProfil.MdiParent = this;
                frmProfil.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgilerini çekerken bir hata oluştu. " + ex.Message);
            }
        }

        private void aramaGecmisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciGecmisAramaDAL gecmisAramaDAL = new KullaniciGecmisAramaDAL();
                List<UrunSimpleListDTO> gecmisAramalar = gecmisAramaDAL.GetUserSearchHistory(ClientVariables.LoggedInUserId);

                FrmGecmisAramalar frmGecmisAramalar = new FrmGecmisAramalar(gecmisAramalar);
                frmGecmisAramalar.MdiParent = this;
                frmGecmisAramalar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void favorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFavoriList frmFavoriList = new FrmFavoriList();
            frmFavoriList.MdiParent = this;
            frmFavoriList.Show();
        }

        private void karaListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciKaraListeDAL kullaniciKaraListeDAL = new KullaniciKaraListeDAL();
                List<UrunIcerikSimpleListDTO> icerikListDTO = kullaniciKaraListeDAL.GetKullaniciKaraListe(ClientVariables.LoggedInUserId);

                FrmKaraListe frmKaraListe = new FrmKaraListe(icerikListDTO);
                frmKaraListe.MdiParent = this;
                frmKaraListe.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        } 

        private void ureticiAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUreticiAdmin frmUreticiAdmin = new FrmUreticiAdmin();
            frmUreticiAdmin.MdiParent = this;
            frmUreticiAdmin.Show();
        }

        private void kategoriAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKategoriAdmin frmKategoriAdmin = new FrmKategoriAdmin();
            frmKategoriAdmin.MdiParent = this;
            frmKategoriAdmin.Show();
        }

        private void kullaniciAdminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmKullaniciAdmin frmKullaniciAdmin = new FrmKullaniciAdmin();
            frmKullaniciAdmin.MdiParent = this;
            frmKullaniciAdmin.Show();
        }

        private void urunIcerikAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunIcerikAdmin frmUrunIcerikAdmin = new FrmUrunIcerikAdmin();
            frmUrunIcerikAdmin.MdiParent = this;
            frmUrunIcerikAdmin.Show();
        }

        private void urunAdminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmUrunAdmin frmUrunAdmin = new FrmUrunAdmin();
            frmUrunAdmin.MdiParent = this;
            frmUrunAdmin.Show();
        }

        private void urunDuzeltmeTalepleriAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunDuzeltmeTalepAdmin frmUrunDuzeltmeTalepAdmin = new FrmUrunDuzeltmeTalepAdmin();
            frmUrunDuzeltmeTalepAdmin.MdiParent = this;
            frmUrunDuzeltmeTalepAdmin.Show();
        }

        private void urunOnaylamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunOnayAdmin frmUrunOnay = new FrmUrunOnayAdmin();
            frmUrunOnay.MdiParent = this;
            frmUrunOnay.Show();
        }

        private void kullaniciFavoriListeAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKullaniciFavoriAdmin frmKullaniciFavoriAdmin = new FrmKullaniciFavoriAdmin();
            frmKullaniciFavoriAdmin.MdiParent = this;
            frmKullaniciFavoriAdmin.Show();
        }

        private void kullaniciGecmisAramaAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKullaniciGecmisAdmin frmKullaniciGecmisAdmin = new FrmKullaniciGecmisAdmin();
            frmKullaniciGecmisAdmin.MdiParent = this;
            frmKullaniciGecmisAdmin.Show();
        }

        private void kullaniciFavoriUrunAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKullaniciFavoriUrunAdmin frmKullaniciFavoriUrunAdmin = new FrmKullaniciFavoriUrunAdmin();
            frmKullaniciFavoriUrunAdmin.MdiParent = this;
            frmKullaniciFavoriUrunAdmin.Show();
        }

        private void kullaniciKaraListeAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKullaniciKaraListeAdmin frmKullaniciKaraListeAdmin = new FrmKullaniciKaraListeAdmin();
            frmKullaniciKaraListeAdmin.MdiParent = this;
            frmKullaniciKaraListeAdmin.Show();
        }

        
    }
}
