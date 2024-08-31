using System.Data.SqlClient;
using CRUDusingADO.Models;
namespace CRUDusingADO.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connstr = this.configuration.GetConnectionString("DefaultConnetion");
            con = new SqlConnection(connstr);
        }
        // list
        public List<Product> GetProducts()
        {
            List<Product> productlist = new List<Product>();
            string qry = "select * from product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(dr["productid"]);
                    product.Name = dr["productname"].ToString();
                    product.Price = Convert.ToDouble(dr["productprice"]);
                    productlist.Add(product);
                }
            }
            con.Close();
            return productlist;
        }
        //details
        public Product GetProductById(int id)
        {
            Product product = new Product();
            string qry = "select * from product where productid=@productid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    product.Id = Convert.ToInt32(dr["productid"]);
                    product.Name = dr["productname"].ToString();
                    product.Price = Convert.ToDouble(dr["productprice"]);
                }
            }
            con.Close();
            return product;
        }
        // add
        public int AddProduct(Product prdt)
        {
            int result = 0;
            string qry = "insert into product values(@productname,@productprice)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productname", prdt.Name);
            cmd.Parameters.AddWithValue("@productprice", prdt.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int EditProduct(Product prdt)
        {
            int result = 0;
            string qry = "update product set productname=@productname,productprice=@productprice where productid=@productid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productname", prdt.Name);
            cmd.Parameters.AddWithValue("@productprice", prdt.Price);
            cmd.Parameters.AddWithValue("@productid", prdt.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteProductt(int id)
        {
            int result = 0;
            string qry = "delete from product where productid=@productid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
