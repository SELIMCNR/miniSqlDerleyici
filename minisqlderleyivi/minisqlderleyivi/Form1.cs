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

namespace minisqlderleyivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-BC3LOP2\SQLEXPRESS;Initial Catalog=notSistemi;Integrated Security=True;
");
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("sorgunuzu kontrol edin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            try
            {
              
                bgl.Open();
                SqlCommand komut = new SqlCommand(sorgu, bgl);
                komut.ExecuteNonQuery();
                bgl.Close();

                SqlDataAdapter da = new SqlDataAdapter("Select * from tblmat", bgl);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("sorgunuzu kontrol edin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
    }
}
