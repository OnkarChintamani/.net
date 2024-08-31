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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into product values(@name,@price)";

                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@price", txtProductPrice.Text);

                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result >= 1)
                {
                    MessageBox.Show("Record Inserted");
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
                string qry = "update product set productname=@name,productprice=@price where  productid=@id";

                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@price", txtProductPrice.Text);
                cmd.Parameters.AddWithValue("@id", txtProductId.Text);
                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result >= 1)
                {
                    MessageBox.Show("Record Updated");
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
                string qry = "delete from product where productid=@id";

                cmd = new SqlCommand(qry, con);


                cmd.Parameters.AddWithValue("@id", txtProductId.Text);
                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result >= 1)
                {
                    MessageBox.Show("Record Deleted");
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
                string qry = "select * from product where productid=@id";

                cmd = new SqlCommand(qry, con);


                cmd.Parameters.AddWithValue("@id", txtProductId.Text);
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtProductName.Text = dr["productname"].ToString();
                        txtProductPrice.Text = dr["productprice"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
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

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from product";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr= cmd.ExecuteReader();
                DataTable Table = new DataTable();
                Table.Load(dr);
                dataGridView1.DataSource = Table;
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

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
