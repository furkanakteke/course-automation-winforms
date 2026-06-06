using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniOdev
{
    public partial class DersDuzen : Form
    {
        public DersDuzen()
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
            string sql = "SELECT dad AS 'Ders Adı' from Ders order by dad desc";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Ders");
            dataGridView1.DataSource = ds.Tables["Ders"];
            conn.Close();
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
        private void DersDuzen_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
            verilerigetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dersAdi = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(dersAdi))
            {
                MessageBox.Show("Ders adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
            {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DersEkle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DersAdi", dersAdi);
                    cmd.ExecuteNonQuery();
                    verilerigetir();
                    conn.Close();
                string ders = textBox1.Text;
                LogEkle(ders + " adında ders eklendi");
                    textBox1.Text = "";

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
            {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DersSil", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DersAdi", textBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    string ders = textBox1.Text;
                    textBox1.Clear();
                    verilerigetir();
                    conn.Close();
                LogEkle(ders + " adında ders silindi");
                textBox1.Text = "";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkili = new YetkiliAnaSayfa();
            this.Hide();
            yetkili.Show();
        }
    }
}
