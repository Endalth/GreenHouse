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
    public partial class FrmKullaniciUrunList : Form
    {
        private readonly List<UrunListWithStatusDTO> urunListWithStatuses;

        public FrmKullaniciUrunList(List<UrunListWithStatusDTO> urunListWithStatuses)
        {
            InitializeComponent();
            this.urunListWithStatuses = urunListWithStatuses;
        }

        private void FrmKullaniciUrunList_Load(object sender, EventArgs e)
        {
            listBUrun.Items.AddRange(urunListWithStatuses.ToArray());
        }

        private void listBUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBUrun.SelectedIndex != -1)
            {
                try
                {
                    UrunListWithStatusDTO selectedProduct = listBUrun.SelectedItem as UrunListWithStatusDTO;

                    UrunOnayDurumDAL urunOnayDurumDAL = new UrunOnayDurumDAL();

                    txtTakip.Text = selectedProduct.TakipNumarasi.ToString();
                    txtAciklama.Text = urunOnayDurumDAL.GetUrunOnayAciklama(selectedProduct.TakipNumarasi, ClientVariables.LoggedInUserId);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Açıklama bilgisini çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }
    }
}
