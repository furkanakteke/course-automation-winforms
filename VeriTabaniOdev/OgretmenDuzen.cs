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

namespace VeriTabaniOdev
{
    public partial class OgretmenDuzen : Form
    {
        public OgretmenDuzen()
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
        private void OgretmenDuzen_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
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
                conn.Open();
                SqlCommand sorgula = new SqlCommand("OgretmenEkle", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                sorgula.Parameters.AddWithValue("@OgretmenAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgretmenSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@OgretmenBrans", textBox3.Text);
                sorgula.Parameters.AddWithValue("@OgretmenTelefon", textBox4.Text); // CHAR(11)
                sorgula.Parameters.AddWithValue("@OgretmenNumara", textBox5.Text);

                int affectedRows = sorgula.ExecuteNonQuery();
                conn.Close();
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string brans = textBox3.Text;
                string telefon = textBox4.Text;
                string numara = textBox5.Text;
                LogEkle("Adı : " + ad + " soyadı " + soyad + " branşı " + brans + " telefonu : " + telefon + " numarası " + numara + " olan öğretmen eklendi.");
                // Temizle
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
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
                conn.Open();
                SqlCommand sorgula = new SqlCommand("OgretmenSil", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                sorgula.Parameters.AddWithValue("@OgretmenAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgretmenSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@OgretmenBrans", textBox3.Text);
                sorgula.Parameters.AddWithValue("@OgretmenTelefon", textBox4.Text); // 11 karakterlik sabit uzunluk
                sorgula.Parameters.AddWithValue("@OgretmenNumara", textBox5.Text);

                int affectedRows = sorgula.ExecuteNonQuery();
                conn.Close();
                if (affectedRows > 0)
                {
                    MessageBox.Show("Öğretmen başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Belirtilen bilgilerle öğretmen bulunamadı.");
                }
                // Temizle
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string brans = textBox3.Text;
                string telefon = textBox4.Text;
                string numara = textBox5.Text;
                LogEkle("Adı : " + ad + " soyadı " + soyad + " branşı " + brans + " telefonu : " + telefon + " numarası " + numara + " olan öğretmen silindi.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
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
                SqlCommand sorgula = new SqlCommand("OgretmenGuncelle", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekleyelim
                sorgula.Parameters.AddWithValue("@OgretmenAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgretmenSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@OgretmenBrans", textBox3.Text);
                sorgula.Parameters.AddWithValue("@OgretmenTelefon", textBox4.Text);
                sorgula.Parameters.AddWithValue("@OgretmenNumara", textBox5.Text);

                // Sorguyu çalıştırma
                int affectedRows = sorgula.ExecuteNonQuery();

                conn.Close();
                if (affectedRows > 0)
                {
                    MessageBox.Show("Öğretmen bilgileri güncellendi.");
                }
                else
                {
                    MessageBox.Show("Belirtilen numarada öğretmen bulunamadı.");
                }
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string brans = textBox3.Text;
                string telefon = textBox4.Text;
                string numara = textBox5.Text;
                LogEkle("Adı : " + ad + " soyadı " + soyad + " branşı " + brans + " telefonu : " + telefon + " numarası " + numara + " olan öğretmen güncellendi.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Lütfen boş değer girmeyiniz.");
            }
            else
            {
                conn.Open();
                SqlCommand sorgula = new SqlCommand("OgretmenGetir", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Numara parametresi
                sorgula.Parameters.AddWithValue("@OgretmenNumara", Convert.ToInt16(textBox6.Text));

                SqlDataReader oku = sorgula.ExecuteReader();
                if (oku.Read()) // Veritabanından veri bulunduysa
                {
                    textBox1.Text = oku["ad"].ToString();
                    textBox2.Text = oku["soyad"].ToString();
                    textBox3.Text = oku["brans"].ToString();
                    textBox4.Text = oku["telefon"].ToString();
                    textBox5.Text = oku["numara"].ToString();
                }
                else
                {
                    MessageBox.Show("Öğretmen bulunamadı.");
                }

                textBox6.Text = "";
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OgretmenGoruntule ogretmengoruntule = new OgretmenGoruntule();
            this.Hide();
            ogretmengoruntule.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkiliAnaSayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkiliAnaSayfa.Show();
        }
    }
}
