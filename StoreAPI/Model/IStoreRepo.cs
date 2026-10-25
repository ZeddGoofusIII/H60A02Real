using StoreAPI.Model;
using StoreAPI.Services;

namespace StoreAPI.Model
{
    public interface IStoreRepo
    {
        Task<List<Product>> GetProducts();

        Task<List<ProductCategory>> GetCategories();

        Task<bool> InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int  productId);

        void DeleteCategory(int categoryId);

        void UpdateCategory(ProductCategory productCategory);

        void addCategory(ProductCategory category);

        Task<Product> GetProductById(int? productId);

        Task<ProductCategory> GetCategoryById(int? categoryId);

        void UpdateStock(int productid, int stockChange );

        void UpdatePrice(PriceHelper helper);
        void save();

        Task<List<Product>> ProductsByCategory(int  categoryId);

        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomerById(int? customerId);
        
        public void UpdateCustomer(Customer customer);

        public void DeleteCustomer(int customerId);

        public void AddCustomer(Customer customer);
    }
}
