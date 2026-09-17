using A01.models;

namespace A01.Models
{
    public interface IStoreRepo
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<ProductCategory> GetCategories();

        bool InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int  productId);

        void DeleteCategory(int categoryId);

        void UpdateCategory(ProductCategory productCategory);

        void addCategory(ProductCategory category);

        Product GetProductById(int productId);

        ProductCategory GetCategoryById(int categoryId);

        void UpdateStock(int productid, int stockChange );
        void save();
    }
}
