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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder scb;
        public Form2()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            con=new SqlConnection(constr);
        }

        private DataSet GetAllStudents()
        {
            string qry = "select * from student";
            da = new SqlDataAdapter(qry, con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds= new DataSet();  
            da.Fill(ds,"student");

            return ds;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllStudents();
                DataRow row = ds.Tables["student"].NewRow();
                row["name"] = txtName.Text;
                row["marks"] = txtMarks.Text;
                ds.Tables["student"].Rows.Add(row);
                int result = da.Update(ds.Tables["student"]);
                if (result >= 1)
                {
                    MessageBox.Show("Record Inserted...");
                }
                else
                {
                    MessageBox.Show("Record Not Inserted...");

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllStudents();
                DataRow row = ds.Tables["student"].Rows.Find(txtRollNo.Text);
                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["marks"] = txtMarks.Text;
                    int result = da.Update(ds.Tables["student"]);
                    if (result >= 1)
                    {
                        MessageBox.Show("Record updated...");
                        
                    }
                    else
                    {
                        MessageBox.Show("Record Not Updated...");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllStudents();
                DataRow row = ds.Tables["student"].Rows.Find(txtRollNo.Text);
                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtMarks.Text = row["marks"].ToString();
                }
                else
                {
                    MessageBox.Show("Record Not Found...");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show (ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllStudents();
                DataRow row = ds.Tables["student"].Rows.Find(txtRollNo.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["student"]);
                    if(result >= 1)
                    {
                        MessageBox.Show("Record Deleted...");
                        
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found...");
                    }
                }

            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ds= GetAllStudents();
            dataGridView1.DataSource = ds.Tables["student"];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarks.Clear();
            txtName.Clear();
            txtRollNo.Clear();
        }
    }
}
