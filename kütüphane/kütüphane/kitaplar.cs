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
    public partial class kitaplar : Form
    {
        public kitaplar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MTEL2T5\SQLEXPRESS;Initial Catalog=kütüphanekayıt;Integrated Security=True");
        SqlDataAdapter data = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void kitaplar_Load(object sender, EventArgs e)
        {
            verigetir();

        }

        private void verigetir()
        {
            baglan.Open();
            data = new SqlDataAdapter("select * from kitaplar", baglan);
            ds = new DataSet();
            data.Fill(ds, "kitaplar");
            dataGridView1.DataSource = ds.Tables["kitaplar"];
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand kmt = new SqlCommand("insert into kitaplar(kitapadı,kitapyazar,kitapsayfa,kitapyayınevi) values(@kitapadı,@kitapyazar,@kitapsayfa,@kitapyayınevi)", baglan);
            kmt.Parameters.AddWithValue("@kitapadı", textBox1.Text);
            kmt.Parameters.AddWithValue("@kitapyazar", textBox2.Text);
            kmt.Parameters.AddWithValue("@kitapsayfa", int.Parse(textBox3.Text));
            kmt.Parameters.AddWithValue("@kitapyayınevi", textBox4.Text);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kayıt eklendi");

            
            verigetir();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            baglan.Open();
            SqlCommand kmt = new SqlCommand("select * from kitaplar where ıd=@ıd", baglan);
            kmt.Parameters.AddWithValue("@ıd", textBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read()) 
            {
                string isim = dr["ıd"].ToString()+ dr["kitapadı"].ToString() + " " + dr["kitapyazar"].ToString() + " " + dr["kitapsayfa"].ToString() + " " + dr["kitapyayınevi"].ToString();
                dr.Close();
                
                DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                
                if (DialogResult.Yes == durum) 
                {
                    string silmeSorgusu = "DELETE from kitaplar where ıd=@ıd";
                    
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglan);
                    silKomutu.Parameters.AddWithValue("@ıd", int.Parse(textBox5.Text));
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");
                    
                }
            }
            else
                MessageBox.Show("kayıt Bulunamadı.");
            baglan.Close();
            verigetir();
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["kitapadı"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["kitapyazar"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["kitapsayfa"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["kitapyayınevi"].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("update kitaplar set kitapadı=@kitapadı,kitapyazar=@kitapyazar,kitapsayfa=@kitapsayfa,kitapyayınevi=@kitapyayınevi", baglan);
            kmt.Parameters.AddWithValue("@kitapadı", textBox1.Text);
            kmt.Parameters.AddWithValue("@kitapyazar", textBox2.Text);
            kmt.Parameters.AddWithValue("@kitapsayfa", textBox3.Text);
            kmt.Parameters.AddWithValue("@kitapyayınevi", textBox4.Text);
            kmt.ExecuteNonQuery();
            baglan.Close();
            ds.Tables["kitaplar"].Clear();
            verigetir();
            MessageBox.Show("Kayıt güncellendi");
            temizle();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
    
}
