using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoLotDisconnectedLayer;

namespace InventoryDALDisconnectedGUI
{
    public partial class MainForm : Form
    {
        InventoryDALDisLayer dal = null;
        public MainForm()
        {
            InitializeComponent();
            string cnStr = @"Data Source=VH19;Initial Catalog=AutoLot;" +
                "Integrated Security=True;Pooling=False";
            dal = new InventoryDALDisLayer(cnStr);
            dataGridView1.DataSource = dal.GetAllInventory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable changedDT = (DataTable)dataGridView1.DataSource;
            try
            {
                dal.UpdateInventory(changedDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
