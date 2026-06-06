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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;

namespace VeriTabaniOdev
{
    public partial class OgrenciDuzen : Form
    {
        public OgrenciDuzen()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa form = new YetkiliAnaSayfa();
            form.Show();
            this.Hide();
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
                conn.Open();
                SqlCommand sorgula = new SqlCommand("OgrenciEkle", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                sorgula.Parameters.AddWithValue("@OgrenciAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgrenciSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@Numara", Convert.ToInt16(textBox3.Text));
                sorgula.Parameters.AddWithValue("@TCKimlik", textBox4.Text); // CHAR(11)
                sorgula.Parameters.AddWithValue("@SinifAd", textBox5.Text);

                int affectedRows = sorgula.ExecuteNonQuery();
                conn.Close();
                string ad = textBox1.Text;
                string soyad= textBox2.Text;
                string numara = textBox3.Text;
                string kimlik = textBox4.Text;
                string sinif = textBox5.Text;
                LogEkle("İsmi : " + ad + " soy ismi " + soyad + " numarası " + numara + " olan ve kimliği " + kimlik + " sınıfı " + sinif + " olan öğrenci eklendi.");
                // Temizle
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void OgrenciDuzen_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OgrenciListesi ogrenciListesi = new OgrenciListesi();
            this.Hide();
            ogrenciListesi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
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
                SqlCommand sorgula = new SqlCommand("OgrenciSil", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                sorgula.Parameters.AddWithValue("@OgrenciAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgrenciSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@Numara", Convert.ToInt16(textBox3.Text));
                sorgula.Parameters.AddWithValue("@TCKimlik", textBox4.Text); // 11 karakterlik sabit uzunluk
                sorgula.Parameters.AddWithValue("@SinifAd", textBox5.Text);

                int affectedRows = sorgula.ExecuteNonQuery();
                conn.Close();
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string numara = textBox3.Text;
                string kimlik = textBox4.Text;
                string sinif = textBox5.Text;
                LogEkle("İsmi : " + ad + " soy ismi " + soyad + " numarası " + numara + " olan ve kimliği " + kimlik + " sınıfı " + sinif + " olan öğrenci silindi.");
                // Temizle
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
                SqlCommand sorgula = new SqlCommand("OgrenciGetir", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Numara parametresi
                sorgula.Parameters.AddWithValue("@Numara", Convert.ToInt16(textBox6.Text));

                SqlDataReader oku = sorgula.ExecuteReader();
                if (oku.Read()) // Veritabanından veri bulunduysa
                {
                    textBox1.Text = oku["oad"].ToString();
                    textBox2.Text = oku["osoyad"].ToString();
                    textBox3.Text = oku["numara"].ToString();
                    textBox4.Text = oku["tckimlik"].ToString();
                    textBox5.Text = oku["sinif"].ToString();
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı.");
                }

                textBox6.Text = "";
                conn.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
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
                SqlCommand sorgula = new SqlCommand("OgrenciGuncelle", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekleyelim
                sorgula.Parameters.AddWithValue("@OgrenciAd", textBox1.Text);
                sorgula.Parameters.AddWithValue("@OgrenciSoyad", textBox2.Text);
                sorgula.Parameters.AddWithValue("@Numara", Convert.ToInt16(textBox3.Text));
                sorgula.Parameters.AddWithValue("@TCKimlik", textBox4.Text);
                sorgula.Parameters.AddWithValue("@SinifAd", textBox5.Text);

                // Sorguyu çalıştırma
                int affectedRows = sorgula.ExecuteNonQuery();
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string numara = textBox3.Text;
                string kimlik = textBox4.Text;
                string sinif = textBox5.Text;
                LogEkle("İsmi : " + ad + " soy ismi " + soyad + " numarası " + numara + " olan ve kimliği " + kimlik + " sınıfı " + sinif + " olan öğrenci güncellendi.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                conn.Close();
            }
            
            
        }
    }
}
