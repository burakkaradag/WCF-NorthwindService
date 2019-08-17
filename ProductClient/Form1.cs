using ProductClient.ServiceProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceProducts.ServiceProductsClient servis = new ServiceProducts.ServiceProductsClient();
        int secilenID;
        Urun secilenUrun;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servis.GetProducts();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secilenID = (int)dataGridView1.CurrentRow.Cells[3].Value;
            secilenUrun = servis.GetOneProduct(secilenID);
            txtBoxId.Text = secilenUrun.UrunID.ToString();
            txtBoxAd.Text = secilenUrun.UrunAd;
            txtBoxFiyat.Text = secilenUrun.BirimFiyat.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            servis.UpdatePrice(secilenID, Convert.ToDecimal(txtBoxFiyat.Text));
            Form1_Load(null, null);
           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            servis.DeleteProduct(secilenID);
            Form1_Load(null, null);

        }
    }
}
