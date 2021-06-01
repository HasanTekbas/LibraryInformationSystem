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
    public partial class deleterecord : Form
    {
       
        public deleterecord()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainboard mnd = new Mainboard();
            mnd.Show();
            this.Close();
        }
        
        private void deleterecord_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = "Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            string Siladi = textBox1.Text;
            cmd.CommandText = "Delete from Library_table where kitap_adi='" + Siladi + "'";
            cmd.Connection = baglanti;
            baglanti.Open();
            int sayı = cmd.ExecuteNonQuery();
            MessageBox.Show("İşlem yapıldı. Silinen kayıt sayısı: " + sayı);
            baglanti.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

            if (verigetir.HasRows)
            {
                while (verigetir.Read())
                {
                    listBox1.Items.Add(verigetir.GetString(1));

                }
            }
        }
    }
}
