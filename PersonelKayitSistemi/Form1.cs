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

namespace PersonelKayitSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {

            txtAd.Text = "";
            txtid.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            mskMaas.Text = "";
            cmdSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
            label8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert info Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek) values(@p1,@p2,@p3,@p4,@p5)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmdSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            cmdSehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {

                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Tbl_Personel where Personelid=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand güncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@p1,PerSoyad=@p2,PerSehir=@p3,perMaas=@p4,PerDurum=@p5,PerMeslek=@p6 where personekid=@p7", baglanti);
            güncelle.Parameters.AddWithValue("p1", txtAd.Text);
            güncelle.Parameters.AddWithValue("p2", txtSoyad.Text);
            güncelle.Parameters.AddWithValue("p3", cmdSehir.Text);
            güncelle.Parameters.AddWithValue("p4", mskMaas.Text);
            güncelle.Parameters.AddWithValue("p5", label8.Text);
            güncelle.Parameters.AddWithValue("p6", txtMeslek.Text);
            güncelle.Parameters.AddWithValue("p7", txtid.Text);
            güncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel güncellemesi tamamlandı");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
