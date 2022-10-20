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
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            KullaniciKayitDTO kullaniciKayitDTO = new KullaniciKayitDTO{ 
                KullaniciAdi = txtKullanici.Text,
                Sifre = UsefulMethods.GetSHA256(txtSifre.Text),
                Email = txtEmail.Text
            };

            txtKullanici.Text = "";
            txtSifre.Text = "";
            txtEmail.Text = "";

            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                bool result = kullaniciDAL.UserRegister(kullaniciKayitDTO);

                if (result)
                    MessageBox.Show("Kayıt Başarılı.");
                else
                    MessageBox.Show("Kayıt Başarısız.");
            }
            catch(ModelNotValidException ex)
            {
                MessageBox.Show(string.Join("\n", ex.ValidationMessages));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu:\n" + ex.Message);
            }
        }
    }
}
