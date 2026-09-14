using A01.models;
using Microsoft.EntityFrameworkCore;
using A01.Services;
namespace A01.Models
{
    public class StoreRepo : IStoreRepo
    {

        private readonly H60AssignmentDbZlContext _context;

        public StoreRepo(H60AssignmentDbZlContext context)
        {
            _context = context;
        } 

        public void addCategory(ProductCategory category)
        {
            _context.Add(category);
            save();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.ProductCategories.Where(x =>  x.CategoryId == categoryId).FirstOrDefault();
            if (category != null) {
                _context.ProductCategories.Remove(category);           
            }
            save();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            save() ;
        }

        public IEnumerable<ProductCategory> GetCategories()
        {
            var categories = _context.ProductCategories.ToList();
            return categories;
        }

        public ProductCategory GetCategoryById(int categoryId)
        {
            return _context.ProductCategories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            var pro = product;
            var cat = _context.ProductCategories.FirstOrDefault(x => x.CategoryId == pro.ProdCatId);
            pro.ProdCat = cat;
            _context.Products.Add(pro);
           
            save();
        }

        public void save()
        {
            _context.SaveChanges();
            save();
        }

        public void UpdateCategory(ProductCategory productCategory)
        {
            _context.Update(productCategory);
            save();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            save();
        }


        public void UpdateStock(int productId, int newStock)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                try
                {
                    Validation.ValidateStock(newStock, product);
                    product.Stock += newStock;
                    _context.SaveChanges();
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }
}
