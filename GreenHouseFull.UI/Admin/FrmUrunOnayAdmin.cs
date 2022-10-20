using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.UI.Dialog_Forms;
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
    public partial class FrmUrunOnayAdmin : Form
    {
        public FrmUrunOnayAdmin()
        {
            InitializeComponent();
        }

        private void FrmUrunOnay_Load(object sender, EventArgs e)
        {
            try
            {
                UrunOnayDurumDAL urunOnayDurumDAL = new UrunOnayDurumDAL();
                List<UrunOnayListDTO> onayListDTOs = urunOnayDurumDAL.GetUrunOnayList(ClientVariables.LoggedInUserId);

                if (onayListDTOs.Count != 0)
                {
                    lvUrunOnay.Columns.Add("Urun Adı");
                    lvUrunOnay.Columns[0].Width = 100;
                    lvUrunOnay.Columns.Add("Onay Durumu");
                    lvUrunOnay.Columns[1].Width = 100;
                    lvUrunOnay.Columns.Add("Açıklama");
                    lvUrunOnay.Columns[2].Width = 150;
                    lvUrunOnay.Columns.Add("Ürünü Ekleyen");
                    lvUrunOnay.Columns[3].Width = 100;
                }

                for (int i = 0; i < onayListDTOs.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(onayListDTOs[i].UrunAdi);
                    listViewItem.SubItems.Add(onayListDTOs[i].OnayDurumId.ToString().Replace("_", " "));
                    listViewItem.SubItems.Add(onayListDTOs[i].Aciklama);
                    listViewItem.SubItems.Add(onayListDTOs[i].UrunuEkleyen);
                    listViewItem.Tag = onayListDTOs[i];

                    lvUrunOnay.Items.Add(listViewItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. " + ex.Message);
            }
        }

        private void lvUrunOnay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UrunOnayListDTO urunOnayListDTO = (UrunOnayListDTO)lvUrunOnay.SelectedItems[0].Tag;

            FrmUrunOnayGuncelleDialog frmUrunOnayGuncelleDialog = new FrmUrunOnayGuncelleDialog(urunOnayListDTO.OnayDurumId, urunOnayListDTO.Aciklama);

            if (frmUrunOnayGuncelleDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UrunOnayListDTO selectedItem = (UrunOnayListDTO)lvUrunOnay.SelectedItems[0].Tag;

                    UrunOnayDurumGuncelleDTO guncelleDTO = new UrunOnayDurumGuncelleDTO()
                    {
                        TakipNumarasi = selectedItem.TakipNumarasi,
                        OnayDurumId = frmUrunOnayGuncelleDialog.ReturnOnayDurum,
                        Aciklama = frmUrunOnayGuncelleDialog.ReturnAciklama
                    };

                    selectedItem.OnayDurumId = guncelleDTO.OnayDurumId;
                    selectedItem.Aciklama = guncelleDTO.Aciklama;

                    UrunOnayDurumDAL urunOnayDurumDAL = new UrunOnayDurumDAL();

                    bool result = urunOnayDurumDAL.UrunOnayDurumGuncelleAdmin(guncelleDTO, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Ürün onay durum güncellendi.");

                        lvUrunOnay.SelectedItems[0].SubItems[1].Text = guncelleDTO.OnayDurumId.ToString().Replace("_", " ");
                        lvUrunOnay.SelectedItems[0].SubItems[2].Text = guncelleDTO.Aciklama;

                        lvUrunOnay.SelectedItems[0].Tag = selectedItem;

                        lvUrunOnay.SelectedIndices.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ürün onay durum güncellenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncellerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                UrunOnayListDTO selectedItem = (UrunOnayListDTO)lvUrunOnay.SelectedItems[0].Tag;

                UrunOnayDurumDAL urunOnayDurumDAL = new UrunOnayDurumDAL();

                bool result = urunOnayDurumDAL.UrunOnayDurumSilAdmin(selectedItem.TakipNumarasi, ClientVariables.LoggedInUserId);

                if(result)
                {
                    MessageBox.Show("Ürün onay durum silindi.");

                    lvUrunOnay.Items.RemoveAt(lvUrunOnay.SelectedIndices[0]);

                    lvUrunOnay.SelectedIndices.Clear();
                }
                else
                {
                    MessageBox.Show("Ürün onay durum silinemedi.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void lvUrunOnay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUrunOnay.SelectedIndices.Count == 0)
            {
                btnSil.Enabled = false;
            }
            else
            {
                btnSil.Enabled = true;
            }
        }


    }
}
