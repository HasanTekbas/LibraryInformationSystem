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
    public partial class logın : Form
    {
        public logın()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BV523K;Initial Catalog=library;Integrated Security=True");

        private void logın_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "admin";
            string password = Convert.ToString(12345);

            if (name == textBox1.Text && password == textBox2.Text)
            {
                Mainboard mn = new Mainboard();
                mn.Show();
                this.Hide();
            }
            else if (name != textBox1.Text || password == textBox2.Text)
            {
                MessageBox.Show("Kullanıcı adı veya şifreniz hatalı..");
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyiniz..");
            }
            


        }
    }
}
