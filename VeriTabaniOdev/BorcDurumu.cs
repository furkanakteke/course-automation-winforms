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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeriTabaniOdev
{
    public partial class BorcDurumu : Form
    {
        public BorcDurumu()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        void verilerigetir()
        {
            string sql = "SELECT oad AS 'Ad', osoyad AS 'Soy Ad', numara AS 'Numara' , borcisim AS 'Borç Sebebi' , borctutar AS 'Toplam Tutar'" +
                " from Borc b inner join Ogrenciler o on b.ogrenciid = o.id";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Borc");
            dataGridView1.DataSource = ds.Tables["Borc"];
            conn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void button4_Click(object sender, EventArgs e)
        {
            string dersAdi = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen Boş Alan bırakmayınız.");
            }
            else
            {
                if (!short.TryParse(textBox1.Text.Trim(), out short ogrenciNumara))
                {
                    MessageBox.Show($"Geçersiz öğrenci numarası: {textBox2.Text}");
                    return; // Hatalı numara girildiğinde işlem durur
                }

                // Borç tutarını (int) dönüştürme
                if (!int.TryParse(textBox3.Text.Trim(), out int borcTutar))
                {
                    MessageBox.Show("Geçersiz borç tutarı.");
                    return; // Hatalı borç tutarı girildiğinde işlem durur
                }
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand sorgula = new SqlCommand("BorcEkle", conn);
                    sorgula.CommandType = CommandType.StoredProcedure;

                    sorgula.Parameters.AddWithValue("@DersAdi", dersAdi);
                    sorgula.Parameters.AddWithValue("@OgrenciNumara",ogrenciNumara);
                    sorgula.Parameters.AddWithValue("@BorcTutar",borcTutar);
                    sorgula.ExecuteNonQuery();
                    conn.Close();

                    verilerigetir();
                    string sebep = textBox2.Text;
                    string numara = textBox1.Text;
                    string borc = textBox3.Text;
                    LogEkle(sebep + " sebebinden " + numara + " numaralı öğrenciye " + borc + "tl tutarında para girdisi girildi");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    
                }
            }
        }

        private void BorcDurumu_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Server=.;Database=DershaneTS;Integrated Security=True");
            verilerigetir();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SilBorc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekleyin
                cmd.Parameters.AddWithValue("@numara", textBox1.Text);
                cmd.Parameters.AddWithValue("@borcisim", textBox2.Text);
                cmd.Parameters.AddWithValue("@borctutar", Convert.ToDecimal(textBox3.Text));

                // Komutun sonucu bir mesaj döndürecekse (PRINT ile yazdırılmış mesaj)
                cmd.ExecuteNonQuery();
                // Bağlantıyı kapat
                conn.Close();
                string sebep = textBox2.Text;
                string numara = textBox1.Text;
                string borc = textBox3.Text;
                LogEkle(sebep + " sebepli " + numara + " numaralı öğrencinin " + borc + "tl tutarındaki borcu silindi");
                verilerigetir();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkili = new YetkiliAnaSayfa();
            this.Hide();
            yetkili.Show();
        }
    }
}
