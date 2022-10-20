using GreenHouseFull.Common;
using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI.Admin
{
    public partial class FrmUrunDuzeltmeTalepAdmin : Form
    {
        int prevIndex = -1;
        byte[] seciliTalepResim;

        public FrmUrunDuzeltmeTalepAdmin()
        {
            InitializeComponent();
        }

        private void FrmUrunDuzeltmeTalepAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                List<DuzeltmeTalepListeDTO> duzeltmeTalepListeDTOs;

                UrunDuzeltmeTalepDAL urunDuzeltmeTalepDAL = new UrunDuzeltmeTalepDAL();

                duzeltmeTalepListeDTOs = urunDuzeltmeTalepDAL.GetTaleps(ClientVariables.LoggedInUserId);

                listBTalep.Items.AddRange(duzeltmeTalepListeDTOs.ToArray());

                cbxOnayDurum.Items.AddRange(Enum.GetNames(typeof(Commons.OnayDurum)).Select(x => x.Replace("_", " ")).ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Talepleri çekerken bir hata oluştu. " + ex.Message);
            }

            ClearForm();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if(txtOnayAciklama.Text == "" || txtOnayAciklama.Text.Length > 1000)
            {
                MessageBox.Show("Onay açıklaması boş veya 1000 karakterden uzun olamaz");
                return;
            }

            try
            {
                DuzeltmeTalepListeDTO selectedRequest = listBTalep.SelectedItem as DuzeltmeTalepListeDTO;
                selectedRequest.OnayDurumId = (Commons.OnayDurum)cbxOnayDurum.SelectedIndex + 1;

                DuzeltmeTalepGuncelleODT guncelleODT = new DuzeltmeTalepGuncelleODT()
                {
                    Id = selectedRequest.Id,
                    OnayAciklama = txtOnayAciklama.Text,
                    OnayDurumId = (Commons.OnayDurum)cbxOnayDurum.SelectedIndex + 1
                };

                UrunDuzeltmeTalepDAL urunDuzeltmeTalepDAL = new UrunDuzeltmeTalepDAL();

                bool result = urunDuzeltmeTalepDAL.TalepGuncelleAdmin(guncelleODT, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Talep güncellendi");
                    listBTalep.Items[listBTalep.SelectedIndex] = selectedRequest;
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Talep güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talebi güncellerken bir hata oluştu. " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DuzeltmeTalepListeDTO selectedRequest = listBTalep.SelectedItem as DuzeltmeTalepListeDTO;

                UrunDuzeltmeTalepDAL urunDuzeltmeTalepDAL = new UrunDuzeltmeTalepDAL();

                bool result = urunDuzeltmeTalepDAL.TalepSilAdmin(selectedRequest.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("Talep silindi");
                    listBTalep.Items.RemoveAt(listBTalep.SelectedIndex);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Talep silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talebi silerken bir hata oluştu. " + ex.Message);
            }
        }

        private void btnKanitResimGor_Click(object sender, EventArgs e)
        {
            FrmBigImage frmBigImage = new FrmBigImage(seciliTalepResim);
            frmBigImage.MdiParent = this.MdiParent;
            frmBigImage.Show();
        }

        private void listBTalep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevIndex == listBTalep.SelectedIndex)
                ClearForm();
            else
            {
                prevIndex = listBTalep.SelectedIndex;

                DuzeltmeTalepListeDTO selectedRequest = listBTalep.SelectedItem as DuzeltmeTalepListeDTO;

                if(selectedRequest != null)
                {
                    txtUrunAdi.Text = selectedRequest.UrunAdi;
                    int index = cbxOnayDurum.FindStringExact(selectedRequest.OnayDurumId.ToString().Replace("_", " "));
                    cbxOnayDurum.SelectedIndex = index;

                    try
                    {
                        UrunDuzeltmeTalepDAL talepDAL = new UrunDuzeltmeTalepDAL();

                        DuzeltmeTalepListeEkAciklamaResimDTO talepDetails = talepDAL.GetTalepDetail(selectedRequest.Id, ClientVariables.LoggedInUserId);

                        txtAciklama.Text = talepDetails.Aciklama;
                        txtOnayAciklama.Text = talepDetails.OnayAciklama;
                        seciliTalepResim = talepDetails.Resim;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ek bilgileri alırken bir hata oluştu." + ex.Message);
                    }

                    btnGonder.Enabled = true;
                    btnSil.Enabled = true;
                    btnKanitResimGor.Enabled = true;
                }
            }
        }

        void ClearForm()
        {
            seciliTalepResim = null;

            prevIndex = -1;
            listBTalep.SelectedIndex = -1;

            txtUrunAdi.Text = "";
            txtAciklama.Text = "";
            txtOnayAciklama.Text = "";

            if (cbxOnayDurum.Items.Count > 0)
                cbxOnayDurum.SelectedIndex = 0;

            btnGonder.Enabled = false;
            btnSil.Enabled = false;
            btnKanitResimGor.Enabled = false;
        }
    }
}
