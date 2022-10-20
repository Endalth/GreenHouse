using GreenHouseFull.Common;
using GreenHouseFull.DAL;
using GreenHouseFull.DTO;
using GreenHouseFull.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GreenHouseFull.UI
{
    public partial class FrmUrunEkle : Form
    {
        string icerikFilePath = "";
        bool icerikFileSelected = false;

        string onYuzFilePath = "";
        bool onYuzFileSelected = false;

        string arkaYuzFilePath = "";
        bool arkaYuzFileSelected = false;

        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        private void FrmUrunEkle_Load(object sender, EventArgs e)
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
        }

        private void btnSend_Click(object sender, EventArgs e)
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

            try
            {
                UrunDAL urunDAL = new UrunDAL();
                bool result = urunDAL.UrunEkle(urunEkleDTO);

                if (result)
                {
                    MessageBox.Show("Kayıt Başarılı.");

                    //Clear the form
                    icerikFilePath = "";
                    icerikFileSelected = false;
                    btnIcerikSec.Text = "İçerik Resim Seç";

                    onYuzFilePath = "";
                    onYuzFileSelected = false;
                    btnOnYuzSec.Text = "Ön Yüz Resim Seç";

                    arkaYuzFilePath = "";
                    arkaYuzFileSelected = false;
                    btnArkaYuzSec.Text = "Arka Yüz Resim Seç";

                    mtxtBarkod.Text = "";
                    txtUrunAdi.Text = "";
                    cbKategori.SelectedItem = null;
                    cbUretici.SelectedItem = null;

                    foreach (int index in clbxUrunIcerik.CheckedIndices)
                        clbxUrunIcerik.SetItemCheckState(index, CheckState.Unchecked);
                }
                else
                    MessageBox.Show("Kayıt Başarısız.");
            }
            catch (ModelNotValidException ex)
            {
                MessageBox.Show(string.Join("\n", ex.ValidationMessages));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünü kaydederken bir hata oluştu. " + ex.Message);
            }
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
