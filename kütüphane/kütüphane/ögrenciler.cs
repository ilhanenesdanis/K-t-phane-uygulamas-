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
    public partial class ögrenciler : Form
    {
        public ögrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MTEL2T5\SQLEXPRESS;Initial Catalog=kütüphanekayıt;Integrated Security=True");
        SqlDataAdapter data = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void ögrenciler_Load(object sender, EventArgs e)
        {
            verigetir();
            MessageBox.Show("Silmek veya güncellemek istegidiniz ögrenci kaydı için ara kısmına id numarasını yazınız");
        }
        private void verigetir()
        {
            baglan.Open();
            data = new SqlDataAdapter("select * from ögrenci", baglan);
            ds = new DataSet();
            data.Fill(ds, "ögrenci");
            dataGridView1.DataSource = ds.Tables["ögrenci"];
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand kmt = new SqlCommand("insert into ögrenci(ögradı,ögrsoyadı,ögrno)values(@ögradı,@ögrsoyadı,@ögrno)", baglan);
            kmt.Parameters.AddWithValue("@ögradı", textBox1.Text);
            kmt.Parameters.AddWithValue("@ögrsoyadı", textBox2.Text);
            kmt.Parameters.AddWithValue("@ögrno", textBox3.Text);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kayıt eklendi");
            verigetir();
            temizle();
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("select * from ögrenci where ıd=@ıd", baglan);
            kmt.Parameters.AddWithValue("@ıd", textBox4.Text);
            textgetir();
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            SqlDataReader dr = kmt.ExecuteReader();

            if (dr.Read())
            {
                string isim = dr["ıd"].ToString() + dr["ögradı"].ToString() + " " + dr["ögrsoyadı"].ToString() + " " + dr["ögrno"].ToString();
                dr.Close();

                DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu = "DELETE from ögrenci where ıd=@ıd";

                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglan);
                    silKomutu.Parameters.AddWithValue("@ıd", int.Parse(textBox4.Text));
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");

                }
            }
            else
                MessageBox.Show("Müşteri Bulunamadı.");
            baglan.Close();
            verigetir();
            temizle();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textgetir();
        }

        private void textgetir()
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["ögradı"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["ögrsoyadı"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["ögrno"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("update ögrenci set ögradı=@ögradı,ögrsoyadı=@ögrsoyadı,ögrno=@ögrno", baglan);
            kmt.Parameters.AddWithValue("@ögradı", textBox1.Text);
            kmt.Parameters.AddWithValue("@ögrsoyadı", textBox2.Text);
            kmt.Parameters.AddWithValue("@ögrno", textBox3.Text);
            
            kmt.ExecuteNonQuery();
            baglan.Close();
            ds.Tables["ögrenci"].Clear();
            verigetir();
            MessageBox.Show("Kayıt güncellendi");
            temizle();
        }
    }
}
