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

namespace GreenHouseFull.UI.RaporUI
{
    public partial class FrmSimpleDataGridRapor : Form
    {
        public FrmSimpleDataGridRapor(string formAdi, object dto)
        {
            InitializeComponent();
            this.Text = formAdi;

            dataGridView1.DataSource = dto;
            dataGridView1.ReadOnly = true;
        }

        public FrmSimpleDataGridRapor(string formAdi, List<string> list, string columnName)
        {
            InitializeComponent();
            this.Text = formAdi;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = columnName;
            dataGridView1.Columns.Add(column);
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows.Add(list[i]);
            }

            dataGridView1.ReadOnly = true;
        }
    }
}
