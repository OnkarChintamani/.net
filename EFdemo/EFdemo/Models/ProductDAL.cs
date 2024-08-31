using EFdemo.Data;

namespace EFdemo.Models
{
    public class ProductDAL
    {
        ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            var model = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return model;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result = db.SaveChanges();
            return result;
        }

        public int EditProduct(Product product)
        {
            int result = 0;
            var model = db.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault();
            if (model != null)
            {
                model.ProductId = product.ProductId;
                model.ProductName = product.ProductName;
                model.ProductPrice = product.ProductPrice;
                result = db.SaveChanges();

            }
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Products.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
