using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kütüphane
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MTEL2T5\SQLEXPRESS;Initial Catalog=kütüphanekayıt;Integrated Security=True");
        SqlDataAdapter data = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            kitaplar kitaplar = new kitaplar();
            kitaplar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ögrenciler ögrenciler = new ögrenciler();
            ögrenciler.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nöbetçiler nöbetçiler = new nöbetçiler();
            nöbetçiler.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grid()
        {
            baglan.Open();
            data = new SqlDataAdapter("select * from ögrenci", baglan);
            ds = new DataSet();
            data.Fill(ds, "ögrenci");
            dataGridView1.DataSource = ds.Tables["ögrenci"];
            baglan.Close();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            grid();
        }
    }
}
