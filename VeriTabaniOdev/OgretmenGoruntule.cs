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
    public partial class OgretmenGoruntule : Form
    {
        public OgretmenGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void verilerigetir()
        {
            string sql = "SELECT ad AS 'Ad',soyad AS 'Soy Ad', brans AS 'Branş', telefon AS 'Telefon Numara',numara AS 'Numara' from Ogretmenler";
            da = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Ogretmenler");
            dataGridView1.DataSource = ds.Tables["Ogretmenler"];
            conn.Close();
        }

        private void OgretmenGoruntule_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
            verilerigetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenDuzen ogretmenDuzen = new OgretmenDuzen();
            this.Hide();
            ogretmenDuzen.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa yetkiliAnaSayfa = new YetkiliAnaSayfa();
            this.Hide();
            yetkiliAnaSayfa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
