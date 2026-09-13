using A01.models;
using Microsoft.EntityFrameworkCore;

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
            _context.Add(product);
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
    }
}
