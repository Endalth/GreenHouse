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

namespace GreenHouseFull.UI.Admin
{
    public partial class FrmKategoriAdmin : Form
    {
        string noCategoryAbove = "Üst Kategori Yok";
        List<KategoriWithUstDTO> kategoriWithUstDTOs;
        public FrmKategoriAdmin()
        {
            InitializeComponent();
        }

        private void FrmKategoriAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                KategoriDAL kategoriDAL = new KategoriDAL();
                kategoriWithUstDTOs = kategoriDAL.GetAllKategoriWithUsts(ClientVariables.LoggedInUserId);

                cbxUstKategori.Items.Add("Boş");
                cbxUstKategori.SelectedIndex = 0;

                lvKategori.Columns.Add("Kategori Adı");
                lvKategori.Columns[0].Width = 100;
                lvKategori.Columns.Add("Üst Kategori Adı");
                lvKategori.Columns[1].Width = 100;

                for (int i = 0; i < kategoriWithUstDTOs.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(kategoriWithUstDTOs[i].Name);
                    if (kategoriWithUstDTOs[i].UstName == null)
                        listViewItem.SubItems.Add(noCategoryAbove);
                    else
                        listViewItem.SubItems.Add(kategoriWithUstDTOs[i].UstName);

                    listViewItem.Tag = kategoriWithUstDTOs[i];

                    lvKategori.Items.Add(listViewItem);

                    cbxUstKategori.Items.Add(new KategoriSimpleListDTO()
                    {
                        Id = kategoriWithUstDTOs[i].KategoriId,
                        Adi = kategoriWithUstDTOs[i].Name
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategorileri çekerken bir sorun oluştu. " + ex.Message);
            }

            btnSil.Enabled = false;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text == "" || txtKategoriAdi.Text.Length > 100)
            {
                MessageBox.Show("Kategori adı boş veya 100 karakterden uzun olamaz");
                return;
            }

            KategoriDAL kategoriDAL = new KategoriDAL();
            if (lvKategori.SelectedItems.Count == 0)
            {
                try
                {
                    //Add
                    KategoriSimpleListDTO ustKat = null;
                    if (cbxUstKategori.SelectedIndex != 0)
                        ustKat = cbxUstKategori.SelectedItem as KategoriSimpleListDTO;

                    KategoriWithUstDTO newKategori = kategoriDAL.KategoriEkleAdmin(txtKategoriAdi.Text, ustKat, ClientVariables.LoggedInUserId);

                    if (newKategori != null)
                    {
                        MessageBox.Show("Kategori eklendi.");

                        ListViewItem listViewItem = new ListViewItem(newKategori.Name);
                        if (newKategori.UstName == null)
                            listViewItem.SubItems.Add("Üst Kategori Yok");
                        else
                            listViewItem.SubItems.Add(newKategori.UstName);

                        listViewItem.Tag = newKategori;

                        lvKategori.Items.Add(listViewItem);

                        cbxUstKategori.Items.Add(new KategoriSimpleListDTO
                        {
                            Id = newKategori.KategoriId,
                            Adi = newKategori.Name
                        });

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Kategori eklenemedi.");
                    }
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
            else
            {
                //Update
                try
                {
                    KategoriSimpleListDTO categoryAbove = null;
                    if (cbxUstKategori.SelectedIndex != 0)
                        categoryAbove = cbxUstKategori.SelectedItem as KategoriSimpleListDTO;

                    KategoriWithUstDTO selectedCategoryWithUpdates = lvKategori.SelectedItems[0].Tag as KategoriWithUstDTO;

                    if (categoryAbove != null)
                    {
                        if (selectedCategoryWithUpdates.KategoriId == categoryAbove.Id)
                        {
                            MessageBox.Show("Kategori ve Üst kategori aynı olamaz.");
                            return;
                        }
                    }

                    selectedCategoryWithUpdates.Name = txtKategoriAdi.Text;
                    selectedCategoryWithUpdates.UstName = categoryAbove == null ? null : categoryAbove.Adi;

                    KategoriSimpleListDTO updatedName = new KategoriSimpleListDTO()
                    {
                        Id = selectedCategoryWithUpdates.KategoriId,
                        Adi = selectedCategoryWithUpdates.Name
                    };

                    bool result = kategoriDAL.KategoriGuncelleAdmin(updatedName, categoryAbove?.Id, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Kategori güncellendi.");

                        int i = cbxUstKategori.FindStringExact(lvKategori.SelectedItems[0].Text);
                        cbxUstKategori.Items[i] = updatedName;

                        lvKategori.SelectedItems[0].Text = selectedCategoryWithUpdates.Name;
                        lvKategori.SelectedItems[0].SubItems[1].Text = selectedCategoryWithUpdates.UstName == null ? noCategoryAbove : selectedCategoryWithUpdates.UstName;

                        lvKategori.SelectedItems[0].Tag = selectedCategoryWithUpdates;


                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Kategori güncellenemedi.");
                    }
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
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                KategoriWithUstDTO kategoriWithUstDTO = lvKategori.SelectedItems[0].Tag as KategoriWithUstDTO;
                KategoriDAL kategoriDAL = new KategoriDAL();
                bool result = kategoriDAL.KategoriSilAdmin(kategoriWithUstDTO.KategoriId, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Kategori Silindi.");

                    lvKategori.Items.Remove(lvKategori.SelectedItems[0]);

                    int i = cbxUstKategori.FindStringExact(kategoriWithUstDTO.Name);
                    cbxUstKategori.Items.RemoveAt(i);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Kategori silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearForm()
        {
            lvKategori.SelectedIndices.Clear();
            cbxUstKategori.SelectedIndex = 0;
            txtKategoriAdi.Text = "";

            btnGonder.Text = "Ekle";
            btnSil.Enabled = false;
        }

        private void lvKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategori.SelectedIndices.Count == 0)
            {
                ClearForm();
            }
            else
            {
                KategoriWithUstDTO kategoriWithUstDTO = lvKategori.SelectedItems?[0].Tag as KategoriWithUstDTO;
                if (kategoriWithUstDTO != null)
                {
                    txtKategoriAdi.Text = kategoriWithUstDTO.Name;
                    if (kategoriWithUstDTO.UstName != null)
                    {
                        int i = cbxUstKategori.FindStringExact(kategoriWithUstDTO.UstName);
                        cbxUstKategori.SelectedIndex = i;
                    }
                    else
                        cbxUstKategori.SelectedIndex = 0;
                }

                btnGonder.Text = "Seçileni Güncelle";
                btnSil.Enabled = true;
            }
        }
    }
}
