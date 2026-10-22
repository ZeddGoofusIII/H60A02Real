
using Microsoft.EntityFrameworkCore;
using StoreAPI.Model;
using StoreAPI.Services;
namespace StoreAPI.Model;

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

    public void DeleteCategory(int productCategoryId)
    {
        var category = _context.ProductCategories.Where(x =>  x.ProductCategoryId == productCategoryId).FirstOrDefault();
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
        save();
    }

    public bool InsertProduct(Product product)
    { 
        _context.Products.Add(product);
       
        save();
        return true;
    }

    public void save()
    {
        _context.SaveChanges();
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

    public void UpdatePrice(PriceHelper helper)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == helper.ProdId);
        if (product != null)
        {
            try
            {
                Validation.ValidatePrice(helper);
                product.SellPrice = helper.SellPrice;
                product.BuyPrice = helper.BuyPrice;
                _context.Update(product);
                save();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }

    public void UpdateStock(int productId, int stockChange)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
        if (product != null)
        {
            try
            {
                Validation.ValidateStock(stockChange, product);
                product.Stock += stockChange;
                save();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }

    Task<List<ProductCategory>> IStoreRepo.GetCategories()
    {
        return Task.FromResult(_context.ProductCategories.ToList());
    }

    Task<bool> IStoreRepo.InsertProduct(Product product)
    {
        return Task.FromResult(InsertProduct(product));
    }

    Task<Product> IStoreRepo.GetProductById(int? productId)
    {
        return Task.FromResult(_context.Products.Include(p => p.ProdCat).FirstOrDefault(x => x.ProductId == productId));
    }

    Task<ProductCategory> IStoreRepo.GetCategoryById(int? categoryId)
    {
        return Task.FromResult(_context.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == categoryId));
    }

    Task<List<Product>> IStoreRepo.ProductsByCategory(int categoryId)
    {
        return Task.FromResult(_context.Products.Where(p => p.ProductCategoryId == categoryId).Include(p => p.ProdCat).ToList());
    }

    Task<List<Product>> IStoreRepo.GetProducts()
    {
        return Task.FromResult(_context.Products.Include(p => p.ProdCat).OrderBy(p => p.ProdCat.ProdCat).ToList());
    }
}


