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

namespace VeriTabaniOdev
{
    public partial class YoklamaEkle : Form
    {
        public YoklamaEkle()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
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
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                conn.Open();

                // textBox5'e yazılan değeri kontrol edip, "var" ise 1, "yok" ise 0 değerini ayarlıyoruz
                int yoklamaBit = (textBox4.Text.ToLower() == "var") ? 1 : 0;

                // Stored Procedure'i çalıştırıyoruz
                SqlCommand sorgula = new SqlCommand("AddYoklama", conn);
                sorgula.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekliyoruz
                sorgula.Parameters.AddWithValue("@Tarih", textBox3.Text);  // Tarih
                sorgula.Parameters.AddWithValue("@OgrenciNumara", textBox1.Text);  // Öğrenci numarası
                sorgula.Parameters.AddWithValue("@DersAd", textBox2.Text);  // Ders adı
                sorgula.Parameters.AddWithValue("@YoklamaBit", yoklamaBit);  // Yoklama durumu (1 ya da 0)

                // ExecuteNonQuery kullanarak prosedürü çalıştırıyoruz
                int affectedRows = sorgula.ExecuteNonQuery();

                // Eğer işlem başarılıysa, kullanıcıyı bilgilendiriyoruz
                if (affectedRows > 0)
                {
                    MessageBox.Show("Yoklama kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Yoklama kaydedilemedi.");
                }

                // Bağlantıyı kapatıyoruz
                conn.Close();
                string tarih = textBox3.Text;
                string numara = textBox1.Text;
                string ad = textBox2.Text;
                LogEkle(tarih + " tarihinde " + numara + " numaralı öğrenciye " + ad + " dersinde yoklama kaydı eklenmiştir.");
                // TextBox'ları temizliyoruz
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Tüm değerleri giriniz.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SilYoklama", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@numara", textBox1.Text);
                cmd.Parameters.AddWithValue("@dersAdi", textBox2.Text);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(textBox3.Text));

                // "var" ise 1, "yok" ise 0 olarak belirle
                byte yoklamaDegeri = textBox4.Text.Trim().ToLower() == "var" ? (byte)1 : (byte)0;
                cmd.Parameters.AddWithValue("@yoklama", yoklamaDegeri);

                int affectedRows = cmd.ExecuteNonQuery();

                conn.Close();
                string tarih = textBox3.Text;
                string numara = textBox1.Text;
                string ad = textBox2.Text;
                LogEkle(tarih + " tarihinde " + numara + " numaralı öğrenciye " + ad + " dersinde eklenilen yoklama kaydı silinmiştir.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GuncelleYoklama", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@numara", textBox1.Text);
                cmd.Parameters.AddWithValue("@dersAdi", textBox2.Text);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(textBox3.Text));

                bool yoklamaDegeri = textBox4.Text.Trim().ToLower() == "var";
                cmd.Parameters.AddWithValue("@yoklama", yoklamaDegeri);

                int affectedRows = cmd.ExecuteNonQuery();

                conn.Close();
                string tarih = textBox3.Text;
                string numara = textBox1.Text;
                string ad = textBox2.Text;
                LogEkle(tarih + " tarihinde " + numara + " numaralı öğrenciye " + ad + " dersinde eklenen yoklama kaydı güncellenmiştir.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void YoklamaEkle_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkilianasayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkilianasayfa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yoklama yoklama = new Yoklama();
            this.Hide();
            yoklama.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Lütfen hepsini doldurunuz.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("YoklamaSorgula", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@numara", textBox5.Text);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@dersAdi", textBox7.Text);

                SqlDataReader oku = cmd.ExecuteReader();

                if (oku.Read())
                {
                    textBox1.Text = oku["numara"].ToString();
                    textBox2.Text = oku["dad"].ToString();

                    DateTime tarih = Convert.ToDateTime(oku["tarih"]);
                    textBox3.Text = tarih.ToString("dd.MM.yyyy");

                    bool yoklamaDurumu = Convert.ToBoolean(oku["yoklama"]);
                    textBox4.Text = yoklamaDurumu ? "Var" : "Yok";
                }

                conn.Close();
            }
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
