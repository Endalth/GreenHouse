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
    public partial class FrmKaraListe : Form
    {
        List<UrunIcerikSimpleListDTO> icerikListDTO;
        public FrmKaraListe(List<UrunIcerikSimpleListDTO> icerikListDTO)
        {
            InitializeComponent();
            this.icerikListDTO = icerikListDTO;
        }

        private void FrmKaraListe_Load(object sender, EventArgs e)
        {
            btnKaraListedenKaldir.Enabled = false;

            listBUrunIcerik.Items.AddRange(icerikListDTO.ToArray());
        }

        private void listBUrunIcerik_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBUrunIcerik.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                UrunIcerikSimpleListDTO icerikSimpleDTO = listBUrunIcerik.Items[listBUrunIcerik.SelectedIndex] as UrunIcerikSimpleListDTO;

                try
                {
                    UrunIcerikDAL urunIcerikDAL = new UrunIcerikDAL();
                    UrunIcerikDTO urunIcerikDTO = urunIcerikDAL.GetIcerikDTOById(icerikSimpleDTO.Id, ClientVariables.LoggedInUserId);

                    FrmIcerik frmIcerik = new FrmIcerik(urunIcerikDTO);
                    frmIcerik.MdiParent = this.MdiParent;
                    frmIcerik.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İçerik bilgilerini getirirken bir hata oluştu. " + ex.Message);
                }
            }
        }

        private void listBUrunIcerik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBUrunIcerik.SelectedIndex != -1)
            {
                btnKaraListedenKaldir.Enabled = true;
            }
        }

        private void btnKaraListedenKaldir_Click(object sender, EventArgs e)
        {
            UrunIcerikSimpleListDTO urunIcerikDTO = listBUrunIcerik.SelectedItem as UrunIcerikSimpleListDTO;

            try
            {
                KullaniciKaraListeDAL kullaniciKaraListeDAL = new KullaniciKaraListeDAL();
                bool result = kullaniciKaraListeDAL.EraseFromBlacklist(urunIcerikDTO.Id, ClientVariables.LoggedInUserId);

                if(result)
                {
                    MessageBox.Show("İçerik kara listeden silindi.");

                    listBUrunIcerik.Items.RemoveAt(listBUrunIcerik.SelectedIndex);
                    btnKaraListedenKaldir.Enabled = false;
                }
                else
                {
                    MessageBox.Show("İçerik kara listeden silinemedi.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("İçeriği kara listeden kaldırırken bir sorun oluştu. " + ex.Message);
            }
        }
    }
}
