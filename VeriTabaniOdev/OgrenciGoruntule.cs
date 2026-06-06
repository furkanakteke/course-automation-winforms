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

namespace VeriTabaniOdev
{

    public partial class OgrenciGoruntule : Form
    {
        public OgrenciGoruntule()
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
            string sql = "SELECT oad AS 'Ad',osoyad AS 'Soy Ad',numara AS 'Numara',sinifad AS 'Sınıf',dad AS 'Ders',not1 AS '1.Not',not2 AS '2.Not',ortalama AS 'Ortalama' FROM Ogrenciler o1 inner join Notlar n1 on o1.id=n1.ogrenciid inner join Ders d1 on n1.dersid=d1.id INNER JOIN Sinif s1 on s1.id=o1.sinifid";
            da = new SqlDataAdapter(sql,conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds,"Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa form = new YetkiliAnaSayfa();
            form.Show();
            this.Hide();
        }

        private void OgrenciGoruntule_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
            verilerigetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("OgrenciNotListele", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SinifAd", string.IsNullOrEmpty(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
            cmd.Parameters.AddWithValue("@DersAd", string.IsNullOrEmpty(textBox1.Text) ? (object)DBNull.Value : textBox1.Text);

            short numara;
            cmd.Parameters.AddWithValue("@Numara", short.TryParse(textBox3.Text, out numara) ? (object)numara : DBNull.Value);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
