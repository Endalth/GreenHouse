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
using System.Windows.Forms;

namespace GreenHouseFull.UI
{
    public partial class FrmUrunDuzeltmeTalepAc : Form
    {
        private UrunSimpleListDTO urunSimpleListDTO;
        private bool imageSelected = false;
        private string imagePath = "";

        public FrmUrunDuzeltmeTalepAc(UrunSimpleListDTO urunSimpleListDTO)
        {
            InitializeComponent();
            this.urunSimpleListDTO = urunSimpleListDTO;
            this.Text = urunSimpleListDTO.Adi + " İçin Düzeltme Talebi Formu";
        }

        private void btnImageSelect_Click(object sender, EventArgs e)
        {
            if (!imageSelected)
                UsefulMethods.ImageSelect(out imagePath);

            ChangeImageSelectButtonMode(btnImageSelect);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UrunDuzeltmeTalepEkleDTO talepDTO = new UrunDuzeltmeTalepEkleDTO()
            {
                UrunId = urunSimpleListDTO.Id,
                Aciklama = txtAciklama.Text,
                Resim = imagePath == "" ? null : UsefulMethods.ImageByteArrayFromFile(imagePath),
                OnayAciklama = "İncelenmeyi bekliyor.",
                OnayDurumId = (int)Commons.OnayDurum.Beklemede,
                CreatedBy = ClientVariables.LoggedInUserId,
                ModifiedBy = ClientVariables.LoggedInUserId
            };

            try
            {
                UrunDuzeltmeTalepDAL ekleDAL = new UrunDuzeltmeTalepDAL();
                bool success = ekleDAL.UrunDuzeltmeTalepEkle(talepDTO);

                if (success)
                {
                    MessageBox.Show("Talep başarıyla eklendi.");

                    txtAciklama.Text = "";
                    ChangeImageSelectButtonMode(btnImageSelect);
                }
                else
                    MessageBox.Show("Talep eklenemedi.");
            }
            catch(ModelNotValidException ex) 
            {
                MessageBox.Show(string.Join("\n", ex.ValidationMessages));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında bir hata oluştu. " + ex.Message);
            }
        }

        private void ChangeImageSelectButtonMode(Button sender)
        {
            if (!imageSelected)
            {
                if (imagePath != "")
                {
                    imageSelected = true;
                    sender.Text = "Seçileni Kaldır";
                }
            }
            else
            {
                imageSelected = false;
                imagePath = "";
                sender.Text = "Kanıt Resmi Seçiniz";
            }
        }

        private void FrmUrunDuzeltmeTalepAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
