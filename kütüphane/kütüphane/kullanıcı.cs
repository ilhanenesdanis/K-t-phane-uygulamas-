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
    public partial class kullanıcı : Form
    {
        public kullanıcı()
        {
            InitializeComponent();
        }
        SqlDataReader oku;
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MTEL2T5\SQLEXPRESS;Initial Catalog=kütüphanekayıt;Integrated Security=True");
        private void btngiriş_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("select * from nobetçi where kullanıcıadı='" + txtkullanıcı.Text + "' AND şifre='" + txtsifre.Text + "'", baglan);
            oku = kmt.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Başarılı giriş");
                
                anasayfa sayfa = new anasayfa();
                sayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya parola hatalı");
            }
        }
    }
}
