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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            FrmKayit frmKayit = new FrmKayit();
            frmKayit.FormClosing += FrmKayit_FormClosing;
            frmKayit.Show();
            Hide();
        }

        private void FrmKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            KullaniciGirisDTO kullaniciGirisDTO = new KullaniciGirisDTO
            {
                KullaniciAdi = txtKullanici.Text,
                Sifre = UsefulMethods.GetSHA256(txtSifre.Text)
        };

            txtKullanici.Text = "";
            txtSifre.Text = "";

            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                KullaniciGirisSonucDTO kullanici = kullaniciDAL.CheckLoginExists(kullaniciGirisDTO);

                if (kullanici == null)
                    MessageBox.Show("Böyle bir kullanıcı yok.");
                else
                {
                    if(kullanici.RolId == Commons.Rols.Normal || kullanici.RolId == Commons.Rols.Premium)
                    {
                        FrmMainUser frmMainUser = new FrmMainUser(this);
                        frmMainUser.Show();
                    }
                    else
                    {
                        FrmMainAdmin frmMainAdmin = new FrmMainAdmin(this);
                        frmMainAdmin.Show();
                    }

                    ClientVariables.LoggedInUserId = kullanici.Id;

                    Hide();
                }
            }
            catch(ExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında bir hata oluştu:\n" + ex.Message);
            }
        }
    }
}
