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
    public partial class FrmUreticiAdmin : Form
    {
        int prevIndex = -1;

        public FrmUreticiAdmin()
        {
            InitializeComponent();
        }

        private void FrmUreticiAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                UreticiDAL ureticiDAL = new UreticiDAL();

                listbxUretici.Items.AddRange(ureticiDAL.GetAllUreticiForListing(ClientVariables.LoggedInUserId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üreticileri çekerken bir sorun oluştu." + ex.Message);
            }

            btnSil.Enabled = false;
        }

        private void listbxUretici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevIndex == listbxUretici.SelectedIndex)
            {
                ClearForm();
            }
            else
            {
                prevIndex = listbxUretici.SelectedIndex;
                txtAdi.Text = listbxUretici.SelectedItem?.ToString();
                btnGonder.Text = "Seçileni Güncelle";
                btnSil.Enabled = true;

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            UreticiSimpleListDTO ureticiSimpleListDTO = listbxUretici.SelectedItem as UreticiSimpleListDTO;

            try
            {
                UreticiDAL ureticiDAL = new UreticiDAL();
                bool result = ureticiDAL.UreticiSilAdmin(ureticiSimpleListDTO.Id, ClientVariables.LoggedInUserId);
                if (result)
                {
                    MessageBox.Show("Üretici silindi.");
                    listbxUretici.Items.Remove(ureticiSimpleListDTO);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("üretici silinemedi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == "" || txtAdi.Text.Length > 100)
            {
                MessageBox.Show("Üretici adı boş veya 100 karakterden uzun olamaz");
                return;
            }

            UreticiDAL ureticiDAL = new UreticiDAL();
            if (listbxUretici.SelectedIndex == -1)
            {
                try
                {
                    //Add
                    UreticiSimpleListDTO newUretici = ureticiDAL.UreticiEkleAdmin(txtAdi.Text, ClientVariables.LoggedInUserId);
                    if (newUretici != null)
                    {
                        MessageBox.Show("Üretici eklendi.");
                        listbxUretici.Items.Add(newUretici);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("üretici eklenemedi.");
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
                UreticiSimpleListDTO ureticiSimpleListDTO = listbxUretici.SelectedItem as UreticiSimpleListDTO;
                ureticiSimpleListDTO.Adi = txtAdi.Text;

                try
                {
                    //Update
                    bool result = ureticiDAL.UreticiGuncelleAdmin(ureticiSimpleListDTO, ClientVariables.LoggedInUserId);
                    if (result)
                    {
                        MessageBox.Show("Üretici güncellendi.");
                        listbxUretici.Items[listbxUretici.SelectedIndex] = ureticiSimpleListDTO;
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("üretici güncellenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir sorun oluştu." + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            prevIndex = -1;

            listbxUretici.SelectedIndex = -1;
            txtAdi.Text = "";

            btnGonder.Text = "Ekle";
            btnSil.Enabled = false;
        }
    }
}
