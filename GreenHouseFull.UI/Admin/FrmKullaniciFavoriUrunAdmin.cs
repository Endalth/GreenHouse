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
    public partial class FrmKullaniciFavoriUrunAdmin : Form
    {
        public FrmKullaniciFavoriUrunAdmin()
        {
            InitializeComponent();
        }

        private void FrmKullaniciFavoriUrunAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();

                listKullanici.Items.AddRange(kullaniciDAL.GetAllKullanici(ClientVariables.LoggedInUserId).ToArray());

                UrunDAL urunDAL = new UrunDAL();

                cbxUrun.Items.AddRange(urunDAL.GetAllUrun(ClientVariables.LoggedInUserId).ToArray());

                if (cbxUrun.Items.Count > 0)
                    cbxUrun.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcıları yüklerken bir sorun oluştu. " + ex.Message);
            }


            cbxUrun.Enabled = false;
            btnEkle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cbxUrun.SelectedIndex == -1)
            {
                MessageBox.Show("Eklemek için ürün seçiniz.");
                return;
            }

            try
            {
                KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;
                FavoriListeSimpleListDTO selectedList = listList.SelectedItem as FavoriListeSimpleListDTO;
                UrunSimpleListDTO selectedUrun = cbxUrun.SelectedItem as UrunSimpleListDTO;

                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                bool result = favoriDAL.UrunuFavoriyeEkle(selectedList.Id, selectedUrun.Id, selectedUser.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Ürün listeye eklendi.");
                    listUrun.Items.Add(selectedUrun);
                }
                else
                {
                    MessageBox.Show("Ürün listeye eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeye ait ürünleri çekerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                FavoriListeSimpleListDTO selectedList = listList.SelectedItem as FavoriListeSimpleListDTO;
                UrunSimpleListDTO selectedUrun = listUrun.SelectedItem as UrunSimpleListDTO;

                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                bool result = favoriDAL.ListedenUrunKaldir(selectedList.Id, selectedUrun.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Ürün listeden silindi.");
                    listUrun.Items.RemoveAt(listUrun.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Ürün listeden silinemedi.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void listKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKullanici.SelectedIndex != -1)
            {
                try
                {
                    ClearFormKullanici();

                    KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                    KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                    List<FavoriListeSimpleListDTO> selectedUserLists = favoriDAL.GetUserFavoriteLists(selectedUser.Id, ClientVariables.LoggedInUserId);

                    if (selectedUserLists != null)
                        listList.Items.AddRange(selectedUserLists.ToArray());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcıya ait listeleri çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void listList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listList.SelectedIndex != -1)
            {
                try
                {
                    ClearFormList();

                    FavoriListeSimpleListDTO selectedList = listList.SelectedItem as FavoriListeSimpleListDTO;

                    KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                    listUrun.Items.AddRange(favoriDAL.GetProductsBelongingToList(selectedList.Id, ClientVariables.LoggedInUserId).ToArray());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeye ait ürünleri çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void listUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listList.SelectedIndex != -1)
            {
                btnSil.Enabled = true;
            }
        }

        void ClearFormKullanici()
        {
            ClearFormList();

            listList.Items.Clear();
            btnEkle.Enabled = false;
            cbxUrun.Enabled = false;
        }

        void ClearFormList()
        {
            listUrun.Items.Clear();
            btnEkle.Enabled = true;
            cbxUrun.Enabled = true;
            btnSil.Enabled = false;
        }
    }
}
