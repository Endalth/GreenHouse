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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GreenHouseFull.UI.Admin
{
    public partial class FrmKullaniciAdmin : Form
    {
        int prevIndex = -1;

        public FrmKullaniciAdmin()
        {
            InitializeComponent();
        }

        private void FrmKullaniciAdmin_Load(object sender, EventArgs e)
        {
            string[] rols = Enum.GetNames(typeof(Commons.Rols));

            foreach (string rol in rols)
                cbxRol.Items.Add(rol);

            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                List<KullaniciEmailRolDTO> kullaniciEmailRolDTOs = kullaniciDAL.GetKullaniciListWithEmailAndRols(ClientVariables.LoggedInUserId);

                listBKullanici.Items.AddRange(kullaniciEmailRolDTOs.ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kullanıcıları yüklerken bir sorun oluştu. " + ex.Message);
            }

            ClearForm();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            List<string> errorMessages = new List<string>();
            CheckKullaniciAdi(errorMessages, txtKullaniciAdi.Text);
            CheckEmail(errorMessages, txtEmail.Text);

            try
            {
                if (listBKullanici.SelectedIndex == -1)
                {
                    //Add
                    CheckSifre(errorMessages, txtPassNewUser.Text);
                    if (errorMessages.Count > 0)
                    {
                        MessageBox.Show(string.Join("\n", errorMessages));
                        return;
                    }

                    KullaniciKayitDTO kullaniciKayitDTO = new KullaniciKayitDTO()
                    {
                        KullaniciAdi = txtKullaniciAdi.Text,
                        Email = txtEmail.Text,
                        Sifre = UsefulMethods.GetSHA256(txtPassNewUser.Text),
                        RolId = (Commons.Rols)(cbxRol.SelectedIndex + 1)
                    };

                    KullaniciDAL kullaniciDAL = new KullaniciDAL();

                    KullaniciEmailRolDTO kullaniciEmailRolDTO = kullaniciDAL.KullaniciEkleAdmin(kullaniciKayitDTO, ClientVariables.LoggedInUserId);

                    if (kullaniciEmailRolDTO != null)
                    {
                        MessageBox.Show("Kullanıcı eklendi.");
                        listBKullanici.Items.Add(kullaniciEmailRolDTO);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı eklenemedi.");
                    }

                }
                else
                {
                    //Update
                    if (errorMessages.Count > 0)
                    {
                        MessageBox.Show(string.Join("\n", errorMessages));
                        return;
                    }

                    KullaniciEmailRolDTO kullaniciEmailRolDTO = listBKullanici.SelectedItem as KullaniciEmailRolDTO;

                    kullaniciEmailRolDTO.KullaniciAdi = txtKullaniciAdi.Text;
                    kullaniciEmailRolDTO.Email = txtEmail.Text;
                    kullaniciEmailRolDTO.RolId = (Commons.Rols)(cbxRol.SelectedIndex + 1);

                    KullaniciDAL kullaniciDAL = new KullaniciDAL();

                    bool result = kullaniciDAL.KullaniciGuncelleAdmin(kullaniciEmailRolDTO, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Kullanıcı güncellendi.");
                        listBKullanici.SelectedItem = kullaniciEmailRolDTO;

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı güncellenemedi.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();

                KullaniciEmailRolDTO selectedUser = listBKullanici.SelectedItem as KullaniciEmailRolDTO;

                bool result = kullaniciDAL.KullaniciSilAdmin(selectedUser.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Kullanıcı silindi.");
                    listBKullanici.Items.RemoveAt(listBKullanici.SelectedIndex);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme yapılamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnNewPass_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtPassRepeat.Text)
            {
                MessageBox.Show("Şifreler aynı olmalıdır");
                return;
            }

            List<string> errorMessages = new List<string>();
            CheckSifre(errorMessages, txtPass.Text);
            if (errorMessages.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errorMessages));
                return;
            }

            string sha256Pass = UsefulMethods.GetSHA256(txtPass.Text);

            KullaniciEmailRolDTO selectedUser = listBKullanici.SelectedItem as KullaniciEmailRolDTO;

            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                bool result = kullaniciDAL.AdminChangePasswordFor(sha256Pass, selectedUser.Id, ClientVariables.LoggedInUserId);

                if(result)
                {
                    MessageBox.Show("Şifre güncellendi.");

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Şifre güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu." + ex.Message);
            }
        }

        private void listBKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevIndex == listBKullanici.SelectedIndex)
            {
                ClearForm();
            }
            else
            {
                prevIndex = listBKullanici.SelectedIndex;

                KullaniciEmailRolDTO selectedUser = listBKullanici.SelectedItem as KullaniciEmailRolDTO;
                if (selectedUser != null)
                {
                    txtKullaniciAdi.Text = selectedUser.KullaniciAdi;
                    txtEmail.Text = selectedUser.Email;
                    //int index = cbxRol.FindStringExact(selectedUser.RolId.ToString());
                    cbxRol.SelectedIndex = ((int)selectedUser.RolId) - 1;
                }
                btnGonder.Text = "Seçileni Güncelle";
                btnSil.Enabled = true;

                txtPass.Enabled = true;
                txtPassRepeat.Enabled = true;
                btnNewPass.Enabled = true;

                txtPassNewUser.Text = "";
                txtPassNewUser.Enabled = false;
            }
        }

        private void ClearForm()
        {
            prevIndex = -1;

            listBKullanici.SelectedIndex = -1;
            txtKullaniciAdi.Text = "";
            txtEmail.Text = "";
            txtPassNewUser.Text = "";
            txtPassNewUser.Enabled = true;

            btnGonder.Text = "Ekle";
            btnSil.Enabled = false;

            txtPass.Text = "";
            txtPass.Enabled = false;
            txtPassRepeat.Text = "";
            txtPassRepeat.Enabled = false;
            btnNewPass.Enabled = false;

            cbxRol.SelectedIndex = 0;
        }

        private void CheckKullaniciAdi(List<string> errorMessages, string kullaniciAdi)
        {
            //Karakter limit
            if (kullaniciAdi.Length == 0 || kullaniciAdi.Length > 100)
            {
                errorMessages.Add("Kullanıcı Adı uzunluğu 0dan büyük ve 100den küçük olmalı");
            }

            if (kullaniciAdi.Contains(" "))
            {
                errorMessages.Add("Kullanıcı Adı boşluk içeremez.");
            }
        }

        private void CheckSifre(List<string> errorMessages, string sifre)
        {
            //Karakter limit
            if (sifre.Length == 0 || sifre.Length > 100)
            {
                errorMessages.Add("Şifre uzunluğu 0dan büyük ve 100den küçük olmalı");
            }

            if (sifre.Contains(" "))
            {
                errorMessages.Add("Şifre boşluk içeremez.");
            }
        }

        private void CheckEmail(List<string> errorMessages, string email)
        {
            // Email format
            Match emailFormatCheck = Regex.Match(email, @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");
            if (!emailFormatCheck.Success)
            {
                errorMessages.Add("Email formatı yanlış sadece harf, rakam yada \"-\", \"_\", \".\" karakterlerini kullanabilirsiniz. Örnek: ornek@email.com");
            }
        }
    }
}
