using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

       

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarks.Clear();
            txtName.Clear();
            txtRollNo.Clear();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);
                dataGridView1.DataSource = table;
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

                string qry = "insert into student values(@name,@marks)";

                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@marks", txtMarks.Text);


                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {

                string qry = "update student set name=@name,marks=@marks where rollno=@rollno";
                // create object of command and assign the query
                cmd = new SqlCommand(qry, con);
                // assign values to parameters
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@marks", txtMarks.Text);
                cmd.Parameters.AddWithValue("@rollno", txtRollNo.Text);
                // fire the query
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {

                string qry = "delete from student where rollno=@rollno";
                // create object of command and assign the query
                cmd = new SqlCommand(qry, con);
                // assign values to parameters
                cmd.Parameters.AddWithValue("@rollno", txtRollNo.Text);
                // fire the query
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                // step 1
                string qry = "select * from student where rollno=@rollno";
                // step2
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollno", txtRollNo.Text);
                //step3 execute the qry
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows) // whether row is present or not
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["name"].ToString();
                        txtMarks.Text = dr["marks"].ToString();
                    }
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
