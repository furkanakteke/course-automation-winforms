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
    public partial class NotGiris : Form
    {
        public NotGiris()
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("NotEkle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numara", Convert.ToInt16(textBox1.Text));
                    cmd.Parameters.AddWithValue("@DersAdi", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Not1", Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Not2", Convert.ToInt32(textBox4.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string no = textBox1.Text;
                string ad = textBox2.Text;
                string not1 = textBox3.Text;
                string not2 = textBox4.Text;
                LogEkle(no + " numaralı öğrenciye " + ad + " isimli dersten aldığı" + not1 + " 1.not ve" + not2 + " 2.not eklendi.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkilianasayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkilianasayfa.Show();
        }

        private void NotGiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("NotGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Numara", textBox5.Text);
            cmd.Parameters.AddWithValue("@DersAdi", textBox6.Text);
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                textBox1.Text = oku["numara"].ToString();
                textBox2.Text = oku["dad"].ToString();
                textBox3.Text = oku["not1"].ToString();
                textBox4.Text = oku["not2"].ToString();
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
                

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("NotSil", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Numara", textBox1.Text);
            cmd.Parameters.AddWithValue("@DersAdi", textBox2.Text);

            int affectedRows = cmd.ExecuteNonQuery();
            string no = textBox1.Text;
            string ad = textBox2.Text;
            string not1 = textBox3.Text;
            string not2 = textBox4.Text;
            LogEkle(no + " numaralı öğrencinin " + ad + " isimli dersten aldığı" + not1 + " 1.not ve" + not2 + " 2.not silindi.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("NotGuncelle", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Numara", textBox1.Text);
            cmd.Parameters.AddWithValue("@DersAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@Not1", textBox3.Text);
            cmd.Parameters.AddWithValue("@Not2", textBox4.Text);

            int affectedRows = cmd.ExecuteNonQuery();
            string no = textBox1.Text;
            string ad = textBox2.Text;
            string not1 = textBox3.Text;
            string not2 = textBox4.Text;
            LogEkle(no + " numaralı öğrenciye " + ad + " isimli dersten aldığı " + not1 + " 1.not ve " + not2 + " 2.not güncellendi.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            conn.Close();

        }
    }
}
