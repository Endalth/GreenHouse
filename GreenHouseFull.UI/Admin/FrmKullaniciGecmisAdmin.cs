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
    public partial class FrmKullaniciGecmisAdmin : Form
    {
        public FrmKullaniciGecmisAdmin()
        {
            InitializeComponent();
        }

        private void FrmKullaniciGecmisAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();

                listKullanici.Items.AddRange(kullaniciDAL.GetAllKullanici(ClientVariables.LoggedInUserId).ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kullanıcıları çekerken bir sorun oluştu." + ex.Message);
            }
        }

        private void listKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            KullaniciSimpleListDTO selectedUser = listKullanici.SelectedItem as KullaniciSimpleListDTO;
            
            if(selectedUser != null)
            {
                listGecmis.Items.Clear();

                try
                {
                    KullaniciGecmisAramaDAL gecmisDAL = new KullaniciGecmisAramaDAL();

                    listGecmis.Items.AddRange(gecmisDAL.GetUserSearchHistory(selectedUser.Id).ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı geçmişini çekerken bir sorun oluştu. " + ex.Message);
                }
            }
        }

        private void listGecmis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UrunSimpleListDTO selectedUrun = listGecmis.SelectedItem as UrunSimpleListDTO;

            if(selectedUrun != null)
            {
                try
                {
                    UrunDAL urunDAL = new UrunDAL();

                    UrunDTO urunDTO = urunDAL.GetUrunDTO(selectedUrun.Id, ClientVariables.LoggedInUserId);

                    FrmUrun frmUrun = new FrmUrun(urunDTO);
                    frmUrun.MdiParent = this.MdiParent;
                    frmUrun.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seçili ürünü açarken bir sorun oluştu. " + ex.Message);
                }
            }
        }
    }
}
