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
using System.Collections;

namespace VeriTabaniOdev
{
    public partial class Yoklama : Form
    {
        public Yoklama()
        {
            InitializeComponent();
        }

        private void Yoklama_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
            verilerigetir();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        void verilerigetir()
        {
            string sql = "SELECT oad AS 'Adı',osoyad AS 'Soy Adı',dad AS 'Ders',numara AS 'Numarası',tarih 'Yoklama Tarihi',CASE WHEN [yoklama] = 1 THEN CONVERT(NVARCHAR(10), 'Var') ELSE CONVERT(NVARCHAR(10), 'Yok') END AS [Yoklama] from Ogrenciler o inner join Yoklama y on o.id=y.ogrenciid inner join Ders d on y.dersid=d.id";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sorgula = new SqlCommand("GetYoklamaListesi", conn);
            sorgula.CommandType = CommandType.StoredProcedure;

            sorgula.Parameters.AddWithValue("@Ad", string.IsNullOrEmpty(textBox1.Text) ? (object)DBNull.Value : textBox1.Text);
            sorgula.Parameters.AddWithValue("@Soyad", string.IsNullOrEmpty(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
            sorgula.Parameters.AddWithValue("@Numara", string.IsNullOrEmpty(textBox3.Text) ? (object)DBNull.Value : textBox3.Text);
            sorgula.Parameters.AddWithValue("@Sinif", string.IsNullOrEmpty(textBox4.Text) ? (object)DBNull.Value : textBox4.Text);
            sorgula.Parameters.AddWithValue("@Tarih", string.IsNullOrEmpty(textBox5.Text) ? (object)DBNull.Value : textBox5.Text);

            SqlDataAdapter da = new SqlDataAdapter(sorgula);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YoklamaEkle yoklamaekle = new YoklamaEkle();
            this.Hide();
            yoklamaekle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkilianasayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkilianasayfa.Show();
        }
    }
}
