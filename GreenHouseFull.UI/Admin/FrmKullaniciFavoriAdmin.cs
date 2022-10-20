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

namespace GreenHouseFull.UI.Admin
{
    public partial class FrmKullaniciFavoriAdmin : Form
    {
        int kullaniciPrevIndex = -1;
        int listPrevIndex = -1;

        public FrmKullaniciFavoriAdmin()
        {
            InitializeComponent();

        }

        private void FrmKullaniciFavoriAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                listKullanici.Items.AddRange(kullaniciDAL.GetAllKullanici(ClientVariables.LoggedInUserId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcıları çekerken bir sorun oluştu. " + ex.Message);
            }

            ClearFormKullanici();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtListeAdi.Text == "" || txtListeAdi.Text.Length > 100)
            {
                MessageBox.Show("Liste adı boş yada 100 karakterden uzun olamaz");
                return;
            }

            if (listKullanici.SelectedIndex != -1 && listList.SelectedIndex == -1)
            {
                //Add
                try
                {
                    KullaniciSimpleListDTO kullaniciSimpleDTO = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                    KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();
                    FavoriListeSimpleListDTO result = kullaniciFavoriDAL.AddNewList(txtListeAdi.Text, kullaniciSimpleDTO.Id, ClientVariables.LoggedInUserId);

                    if (result != null)
                    {
                        MessageBox.Show("Liste eklendi.");
                        listList.Items.Add(result);
                        ClearFormListe();
                    }
                    else
                    {
                        MessageBox.Show("Liste eklenemedi..");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme esnasında bir sorun oluştu. " + ex.Message);
                }
            }
            else if (listKullanici.SelectedIndex != -1 && listList.SelectedIndex != -1)
            {
                //Update
                try
                {
                    FavoriListeSimpleListDTO listeSimpleDTO = listList.SelectedItem as FavoriListeSimpleListDTO;
                    listeSimpleDTO.ListeAdi = txtListeAdi.Text;

                    KullaniciSimpleListDTO kullaniciSimpleDTO = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                    KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();
                    bool result = kullaniciFavoriDAL.ListeAdiGuncelleAdmin(listeSimpleDTO.Id, kullaniciSimpleDTO.Id, txtListeAdi.Text, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Liste güncellendi.");
                        listList.Items[listList.SelectedIndex] = listeSimpleDTO;
                        ClearFormListe();
                    }
                    else
                    {
                        MessageBox.Show("Liste güncellenemedi.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme esnasında bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                FavoriListeSimpleListDTO listeSimpleDTO = listList.SelectedItem as FavoriListeSimpleListDTO;

                KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();
                bool result = kullaniciFavoriDAL.ListeSil(listeSimpleDTO.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Liste silindi.");
                    listList.Items.RemoveAt(listList.SelectedIndex);
                    ClearFormListe();
                }
                else
                {
                    MessageBox.Show("Liste silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void listKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrevIndex == listKullanici.SelectedIndex)
                ClearFormKullanici();
            else
            {
                kullaniciPrevIndex = listKullanici.SelectedIndex;

                try
                {
                    KullaniciSimpleListDTO kullaniciSimpleDTO = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                    if (kullaniciSimpleDTO != null)
                    {
                        KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();
                        List<FavoriListeSimpleListDTO> list = favoriDAL.GetUserFavoriteLists(kullaniciSimpleDTO.Id, ClientVariables.LoggedInUserId);

                        listList.Items.Clear();
                        ClearFormListe();

                        if(list != null)
                            listList.Items.AddRange(list.ToArray());

                        btnGonder.Enabled = true;
                        txtListeAdi.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı listelerini çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void listList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrevIndex == listList.SelectedIndex)
                ClearFormListe();
            else
            {
                listPrevIndex = listList.SelectedIndex;

                FavoriListeSimpleListDTO listeSimpleDTO = listList.SelectedItem as FavoriListeSimpleListDTO;

                if(listeSimpleDTO != null)
                {
                    txtListeAdi.Text = listeSimpleDTO.ListeAdi;

                    btnGonder.Text = "Seçileni güncelle";
                    btnSil.Enabled = true;
                }
            }
        }

        void ClearFormKullanici()
        {
            ClearFormListe();

            kullaniciPrevIndex = -1;
            listKullanici.SelectedIndex = -1;

            listList.Items.Clear();

            btnGonder.Enabled = false;
            txtListeAdi.Enabled = false;
        }

        void ClearFormListe()
        {
            listPrevIndex = -1;
            listList.SelectedIndex = -1;

            txtListeAdi.Text = "";

            btnGonder.Text = "Liste Ekle";
            btnSil.Enabled = false;
        }
    }
}
