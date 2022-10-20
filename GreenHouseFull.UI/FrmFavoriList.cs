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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GreenHouseFull.UI
{
    public partial class FrmFavoriList : Form
    {
        int prevListIndex = -1;
        public FrmFavoriList()
        {
            InitializeComponent();
        }

        private void FrmFavoriList_Load(object sender, EventArgs e)
        {
            ClearFormList();

            try
            {
                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                List<FavoriListeSimpleListDTO> favoriteLists = favoriDAL.GetUserFavoriteLists(ClientVariables.LoggedInUserId);

                if (favoriteLists != null)
                    listBFavoriList.Items.AddRange(favoriteLists.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleri çekerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            if (txtNewListName.Text == "")
            {
                MessageBox.Show("Liste adı boş olamaz");
                return;
            }
            else if(txtNewListName.Text.Length > 100)
            {
                MessageBox.Show("Liste adı 100 karakterden uzun olamaz");
                return;
            }

            try
            {
                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                if (listBFavoriList.SelectedIndex == -1)
                {
                    //Add
                    FavoriListeSimpleListDTO result = favoriDAL.AddNewList(txtNewListName.Text, ClientVariables.LoggedInUserId);
                    
                    if (result != null)
                    {
                        MessageBox.Show("Liste eklendi.");

                        listBFavoriList.Items.Add(result);
                        txtNewListName.Text = "";

                        ClearFormList();
                    }
                    else
                    {
                        MessageBox.Show("Liste eklenemedi.");
                    }
                }
                else
                {
                    //Update
                    FavoriListeSimpleListDTO selectedList = listBFavoriList.SelectedItem as FavoriListeSimpleListDTO;
                    selectedList.ListeAdi = txtNewListName.Text;

                    bool result = favoriDAL.ListeAdiGuncelleAdmin(selectedList.Id, ClientVariables.LoggedInUserId, txtNewListName.Text);

                    if (result)
                    {
                        MessageBox.Show("Liste adı güncellendi.");

                        int index = listBFavoriList.SelectedIndex;
                        ClearFormList();

                        listBFavoriList.Items[index] = selectedList;

                    }
                    else
                    {
                        MessageBox.Show("Liste adı güncellenemedi.");
                    }
                }

            }
            catch (ExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. " + ex.Message);
            }
        }

        private void btnListeSil_Click(object sender, EventArgs e)
        {
            try
            {
                FavoriListeSimpleListDTO selectedList = listBFavoriList.SelectedItem as FavoriListeSimpleListDTO;

                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                bool result = favoriDAL.ListeSil(selectedList.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Liste silindi.");

                    listBFavoriList.Items.RemoveAt(listBFavoriList.SelectedIndex);

                    ClearFormList();
                }
                else
                {
                    MessageBox.Show("Liste silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnUrunKaldir_Click(object sender, EventArgs e)
        {
            try
            {
                FavoriListeSimpleListDTO selectedList = listBFavoriList.SelectedItem as FavoriListeSimpleListDTO;
                UrunSimpleListDTO selectedUrun = listBUrun.SelectedItem as UrunSimpleListDTO;

                KullaniciFavoriDAL favoriDAL = new KullaniciFavoriDAL();

                bool result = favoriDAL.ListedenUrunKaldir(selectedList.Id, selectedUrun.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Ürün listeden kaldırıldı.");

                    listBUrun.Items.RemoveAt(listBUrun.SelectedIndex);

                    ClearFormUrun();
                }
                else
                {
                    MessageBox.Show("Ürün listeden kaldırılamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünü kaldırırken bir sorun oluştu. " + ex.Message);
            }
        }

        private void listBFavoriList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevListIndex == listBFavoriList.SelectedIndex)
                ClearFormList();
            else
            {
                ClearFormUrun();
                prevListIndex = listBFavoriList.SelectedIndex;
                listBUrun.Items.Clear();

                FavoriListeSimpleListDTO selectedList = listBFavoriList.SelectedItem as FavoriListeSimpleListDTO;

                KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();

                listBUrun.Items.AddRange(kullaniciFavoriDAL.GetProductsBelongingToList(selectedList.Id, ClientVariables.LoggedInUserId).ToArray());

                txtNewListName.Text = selectedList.ListeAdi;
                btnNewList.Text = "Seçili Listenin Adını Güncelle";
                btnListeSil.Enabled = true;
            }
        }

        private void listBUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBUrun.SelectedIndex != -1)
            {
                btnUrunKaldir.Enabled = true;
            }
            else
            {
                ClearFormUrun();
            }
        }

        private void listBUrun_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBUrun.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                UrunSimpleListDTO selectedProduct = listBUrun.SelectedItem as UrunSimpleListDTO;
                try
                {
                    UrunDAL urunDAL = new UrunDAL();
                    UrunDTO urunDTO = urunDAL.GetUrunDTO(selectedProduct.Id, ClientVariables.LoggedInUserId);

                    FrmUrun frmUrun = new FrmUrun(urunDTO);
                    frmUrun.MdiParent = this.MdiParent;
                    frmUrun.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir sorun oluştu. " + ex.Message);
                }
            }
        }

        void ClearFormList()
        {
            ClearFormUrun();

            prevListIndex = -1;
            listBFavoriList.SelectedIndex = -1;
            listBUrun.Items.Clear();
            btnListeSil.Enabled = false;
            btnNewList.Text = "Yeni Liste Ekle";
            txtNewListName.Text = "";
        }

        void ClearFormUrun()
        {
            btnUrunKaldir.Enabled = false;
        }
    }
}
