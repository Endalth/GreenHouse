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
    public partial class FrmMainUser : Form
    {
        private FrmLogin loginScreen;
        private bool logout;

        public FrmMainUser(FrmLogin loginScreen)
        {
            InitializeComponent();
            this.loginScreen = loginScreen;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            logout = true;
            Close();
        }

        private void FrmMainUser_FormClosing(object sender, FormClosingEventArgs e)
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }

        }
    }
}
