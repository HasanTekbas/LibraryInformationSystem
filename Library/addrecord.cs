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
    public partial class addrecord : Form
    {
        public addrecord()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True");


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainboard mnd = new Mainboard();
            mnd.Show();
            this.Close();
        }

        private void addrecord_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = "Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            string Adi = textBox1.Text;
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

            cmd.CommandText = "Insert Into Library_table (kitap_adi,yazar_adi,sayfa_sayisi,kayit_tarihi,ceviri) values ('" + Adi + "','" + Yazar + "','" + Sayfa + "','"+tarih+"','"+cevir+"')";
            cmd.Connection = baglanti;
            baglanti.Open();
            int kayitsayısı = cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni kayıt eklendi. Kayıt sayısı:" + kayitsayısı.ToString());
        }
    }
}
