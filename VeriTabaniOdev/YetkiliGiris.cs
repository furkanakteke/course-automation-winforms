using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace VeriTabaniOdev
{
    public partial class YetkiliGiris : Form
    {
        public YetkiliGiris()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public string KisiAdSoyAd = "";
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sorgula = new SqlCommand("KullaniciGirisKontrol", conn);
            sorgula.CommandType = CommandType.StoredProcedure;

            sorgula.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            sorgula.Parameters.AddWithValue("@KSifre", textBox2.Text);

            SqlDataReader oku = sorgula.ExecuteReader();

            if (oku.Read())
            {
                YetkiliAnaSayfa form = new YetkiliAnaSayfa();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("HATALI İSİM VEYA ŞİFRE");
            }
            conn.Close();

            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
