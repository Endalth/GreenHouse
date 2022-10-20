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
    public partial class FrmUrunAdmin : Form
    {
        int prevIndex = -1;
        string icerikFilePath = "";
        bool icerikFileSelected = false;

        string onYuzFilePath = "";
        bool onYuzFileSelected = false;

        string arkaYuzFilePath = "";
        bool arkaYuzFileSelected = false;

        UrunAdminDTO selectedProductAdminDTO = null;

        public FrmUrunAdmin()
        {
            InitializeComponent();
        }

        private void FrmUrunAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                UreticiDAL ureticiDAL = new UreticiDAL();
                cbUretici.Items.AddRange(ureticiDAL.GetAllUreticiForListing(ClientVariables.LoggedInUserId).ToArray());
                if (cbUretici.Items.Count != 0)
                    cbUretici.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üreticileri yüklerken bir sorun oluştu.   " + ex.Message);
            }

            try
            {
                KategoriDAL kategoriDAL = new KategoriDAL();
                cbKategori.Items.AddRange(kategoriDAL.GetAllKategoriForListing(ClientVariables.LoggedInUserId).ToArray());

                if (cbKategori.Items.Count != 0)
                    cbKategori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategorileri yüklerken bir sorun oluştu.   " + ex.Message);
            }

            try
            {
                UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();
                clbxUrunIcerik.Items.AddRange(urunIcerikDAL.GetAllIcerikForListing(ClientVariables.LoggedInUserId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün içeriklerini yüklerken bir sorun oluştu.   " + ex.Message);
            }

            try
            {
                UrunDAL urunDAL = new UrunDAL();
                listBUrun.Items.AddRange(urunDAL.GetAllUrun(ClientVariables.LoggedInUserId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünleri yüklerken bir sorun oluştu.   " + ex.Message);
            }

            ClearForm();
        }

        private void listBUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevIndex == listBUrun.SelectedIndex)
                ClearForm();
            else
            {
                prevIndex = listBUrun.SelectedIndex;

                UrunSimpleListDTO selectedProduct = listBUrun.SelectedItem as UrunSimpleListDTO;
                
                if(selectedProduct != null)
                {
                    try
                    {
                        UrunDAL urunDAL = new UrunDAL();
                        selectedProductAdminDTO = urunDAL.GetSelectedUrunProperties(selectedProduct.Id, ClientVariables.LoggedInUserId);

                        txtEkleyen.Text = selectedProductAdminDTO.EkleyenKullanici;
                        mtxtBarkod.Text = selectedProductAdminDTO.Barkod.ToString();
                        txtUrunAdi.Text = selectedProductAdminDTO.Adi;

                        int kategoriIndex = cbKategori.FindStringExact(selectedProductAdminDTO.KategoriAdi);
                        cbKategori.SelectedIndex = kategoriIndex;

                        int ureticiIndex = cbUretici.FindStringExact(selectedProductAdminDTO.UreticiAdi);
                        cbUretici.SelectedIndex = ureticiIndex;

                        for (int i = 0; i < clbxUrunIcerik.Items.Count; i++)
                        {
                            clbxUrunIcerik.SetItemChecked(i, false);
                        }
                        
                        foreach (var icerik in selectedProductAdminDTO.UrunIceriks)
                        {
                            int index = clbxUrunIcerik.FindStringExact(icerik.Adi);
                            if(index != ListBox.NoMatches)
                                clbxUrunIcerik.SetItemChecked(index, true);
                        }

                        if (selectedProductAdminDTO.Icerik != null)
                            pbxIcerik.Image = UsefulMethods.ImageFromByteArray(selectedProductAdminDTO.Icerik);
                        else
                            pbxIcerik.Image = null;

                        if (selectedProductAdminDTO.OnYuz != null)
                            pbxOn.Image = UsefulMethods.ImageFromByteArray(selectedProductAdminDTO.OnYuz);
                        else
                            pbxOn.Image = null;

                        if (selectedProductAdminDTO.ArkaYuz != null)
                            pbxArka.Image = UsefulMethods.ImageFromByteArray(selectedProductAdminDTO.ArkaYuz);
                        else
                            pbxArka.Image = null;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ürün bilgilerini çekerken bir sorun oluştu." + ex.Message);
                    }
                }

                btnGonder.Text = "Seçileni güncelle";
                btnSil.Enabled = true;
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if(listBUrun.SelectedIndex == -1)
            {
                //Add
                try
                {
                    List<int> urunIcerikIds = new List<int>();

                    foreach (var item in clbxUrunIcerik.CheckedItems)
                        urunIcerikIds.Add(((UrunIcerikSimpleListDTO)item).Id);

                    UreticiSimpleListDTO seciliUretici = (cbUretici.SelectedItem as UreticiSimpleListDTO);
                    KategoriSimpleListDTO seciliKategori = (cbKategori.SelectedItem as KategoriSimpleListDTO);
                    UrunEkleDTO urunEkleDTO = new UrunEkleDTO()
                    {
                        Barkod = mtxtBarkod.MaskFull ? new Guid(mtxtBarkod.Text) : Guid.Empty,
                        Adi = txtUrunAdi.Text,
                        UreticiId = seciliUretici != null ? seciliUretici.Id : -1,
                        KategoriId = seciliKategori != null ? seciliKategori.Id : -1,
                        Icerik = icerikFilePath == "" ? null : UsefulMethods.ImageByteArrayFromFile(icerikFilePath),
                        OnYuz = onYuzFilePath == "" ? null : UsefulMethods.ImageByteArrayFromFile(onYuzFilePath),
                        ArkaYuz = arkaYuzFilePath == "" ? null : UsefulMethods.ImageByteArrayFromFile(arkaYuzFilePath),
                        CreatedBy = ClientVariables.LoggedInUserId,
                        ModifiedBy = ClientVariables.LoggedInUserId,
                        KullaniciGoster = checkBShowUser.Checked,
                        UrunIcerikIds = urunIcerikIds
                    };

                    UrunDAL urunDAL = new UrunDAL();

                    UrunSimpleListDTO urunSimpleListDTO = urunDAL.UrunEkleAdmin(urunEkleDTO);

                    if(urunSimpleListDTO != null)
                    {
                        MessageBox.Show("Ürün eklendi");
                        listBUrun.Items.Add(urunSimpleListDTO);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Ürün eklenmedi.");
                    }
                }
                catch(ModelNotValidException ex)
                {
                    MessageBox.Show(string.Join("\n", ex.ValidationMessages));
                }
                catch(ExistsException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Br sorun oluştu. " + ex.Message);
                }
            }
            else
            {
                //Update
                try
                {
                    List<int> urunIcerikIds = new List<int>();

                    foreach (var item in clbxUrunIcerik.CheckedItems)
                        urunIcerikIds.Add(((UrunIcerikSimpleListDTO)item).Id);

                    UreticiSimpleListDTO seciliUretici = (cbUretici.SelectedItem as UreticiSimpleListDTO);
                    if(seciliUretici == null)
                    {
                        MessageBox.Show("Üretici Seçiniz.");
                        return;
                    }

                    KategoriSimpleListDTO seciliKategori = (cbKategori.SelectedItem as KategoriSimpleListDTO);
                    if (seciliKategori== null)
                    {
                        MessageBox.Show("Üretici Seçiniz.");
                        return;
                    }

                    if (!mtxtBarkod.MaskFull)
                    {
                        MessageBox.Show("Barkodu tam giriniz.");
                        return;
                    }

                    if(txtUrunAdi.Text == "" || txtUrunAdi.Text.Length > 100)
                    {
                        MessageBox.Show("Urun adı boş veya 100 karakterden uzun olamaz.");
                        return;
                    }

                    if(urunIcerikIds.Count == 0)
                    {
                        MessageBox.Show("İçerik boş olamaz.");
                        return;
                    }

                    UrunGuncelleDTO urunGuncelleDTO = new UrunGuncelleDTO()
                    {
                        Barkod = mtxtBarkod.MaskFull ? new Guid(mtxtBarkod.Text) : Guid.Empty,
                        Adi = txtUrunAdi.Text,
                        UreticiId = seciliUretici != null ? seciliUretici.Id : -1,
                        KategoriId = seciliKategori != null ? seciliKategori.Id : -1,
                        Icerik = icerikFilePath == "" ? selectedProductAdminDTO.Icerik : UsefulMethods.ImageByteArrayFromFile(icerikFilePath),
                        OnYuz = onYuzFilePath == "" ? selectedProductAdminDTO.OnYuz : UsefulMethods.ImageByteArrayFromFile(onYuzFilePath),
                        ArkaYuz = arkaYuzFilePath == "" ? selectedProductAdminDTO.ArkaYuz : UsefulMethods.ImageByteArrayFromFile(arkaYuzFilePath),
                        KullaniciGoster = checkBShowUser.Checked,
                        UrunIcerikIds = urunIcerikIds
                    };
                    UrunSimpleListDTO selectedProduct = listBUrun.SelectedItem as UrunSimpleListDTO;
                    selectedProduct.Adi = txtUrunAdi.Text; // update name in case it is changed

                    UrunDAL urunDAL = new UrunDAL();

                    bool result = urunDAL.UrunGuncelleAdmin(urunGuncelleDTO, selectedProduct.Id, ClientVariables.LoggedInUserId);

                    if (result)
                    {
                        MessageBox.Show("Ürün güncellendi");
                        listBUrun.Items[listBUrun.SelectedIndex] = selectedProduct;
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Ürün güncellenemedi.");
                    }
                }
                catch (ModelNotValidException ex)
                {
                    MessageBox.Show(string.Join("\n", ex.ValidationMessages));
                }
                catch (ExistsException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Br sorun oluştu. " + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                UrunSimpleListDTO urunSimpleListDTO = listBUrun.SelectedItem as UrunSimpleListDTO;

                UrunDAL urunDAL = new UrunDAL();

                bool result = urunDAL.UrunSilAdmin(urunSimpleListDTO.Id, ClientVariables.LoggedInUserId);
                if (result)
                {
                    MessageBox.Show("Ürün silindi");
                    listBUrun.Items.RemoveAt(listBUrun.SelectedIndex);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ürün silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir sorun oluştu." + ex.Message);
            }
        }

        void ClearForm()
        {
            prevIndex = -1;
            listBUrun.SelectedIndex = -1;

            btnGonder.Text = "Ekle";
            btnSil.Enabled = false;

            mtxtBarkod.Text = "";
            txtUrunAdi.Text = "";
            txtEkleyen.Text = "";

            checkBShowUser.Checked = true;

            for (int i = 0; i < clbxUrunIcerik.Items.Count; i++)
            {
                clbxUrunIcerik.SetItemChecked(i, false);
            }

            if (cbKategori.Items.Count != 0)
                cbKategori.SelectedIndex = 0;
            else
                cbKategori.SelectedIndex = -1;

            if (cbUretici.Items.Count != 0)
                cbUretici.SelectedIndex = 0;
            else
                cbUretici.SelectedIndex = -1;

            btnIcerikSec.Text = "İçerik Resim Seç";
            btnOnYuzSec.Text = "Ön Yüz Resim Seç";
            btnArkaYuzSec.Text = "Arka Yüz Resim Seç";

            pbxIcerik.Image = null;
            icerikFilePath = "";
            icerikFileSelected = false;

            pbxOn.Image = null;
            onYuzFilePath = "";
            onYuzFileSelected = false;

            pbxArka.Image = null;
            arkaYuzFilePath = "";
            arkaYuzFileSelected = false;

            selectedProductAdminDTO = null;
        }

        private void btnIcerikSec_Click(object sender, EventArgs e)
        {
            if (!icerikFileSelected)
            {
                UsefulMethods.ImageSelect(out icerikFilePath);

                if (icerikFilePath != "")
                {
                    icerikFileSelected = true;
                    btnIcerikSec.Text = "Seçileni Kaldır";
                }
            }
            else
            {
                icerikFileSelected = false;
                icerikFilePath = "";
                btnIcerikSec.Text = "İçerik Resim Seç";
            }
        }

        private void btnOnYuzSec_Click(object sender, EventArgs e)
        {
            if (!onYuzFileSelected)
            {
                UsefulMethods.ImageSelect(out onYuzFilePath);

                if (onYuzFilePath != "")
                {
                    onYuzFileSelected = true;
                    btnOnYuzSec.Text = "Seçileni Kaldır";
                }
            }
            else
            {
                onYuzFileSelected = false;
                onYuzFilePath = "";
                btnOnYuzSec.Text = "Ön Yüz Resim Seç";
            }
        }

        private void btnArkaYuzSec_Click(object sender, EventArgs e)
        {
            if (!arkaYuzFileSelected)
            {
                UsefulMethods.ImageSelect(out arkaYuzFilePath);

                if (arkaYuzFilePath != "")
                {
                    arkaYuzFileSelected = true;
                    btnArkaYuzSec.Text = "Seçileni Kaldır";
                }
            }
            else
            {
                arkaYuzFileSelected = false;
                arkaYuzFilePath = "";
                btnArkaYuzSec.Text = "Arka Yüz Resim Seç";
            }
        }
    }
}
