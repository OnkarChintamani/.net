using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class BookDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public BookDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connstr = this.configuration.GetConnectionString("DefaultConnetion");
            con = new SqlConnection(connstr);
        }
        // list
        public List<Book> GetBooks()
        {
            List<Book> booklist = new List<Book>();
            string qry = "select * from book";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(dr["bid"]);
                    book.Name = dr["bname"].ToString();
                    book.Author = dr["author"].ToString();
                    book.Price = Convert.ToDouble(dr["bprice"]);
                    booklist.Add(book);
                }
            }
            con.Close();
            return booklist;
        }
        // add
        public int AddBooks(Book book)
        {
            int result = 0;
            string qry = "insert into book values(@bname,@author,@bprice)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@bname", book.Name);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@bprice", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //edit
        public int EditBook(Book book)
        {
            int result = 0;
            string qry = "update book set bname=@bname,author=@author,bprice=@bprice where bid=@bid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@bid", book.Id);
            cmd.Parameters.AddWithValue("@bname", book.Name);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@bprice", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //select single stud
        public Book GetBookByID(int id)
        {
            Book book= new Book();
            string qry = "select * from book where bid=@bid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@bid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    book.Id = Convert.ToInt32(dr["bid"]);
                    book.Name = dr["bname"].ToString();
                    book.Author = dr["author"].ToString();
                    book.Price = Convert.ToDouble(dr["bprice"]);
                }
            }
            con.Close();
            return book;
        }
        public int DeleteBook(int id)
        {
            int result = 0;
            string qry = "delete from book where bid=@bid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@bid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
