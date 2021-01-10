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
    public partial class nöbetçiler : Form
    {
        public nöbetçiler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MTEL2T5\SQLEXPRESS;Initial Catalog=kütüphanekayıt;Integrated Security=True");
        SqlDataAdapter data = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void verigetir()
        {
            baglan.Open();
            data = new SqlDataAdapter("select * from nobetçi", baglan);
            ds = new DataSet();
            data.Fill(ds, "nobetçi");
            dataGridView1.DataSource = ds.Tables["nobetçi"];
            baglan.Close();
        }
        private void nöbetçiler_Load(object sender, EventArgs e)
        {
            verigetir();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("insert into nobetçi(nobetçiadı,nobetçisoyadı,kullanıcıadı,şifre) values(@nobetçiadı,@nobetçisoyadı,@kullanıcıadı,@şifre)", baglan);
            kmt.Parameters.AddWithValue("@nobetçiadı", textBox1.Text);
            kmt.Parameters.AddWithValue("@nobetçisoyadı", textBox2.Text);
            kmt.Parameters.AddWithValue("@kullanıcıadı", textBox3.Text);
            kmt.Parameters.AddWithValue("@şifre", textBox4.Text);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Nöbetçi eklendi");


            verigetir();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("select * from nobetçi where ıd=@ıd", baglan);
            kmt.Parameters.AddWithValue("@ıd", textBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                string isim = dr["ıd"].ToString()+ " "+ dr["nobetçiadı"].ToString() + " " + dr["nobetçisoyadı"].ToString() + " " + dr["kullanıcıadı"].ToString() + " " + dr["şifre"].ToString();
                dr.Close();

                DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu = "DELETE from nobetçi where ıd=@ıd";

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
    }
}
