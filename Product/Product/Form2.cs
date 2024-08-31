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

namespace Product
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
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            con = new SqlConnection(constr);
        }

        public DataSet GetAllProducts()
        {
            string qry = "select * from product";

            da = new SqlDataAdapter(qry, con);

            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            scb = new SqlCommandBuilder(da);

            ds = new DataSet();

            da.Fill(ds, "product");
            return ds;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllProducts();

                DataRow row = ds.Tables["product"].NewRow();

                row["productname"] = txtProductName.Text;
                row["productprice"] = txtProductPrice.Text;

                ds.Tables["product"].Rows.Add(row);

                int result = da.Update(ds.Tables["product"]);

                if (result >= 1)
                {
                    MessageBox.Show("Record Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllProducts();
                DataRow row = ds.Tables["product"].Rows.Find(txtProductId.Text);
                if (row != null)
                {
                    // override the value from textbox to row
                    row["productname"] = txtProductName.Text;
                    row["productprice"] = txtProductPrice.Text;

                    int result = da.Update(ds.Tables["product"]);
                    if (result >= 1)
                    {
                        MessageBox.Show("Record updated");

                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllProducts();
                DataRow row = ds.Tables["product"].Rows.Find(txtProductId.Text);
                if (row != null)
                {
                    txtProductName.Text = row["productname"].ToString();
                    txtProductPrice.Text = row["productprice"].ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductPrice.Clear();
            txtProductName.Clear();
            txtProductId.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllProducts();
                DataRow row = ds.Tables["product"].Rows.Find(txtProductId.Text);
                if (row != null)
                {
                    row.Delete();

                    int result = da.Update(ds.Tables["product"]);
                    if (result >= 1)
                    {
                        MessageBox.Show("Record deleted");

                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ds = GetAllProducts();

            dataGridView1.DataSource = ds.Tables["product"];

        }
    }
}
