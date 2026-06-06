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
    public partial class SinifDuzen : Form
    {
        public SinifDuzen()
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
            string sql = "SELECT sinifad AS 'Sınıf Adı' , sinifsayisi AS 'Sınıf Nüfuzu' from Sinif order by sinifsayisi asc";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Sinif");
            dataGridView1.DataSource = ds.Tables["Sinif"];
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
        private void SinifDuzen_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Server=.;Database=DershaneTS;Integrated Security=True");
            verilerigetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sinifAdi = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(sinifAdi))
            {
                MessageBox.Show("Sınıf adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SinifEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SinifAdi", sinifAdi);
                cmd.ExecuteNonQuery();
                verilerigetir();
                conn.Close();
                string sinif = textBox1.Text;
                LogEkle(sinif + " adlı sınıf eklendi.");
                textBox1.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SinifSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SinifAdi", textBox1.Text.Trim());
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                verilerigetir();
                conn.Close();
                string sinif = textBox1.Text;
                LogEkle(sinif + " adlı sınıf silindi.");
                textBox1.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkiliAnaSayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkiliAnaSayfa.Show();
        }
    }
}
