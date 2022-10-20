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

namespace GreenHouseFull.UI.Admin
{
    public partial class FrmUrunIcerikAdmin : Form
    {
        int prevIndex = -1;

        public FrmUrunIcerikAdmin()
        {
            InitializeComponent();
        }

        private void FrmUrunIcerikAdmin_Load(object sender, EventArgs e)
        {
            List<UrunIcerikAdminDTO> urunIcerikAdminDTOs = null;

            try
            {
                UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();
                urunIcerikAdminDTOs = urunIcerikDAL.GetAllIcerik(ClientVariables.LoggedInUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünleri çekerken bir hata oluştu. " + ex.Message);
            }

            listBIcerik.Items.AddRange(urunIcerikAdminDTOs.ToArray());

            cbxRiskSeviye.Items.AddRange(Enum.GetNames(typeof(Commons.RiskSeviye)).Select(x => x.Replace("_", " ")).ToArray());
            cbxRiskSeviye.SelectedIndex = 0;

            btnSil.Enabled = false;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (!CheckIcerikAdi(txtIcerikAdi.Text))
                return;

            if (!CheckAciklama(txtAciklama.Text))
                return;

            if (listBIcerik.SelectedIndex == -1)
            {
                //Add
                UrunIcerikAdminDTO urunIcerikAdminDTO = new UrunIcerikAdminDTO()
                {
                    Adi = txtIcerikAdi.Text,
                    Aciklama = txtAciklama.Text,
                    RiskSeviyeId = (Commons.RiskSeviye)cbxRiskSeviye.SelectedIndex + 1
                };

                try
                {
                    UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();

                    urunIcerikAdminDTO = urunIcerikDAL.UrunIcerikEkleAdmin(urunIcerikAdminDTO, ClientVariables.LoggedInUserId);

                    if (urunIcerikAdminDTO != null)
                    {
                        MessageBox.Show("İçerik eklendi.");
                        listBIcerik.Items.Add(urunIcerikAdminDTO);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("İçerik eklenemedi.");
                    }
                }
                catch(ExistsException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eklemeye çalışırken bir sorun oluştu. " + ex.Message);
                }
            }
            else
            {
                //Update
                UrunIcerikAdminDTO urunIcerikAdminDTO = new UrunIcerikAdminDTO()
                {
                    Id = (listBIcerik.SelectedItem as UrunIcerikAdminDTO).Id,
                    Adi = txtIcerikAdi.Text,
                    Aciklama = txtAciklama.Text,
                    RiskSeviyeId = (Commons.RiskSeviye)cbxRiskSeviye.SelectedIndex + 1
                };

                try
                {
                    UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();

                    bool result = urunIcerikDAL.UrunIcerikGuncelleAdmin(urunIcerikAdminDTO, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Güncelleme başarılı.");
                        listBIcerik.Items[listBIcerik.SelectedIndex] = urunIcerikAdminDTO;
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız.");
                    }
                }
                catch (ExistsException ex)
                {
                    MessageBox.Show(ex.Message);
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
                UrunIcerikAdminDTO urunIcerikAdminDTO = listBIcerik.SelectedItem as UrunIcerikAdminDTO;

                UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();

                bool result = urunIcerikDAL.UrunIcerikSilAdmin(urunIcerikAdminDTO.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Silme başarılı.");
                    listBIcerik.Items.RemoveAt(listBIcerik.SelectedIndex);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sıraında bir sorun oldu. " + ex.Message);
            }
        }

        private void listBIcerik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevIndex == listBIcerik.SelectedIndex)
                ClearForm();
            else
            {
                prevIndex = listBIcerik.SelectedIndex;

                UrunIcerikAdminDTO urunIcerikAdminDTO = listBIcerik.SelectedItem as UrunIcerikAdminDTO;

                if (urunIcerikAdminDTO != null)
                {
                    txtIcerikAdi.Text = urunIcerikAdminDTO.Adi;
                    txtAciklama.Text = urunIcerikAdminDTO.Aciklama;
                    cbxRiskSeviye.SelectedIndex = (int)urunIcerikAdminDTO.RiskSeviyeId - 1;
                }
                btnGonder.Text = "Seçileni Güncelle";
                btnSil.Enabled = true;
            }
        }

        private void ClearForm()
        {
            txtIcerikAdi.Text = "";
            txtAciklama.Text = "";

            prevIndex = -1;
            listBIcerik.SelectedIndex = -1;

            cbxRiskSeviye.SelectedIndex = 0;

            btnGonder.Text = "Ekle";
            btnSil.Enabled = false;
        }

        private bool CheckIcerikAdi(string icerikAdi)
        {
            if (icerikAdi == "" || icerikAdi.Length > 100)
            {
                MessageBox.Show("İçerik adı boş veya 100 karakterden uzun olamaz.");
                return false;
            }

            return true;
        }

        private bool CheckAciklama(string aciklama)
        {
            if (aciklama == "" || aciklama.Length > 1000)
            {
                MessageBox.Show("Açıklama boş veya 1000 karakterden uzun olamaz.");
                return false;
            }

            return true;
        }
    }
}
