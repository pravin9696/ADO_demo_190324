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
using System.Windows.Forms.Automation;

namespace ADO_demo_190324
{
    public partial class EmpRegistration : Form
    {
        public EmpRegistration()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int empid=Convert.ToInt32(txtEmpId.Text);
            string name = txtEmpName.Text;
            string gender = "";
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }

            string dept = cmbDept.SelectedItem.ToString();
            int sal = int.Parse(txtSalary.Text);

            string designation = listDesignation.SelectedItem.ToString();
            ///////////////////////////////////////////////////////////////////////////////////////


            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_insert_emp_details";
            cmd.CommandType = CommandType.StoredProcedure;
            /*
             @empid=1,@name='anand',@gender='Male',
                                       @dept='HR',@sal=15000,@designation='Sales person'
             */
            cmd.Parameters.AddWithValue("@empid",empid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@sal",sal);
            cmd.Parameters.AddWithValue("@designation", designation);


            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Record inserted successfully...");
            }
            else
            {
                MessageBox.Show("Record not inserted!!!!");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            string gender = "";
            string dept = "";
            string designation = "";
            cmbDept.SelectedIndex = -1;
            txtSalary.Text = "";
            listDesignation.SelectedIndex = -1;
            radioButton1.Checked = radioButton2.Checked = false;

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select * from tblEmp_info where empid="+txtEmpId.Text.Trim();
            cmd1.CommandType = CommandType.Text;

            SqlDataReader rdr= cmd1.ExecuteReader();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "select * from tblEmp_office_details where empid=" + txtEmpId.Text.Trim();
            cmd2.CommandType = CommandType.Text;
            
            
           
            if (rdr.Read())
            {
                //txtEmpId.Text= rdr["empid"].ToString();
                txtEmpName.Text = rdr["name"].ToString();
                gender = rdr["gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Employee information not available!!!!");
                return;
            }
            rdr.Close();
            rdr = cmd2.ExecuteReader();
            if (rdr.Read())
            {
                dept = rdr["dept"].ToString();
                cmbDept.SelectedText= dept;
                txtSalary.Text = rdr["Salary"].ToString();
                designation = rdr["Designation"].ToString();
                listDesignation.SelectedItem = designation;

            }
            else
            {
                MessageBox.Show("Employee information not available!!!!");
            }

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            string gender = "";
            string dept = "";
            string designation = "";
            cmbDept.SelectedIndex = -1;
            txtSalary.Text = "";
            listDesignation.SelectedIndex = -1;
            radioButton1.Checked = radioButton2.Checked = false;

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select * from tblEmp_info ei inner join tblEmp_office_details eo on ei.empid=eo.empid  where ei.empid=" + txtEmpId.Text.Trim();
            cmd1.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.Read())
            {                
                txtEmpName.Text = rdr["name"].ToString();
                gender = rdr["gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            
                dept = rdr["dept"].ToString();
                cmbDept.SelectedText = dept;
                txtSalary.Text = rdr["Salary"].ToString();
                designation = rdr["Designation"].ToString();
                listDesignation.SelectedItem = designation;

            }
            else
            {
                MessageBox.Show("Employee information not available!!!!");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            string gender = "";
            string dept = "";
            string designation = "";
            cmbDept.SelectedIndex = -1;
            txtSalary.Text = "";
            listDesignation.SelectedIndex = -1;
            radioButton1.Checked = radioButton2.Checked = false;

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "sp_select_empBy_id";
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@id", txtEmpId.Text.Trim());

            SqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.Read())
            {
                txtEmpName.Text = rdr["name"].ToString();
                gender = rdr["gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                dept = rdr["dept"].ToString();
                cmbDept.SelectedText = dept;
                txtSalary.Text = rdr["Salary"].ToString();
                designation = rdr["Designation"].ToString();
                listDesignation.SelectedItem = designation;

            }
            else
            {
                MessageBox.Show("Employee information not available!!!!");
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            cmbDept.ResetText();
            txtSalary.Text = "";
            listDesignation.ResetText();

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "  select * from tblEmp_info ei inner join tblEmp_office_details eod on ei.empid=eod.empid  where ei.empid=" + txtEmpId.Text.Trim();
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr= cmd.ExecuteReader();
            if (rdr.Read())//true
            {
                txtEmpName.Text = rdr["name"].ToString();
                if (rdr["gender"].ToString()=="Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

                cmbDept.SelectedText = rdr["dept"].ToString();           
                txtSalary.Text = rdr["Salary"].ToString();
                listDesignation.SelectedValue = rdr["Designation"].ToString();
            }
            else
            {
                MessageBox.Show("Record not available!!!!!");
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            cmbDept.ResetText();
            txtSalary.Text = "";
            listDesignation.SelectedItem = null;

            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=DB_130324_ADO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_select_emp_join_new";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid",txtEmpId.Text);

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())//true
            {
                txtEmpName.Text = rdr["name"].ToString();
                if (rdr["gender"].ToString() == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

                cmbDept.SelectedText = rdr["dept"].ToString();
                txtSalary.Text = rdr["Salary"].ToString();

               string designation = rdr["Designation"].ToString();
                listDesignation.SelectedItem = designation;

            }
            else
            {
                MessageBox.Show("Record not available!!!!!");
            }

            con.Close();
        }
    }
}
