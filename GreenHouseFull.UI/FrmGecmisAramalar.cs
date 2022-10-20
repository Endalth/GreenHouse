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
    public partial class FrmGecmisAramalar : Form
    {
        List<UrunSimpleListDTO> gecmisAramalarDTOs;
        public FrmGecmisAramalar(List<UrunSimpleListDTO> gecmisAramalarDTOs)
        {
            InitializeComponent();
            this.gecmisAramalarDTOs = gecmisAramalarDTOs;
        }

        private void FrmGecmisAramalar_Load(object sender, EventArgs e)
        {
            btnKaldir.Enabled = false;
            dateTimePicker1.MaxDate = DateTime.Now;


            listBUruns.Items.AddRange(gecmisAramalarDTOs.ToArray());
        }

        private void listBUruns_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBUruns.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                UrunSimpleListDTO urunSimpleListDTO = listBUruns.Items[listBUruns.SelectedIndex] as UrunSimpleListDTO;

                try
                {
                    UrunDAL urunDAL = new UrunDAL();
                    UrunDTO urunDTO = urunDAL.GetUrunDTO(urunSimpleListDTO.Id, ClientVariables.LoggedInUserId);

                    FrmUrun frmUrun = new FrmUrun(urunDTO);
                    frmUrun.MdiParent = this.MdiParent;
                    frmUrun.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürünü getirirken bir hata oluştu. " + ex.Message);
                }
            }
        }

        private void listBUruns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBUruns.SelectedIndex != -1)
                btnKaldir.Enabled = true;
            else
                btnKaldir.Enabled = false;
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            try
            {
                UrunSimpleListDTO selectedProduct = listBUruns.SelectedItem as UrunSimpleListDTO;

                KullaniciGecmisAramaDAL gecmisDAL = new KullaniciGecmisAramaDAL();

                bool result = gecmisDAL.EraseFromSearchHistory(selectedProduct.Id, ClientVariables.LoggedInUserId);
                if (result)
                {
                    MessageBox.Show("Seçili ürün kaldırıldı.");

                    listBUruns.Items.RemoveAt(listBUruns.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Seçili ürün kaldırılamadı.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçili ürünü listeden kaldırırken bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnRemoveBeforeDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dateTimePicker1.Value;
                selectedDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 23, 59, 50);

                UrunSimpleListDTO selectedProduct = listBUruns.SelectedItem as UrunSimpleListDTO;

                KullaniciGecmisAramaDAL gecmisDAL = new KullaniciGecmisAramaDAL();

                List<int> erasedIds = gecmisDAL.EraseSearchesBeforeDate(selectedDate, ClientVariables.LoggedInUserId);
                if (erasedIds.Count > 0)
                {
                    MessageBox.Show("Seçili tarihten önce eklenen ürünler kaldırıldı.");
                    listBUruns.SelectedIndex = -1;

                    //Go thorough the list and remove the items that are removed from the database
                    for (int i = listBUruns.Items.Count - 1; i >= 0; i--)
                    {
                        //If at any point erasedIds count reaches 0 stop
                        if (erasedIds.Count == 0)
                            break;
                        for (int j = 0; j < erasedIds.Count; j++)
                        {
                            UrunSimpleListDTO productAtIndexI = listBUruns.Items[i] as UrunSimpleListDTO;

                            //If erased Id found remove from the list
                            if (productAtIndexI.Id == erasedIds[j])
                            {
                                listBUruns.Items.RemoveAt(i);
                                erasedIds.RemoveAt(j);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seçili tarihten önce eklenen ürün yok.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçili ürünü listeden kaldırırken bir sorun oluştu. " + ex.Message);
            }
        }
    }
}
