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
  // this is my comment from Git HUB*********************************************8
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

        private void button3_Click(object sender, EventArgs e)
        {
            int roll = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            int contact = Convert.ToInt32(textBox3.Text);

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_insert_student";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@contact", contact);

            int n = cmd.ExecuteNonQuery();
            if (n>0)
            {
                MessageBox.Show("Record inserted successfully...");
            }
            else
            {
                MessageBox.Show("Record not inserted!!!!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int roll = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            int contact = Convert.ToInt32(textBox3.Text);

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_update_student";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@contact", contact);

            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Record updated successfully...");
            }
            else
            {
                MessageBox.Show("Record not updated!!!!");
            }
        }
    }
}
