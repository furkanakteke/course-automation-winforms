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
    public partial class YetkiliAnaSayfa : Form
    {
        public YetkiliAnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DershaneTS;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OgrenciDuzen ogrenciDuzen = new OgrenciDuzen();
            ogrenciDuzen.Show();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NotGiris notGiris = new NotGiris();
            this.Hide();
            notGiris.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OgrenciGoruntule ogrenciGoruntule = new OgrenciGoruntule();
            ogrenciGoruntule.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OgrenciListesi ogrenciListesi = new OgrenciListesi();
            this.Hide();
            ogrenciListesi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Yoklama yoklama = new Yoklama();
            this.Hide();
            yoklama.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            YoklamaEkle yoklamaduzen = new YoklamaEkle();
            this.Hide();
            yoklamaduzen.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DersDuzen dersduzen = new DersDuzen();
            this.Hide();
            dersduzen.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BorcDurumu borc = new BorcDurumu();
            this.Hide();
            borc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SinifDuzen sinif = new SinifDuzen();
            this.Hide();
            sinif.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OgretmenDuzen ogretmen = new OgretmenDuzen();
            this.Hide();
            ogretmen.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           OgretmenGoruntule ogretmengoruntule = new OgretmenGoruntule();
            this.Hide();
            ogretmengoruntule.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DersProgramiGoruntule d = new DersProgramiGoruntule();
            this.Hide();
            d.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DersProgrami d = new DersProgrami();
            this.Hide();
            d.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            this.Hide();
            log.Show();
        }
    }
}
