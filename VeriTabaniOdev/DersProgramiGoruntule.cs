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
    public partial class DersProgramiGoruntule : Form
    {
        public DersProgramiGoruntule()
        {
            InitializeComponent();
        }

        private void DersProgramiGoruntule_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DersProgrami d = new DersProgrami();
            this.Hide();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YetkiliAnaSayfa y = new YetkiliAnaSayfa();
            this.Hide();
            y.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sinifAdi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(sinifAdi))
            {
                MessageBox.Show("Lütfen bir sınıf adı girin.");
                return;
            }

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            List<string> gunler = new List<string>();
            List<string> saatler = new List<string>();

            using (SqlConnection baglanti = new SqlConnection("Server=.;Database=DershaneTS;Trusted_Connection=True;"))
            {
                baglanti.Open();

                // Günleri çek
                SqlCommand cmdGun = new SqlCommand("SELECT DISTINCT gun FROM DersProgrami", baglanti);
                SqlDataReader drGun = cmdGun.ExecuteReader();
                while (drGun.Read())
                {
                    string gun = drGun["gun"].ToString();
                    gun = char.ToUpper(gun[0]) + gun.Substring(1).ToLower(); // normalize et
                    gunler.Add(gun);
                }
                drGun.Close();

                // Saatleri çek
                SqlCommand cmdSaat = new SqlCommand("SELECT DISTINCT saat FROM DersProgrami ORDER BY saat", baglanti);
                SqlDataReader drSaat = cmdSaat.ExecuteReader();
                while (drSaat.Read())
                {
                    saatler.Add(drSaat["saat"].ToString());
                }
                drSaat.Close();

                // Sütunları ekle
                dataGridView1.Columns.Add("Saat", "Saat");
                foreach (string gun in gunler)
                    dataGridView1.Columns.Add(gun, gun);

                // Satırları ekle
                foreach (string saat in saatler)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = saat;
                    dataGridView1.Rows.Add(row);
                }

                // Ders programı verisini çek
                SqlCommand komut = new SqlCommand(@"
            SELECT DP.gun, DP.saat, DP.dersad, O.ad, O.soyad
            FROM DersProgrami DP
            JOIN Sinif S ON DP.sinifid = S.id
            JOIN Ogretmenler O ON DP.ogretmenid = O.id
            WHERE S.sinifad = @sinifAdi", baglanti);

                komut.Parameters.AddWithValue("@sinifAdi", sinifAdi);

                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    string gun = char.ToUpper(dr["gun"].ToString()[0]) + dr["gun"].ToString().Substring(1).ToLower();
                    string saat = dr["saat"].ToString();
                    string dersAdi = dr["dersad"].ToString() + " ";
                    string ogretmenAdSoyad = dr["ad"].ToString() + " " + dr["soyad"].ToString();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == saat && dataGridView1.Columns.Contains(gun))
                        {
                            int gunIndex = dataGridView1.Columns[gun].Index;
                            row.Cells[gunIndex].Value = dersAdi + "\n" + ogretmenAdSoyad;
                            break;
                        }
                    }
                }

                dr.Close();

            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
