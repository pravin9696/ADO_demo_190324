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

namespace ADO_demo_190324
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            string contact = textBox3.Text;

            string qry = "update tblStudent set name='" + name + "',contact=" + contact + " where roll=" + textBox1.Text;

            //step1
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;

            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Record updated successfully....");
            }
            else
            {
                MessageBox.Show("Record not updated!!!!");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            string qry = "delete tblStudent where roll="+textBox1.Text;

            //step1
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;

            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Record Deleted  successfully....");
            }
            else
            {
                MessageBox.Show("Record not Deleted!!!!");
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
