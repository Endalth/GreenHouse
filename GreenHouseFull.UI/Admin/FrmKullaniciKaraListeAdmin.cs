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
    public partial class FrmKullaniciKaraListeAdmin : Form
    {
        public FrmKullaniciKaraListeAdmin()
        {
            InitializeComponent();
        }

        private void FrmKullaniciKaraListeAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();

                listKullanici.Items.AddRange(kullaniciDAL.GetAllKullanici(ClientVariables.LoggedInUserId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcıları yüklerken bir sorun oluştu. " + ex.Message);
            }


            try
            {
                UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();

                cbxIcerik.Items.AddRange(urunIcerikDAL.GetAllIcerikForListing(ClientVariables.LoggedInUserId).ToArray());

                if (cbxIcerik.Items.Count > 0)
                    cbxIcerik.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İçerikleri yüklerken bir sorun oluştu. " + ex.Message);
            }

            ClearFormKullanici();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                UrunIcerikSimpleListDTO selectedIcerik = cbxIcerik.SelectedItem as UrunIcerikSimpleListDTO;

                KullaniciKaraListeDAL karaListeDAL = new KullaniciKaraListeDAL();

                bool result = karaListeDAL.AddIcerikToKaraList(selectedIcerik.Id, selectedUser.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("İçerik kullanıcının kara listesine eklendi.");
                    listKaraliste.Items.Add(selectedIcerik);
                }
                else
                {
                    MessageBox.Show("İçerik kullanıcının kara listesine eklenemedi.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("İçeriği kara listeye eklerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                UrunIcerikSimpleListDTO selectedIcerik = listKaraliste.SelectedItem as UrunIcerikSimpleListDTO;

                KullaniciKaraListeDAL karaListeDAL = new KullaniciKaraListeDAL();

                bool result = karaListeDAL.EraseFromBlacklist(selectedIcerik.Id, selectedUser.Id, ClientVariables.LoggedInUserId);

                if (result)
                {
                    MessageBox.Show("İçerik kullanıcının kara listesinden silindi.");
                    listKaraliste.Items.RemoveAt(listKaraliste.SelectedIndex);
                    ClearFormIcerik();
                }
                else
                {
                    MessageBox.Show("İçerik kullanıcının kara listesinden silinemedi.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("İçeriği listeden silerken bir sorun oluştu. " + ex.Message);
            }
        }

        private void listKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKullanici.SelectedIndex != -1)
            {
                try
                {
                    ClearFormIcerik();
                    listKaraliste.Items.Clear();

                    KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;

                    KullaniciKaraListeDAL karaListeDAL = new KullaniciKaraListeDAL();

                    listKaraliste.Items.AddRange(karaListeDAL.GetKullaniciKaraListe(selectedUser.Id).ToArray());

                    cbxIcerik.Enabled = true;
                    btnGonder.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcının kara listesini çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void listKaraliste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKaraliste.SelectedIndex != -1)
            {
                btnSil.Enabled = true;
            }
        }

        void ClearFormKullanici()
        {
            ClearFormIcerik();

            listKaraliste.Items.Clear();

            cbxIcerik.Enabled = false;
            btnGonder.Enabled = false;
        }

        void ClearFormIcerik()
        {
            btnSil.Enabled = false;
        }
    }
}
