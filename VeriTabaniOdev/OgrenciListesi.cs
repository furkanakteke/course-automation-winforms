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
    public partial class OgrenciListesi : Form
    {
        public OgrenciListesi()
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
            string sql = "SELECT oad AS 'Ad',osoyad AS 'Soy Ad', numara AS 'Numara', tckimlik AS 'TC Kimlik',sinifad AS 'Sınıf' from Ogrenciler o INNER JOIN Sinif s ON o.sinifid = s.id";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciDuzen ogrenciduzen = new OgrenciDuzen();
            this.Hide();
            ogrenciduzen.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkilianasayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkilianasayfa.Show();
        }

        private void OgrenciListesi_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
            verilerigetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
