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

namespace GreenHouseFull.UI.Dialog_Forms
{
    public partial class FrmSelectListDialog : Form
    {
        public int SelectedListId { get; set; }

        public FrmSelectListDialog()
        {
            InitializeComponent();
        }

        private void FrmSelectListDialog_Load(object sender, EventArgs e)
        {
            try
            {
                KullaniciFavoriDAL kullaniciFavoriDAL = new KullaniciFavoriDAL();
                List<FavoriListeSimpleListDTO> favoriListes = kullaniciFavoriDAL.GetUserFavoriteLists(ClientVariables.LoggedInUserId);

                cbxFavoriLists.Items.AddRange(favoriListes.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir sorun oluştu: " + ex.Message);
            }
        }

        private void btnFavoriList_Click(object sender, EventArgs e)
        {
            if(cbxFavoriLists.SelectedIndex != -1)
            {
                SelectedListId = (cbxFavoriLists.SelectedItem as FavoriListeSimpleListDTO).Id;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ürünü eklemek için bir liste seçmelisiniz.");
            }
        }
    }
}
