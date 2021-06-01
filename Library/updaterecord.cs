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

namespace Library
{
    public partial class updaterecord : Form
    {
        public updaterecord()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True");

        public string ID { get; private set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainboard mnd = new Mainboard();
            mnd.Show();
            this.Close();
        }

        private void updaterecord_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = "Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            int ID = Convert.ToInt32(textBox4.Text);
            string Ad = textBox1.Text;
            string Yazar = textBox2.Text;
            int Sayfa = Convert.ToInt32(textBox3.Text);
            DateTime tarih = dateTimePicker1.Value;
            bool cevir;
            if (radioButton1.Checked == true)
            {
                cevir = true;
            }
            else
            {
                cevir = false;
            }
            cmd.CommandText = "UPDATE Library_table SET kitap_adi='" + Ad + "', yazar_adi='" + Yazar + "',  sayfa_sayisi='" + Sayfa + "', kayit_tarihi='"+tarih+"', ceviri='"+cevir+"' WHERE id="+ID+"";
            cmd.Connection = baglanti;
            baglanti.Open();
            int sayı = cmd.ExecuteNonQuery();
            MessageBox.Show("İşlem yapıldı. Güncellenen kayıt sayısı: " + sayı.ToString());
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select * from Library_table";
            komut.Connection = baglanti;
            baglanti.Open();

            SqlDataReader verigetir;
            verigetir = komut.ExecuteReader();

            if(verigetir.HasRows)
            {
                while(verigetir.Read())
                {
                    listBox1.Items.Add(verigetir.GetString(1));

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

