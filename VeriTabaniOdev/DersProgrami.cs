using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace VeriTabaniOdev
{
    public partial class DersProgrami : Form
    {
        public DersProgrami()
        {
            InitializeComponent();
        }
        void LogEkle(string islem)
        {
            using (SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
            {
                SqlCommand komut = new SqlCommand("LogEkle", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@Islem", islem);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
        }
        private void DersProgrami_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa y = new YetkiliAnaSayfa();
            this.Hide();
            y.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Lütfen Boş Alan bırakmayınız.");
            }
            else
            {
                using (SqlConnection baglanti = new SqlConnection("Server=.;Database=DershaneTS;Trusted_Connection=True;"))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("sp_DersProgramiEkle", baglanti);
                    komut.CommandType = CommandType.StoredProcedure;

                    komut.Parameters.AddWithValue("@SinifAd", textBox1.Text.Trim());
                    komut.Parameters.AddWithValue("@DersAd", textBox2.Text.Trim());
                    komut.Parameters.AddWithValue("@Saat", textBox3.Text.Trim());
                    komut.Parameters.AddWithValue("@OgretmenNo", textBox4.Text.Trim());
                    komut.Parameters.AddWithValue("@Gun", textBox5.Text.Trim());

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ders başarıyla eklendi.");
                    baglanti.Close();
                    string sinifad = textBox1.Text;
                    string dersad = textBox2.Text;
                    string saat = textBox3.Text;
                    string ogrno = textBox4.Text;
                    string gun = textBox5.Text;
                    LogEkle(sinifad + " sınıfa" + dersad + " isimli ders" + saat+ " saatinde" + ogrno +" numarasında sorumlu öğretmen" + gun + " gününe eklenmiştir.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                using (SqlConnection baglanti = new SqlConnection("Server=.;Database=DershaneTS;Trusted_Connection=True;"))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("sp_DersProgramiSil", baglanti);
                    komut.CommandType = CommandType.StoredProcedure;

                    komut.Parameters.AddWithValue("@Sinifad", textBox1.Text.Trim());
                    komut.Parameters.AddWithValue("@DersAdi", textBox2.Text.Trim());
                    komut.Parameters.AddWithValue("@Saat", textBox3.Text.Trim());
                    komut.Parameters.AddWithValue("@OgretmenNumara", textBox4.Text.Trim());
                    komut.Parameters.AddWithValue("@Gun", textBox5.Text.Trim());

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ders başarıyla silindi.");
                    baglanti.Close();
                }
                string sinifad = textBox1.Text;
                string dersad = textBox2.Text;
                string saat = textBox3.Text;
                string ogrno = textBox4.Text;
                string gun = textBox5.Text;
                LogEkle(sinifad + " sınıfa" + dersad + " isimli ders" + saat + " saatinde" + ogrno + " numarasında sorumlu öğretmen" + gun + " günü olan program silinmiştir.");
                // Temizle
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                conn.Open();
                SqlCommand sorgula = new SqlCommand("DersProgramiGuncelle", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekleyelim
                sorgula.Parameters.AddWithValue("@Sinifad", textBox1.Text);
                sorgula.Parameters.AddWithValue("@DersAdi", textBox2.Text);
                sorgula.Parameters.AddWithValue("@Saat", textBox3.Text);
                sorgula.Parameters.AddWithValue("@OgretmenNumara", textBox4.Text);
                sorgula.Parameters.AddWithValue("@Gun", textBox5.Text);

                // Sorguyu çalıştırma
                int affectedRows = sorgula.ExecuteNonQuery();
                string sinifad = textBox1.Text;
                string dersad = textBox2.Text;
                string saat = textBox3.Text;
                string ogrno = textBox4.Text;
                string gun = textBox5.Text;
                LogEkle(sinifad + " sınıfa" + dersad + " isimli ders" + saat + " saatinde" + ogrno + " numarasında sorumlu öğretmen" + gun + " günü yapılan plan değiştirilmiştir.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text) && string.IsNullOrWhiteSpace(textBox7.Text) && string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Lütfen boş değer girmeyiniz.");
            }
            else
            {
                conn.Open();
                SqlCommand sorgula = new SqlCommand("DersProgramiOku", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Numara parametresi
                sorgula.Parameters.AddWithValue("@SinifAdi", textBox6.Text);
                sorgula.Parameters.AddWithValue("@Saat", textBox7.Text);
                sorgula.Parameters.AddWithValue("@Gun", textBox8.Text);

                SqlDataReader oku = sorgula.ExecuteReader();
                if (oku.Read()) // Veritabanından veri bulunduysa
                {
                    textBox1.Text = oku["sinifad"].ToString();
                    textBox2.Text = oku["dersad"].ToString();
                    textBox3.Text = oku["saat"].ToString();
                    textBox4.Text = oku["numara"].ToString();
                    textBox5.Text = oku["gun"].ToString();
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı.");
                }

                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                conn.Close();
            }
        }
    }
}
