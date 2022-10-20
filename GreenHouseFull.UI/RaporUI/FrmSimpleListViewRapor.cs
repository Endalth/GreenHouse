using GreenHouseFull.DTO;
using GreenHouseFull.DTO.RaporDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.UI.RaporUI
{
    public partial class FrmSimpleListViewRapor : Form
    {
        public FrmSimpleListViewRapor(string formAdi, List<UrunIcerikSayilariDTO> dto)
        {
            InitializeComponent();
            this.Text = formAdi;

            for (int i = 0; i < dto.Count; i++)
            {
                listView1.Groups.Add(new ListViewGroup(dto[i].UrunAdi));
                for (int j = 0; j < dto[i].RiskSeviyeSayilari.Count; j++)
                {
                    string text = dto[i].RiskSeviyeSayilari[j].Seviye.ToString() + " Adet: " + dto[i].RiskSeviyeSayilari[j].Adet.ToString();
                    ListViewItem listViewItem = new ListViewItem(text);
                    listViewItem.Group = listView1.Groups[i];
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        public FrmSimpleListViewRapor(string formAdi, List<UrunIcerikKullananUrunlerDTO> dto)
        {
            InitializeComponent();
            this.Text = formAdi;

            for (int i = 0; i < dto.Count; i++)
            {
                listView1.Groups.Add(new ListViewGroup(dto[i].IcerikAdi));
                for (int j = 0; j < dto[i].UrunAdi.Count; j++)
                {
                    ListViewItem listViewItem = new ListViewItem(dto[i].UrunAdi[j]);
                    listViewItem.Group = listView1.Groups[i];
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        public FrmSimpleListViewRapor(string formAdi, List<string> liste)
        {
            InitializeComponent();
            this.Text = formAdi;
            for (int j = 0; j < liste.Count; j++)
            {
                ListViewItem listViewItem = new ListViewItem(liste[j]);
                listView1.Items.Add(listViewItem);
            }
        }
    }
}
