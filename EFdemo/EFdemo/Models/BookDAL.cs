using EFdemo.Data;

namespace EFdemo.Models
{
    public class BookDAL
    {
        private ApplicationDbContext db;
        public BookDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Book> GetBooks()
        {

            return db.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            var model = db.Books.Where(x => x.Bid == id).SingleOrDefault();
            return model;
        }

        public int AddBook(Book book)
        {
            int result = 0;
            db.Books.Add(book);
            result = db.SaveChanges();
            return result;
        }

        public int EditBook(Book book)
        {
            int result = 0;
            var model = db.Books.Where(x => x.Bid == book.Bid).SingleOrDefault();
            if (model != null)
            {
                model.Bid = book.Bid;
                model.Bname = book.Bname;
                model.Bprice = book.Bprice;
                result = db.SaveChanges();

            }
            return result;
        }
        public int DeleteBook(int id)
        {
            int result = 0;
            var model = db.Books.Where(x => x.Bid == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Books.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
