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
    public partial class Mainboard : Form
    {
        public Mainboard()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True");

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logın log = new logın();
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addrecord add = new addrecord();
            add.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enrollmentlist list = new enrollmentlist();
            list.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updaterecord upp = new updaterecord();
            upp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleterecord del = new deleterecord();
            del.Show();
            this.Hide();
        }

        private void Mainboard_Load(object sender, EventArgs e)
        {
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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.library_tableTableAdapter.FillBy(this.libraryDataSet.Library_table);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
