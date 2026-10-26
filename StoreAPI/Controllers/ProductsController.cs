
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Model;
using StoreAPI.Services;

[Route("api/[controller]")]
[ApiController]

public class ProductsController : ControllerBase
{
    private readonly IStoreRepo _storeRepo;

    public ProductsController(IStoreRepo storeRepo)
    {
        _storeRepo = storeRepo;
    }

    [HttpGet]
   public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _storeRepo.GetProducts();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _storeRepo.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _storeRepo.InsertProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        product.ProductId = id;
        /*if (id != product.ProductId)
        {
            return BadRequest();
        }*/
        _storeRepo.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _storeRepo.DeleteProduct(id);
        return NoContent();
    }

    [HttpPut("Stockchange/{id}")]
    public IActionResult UpdateStock(int id, int stockChange)
    {
        _storeRepo.UpdateStock(id, stockChange);
        return NoContent();
    }

    [HttpPut("Pricechange/{id}")]
    public IActionResult UpdatePrice(int id, PriceHelper priceChange)
    {
        _storeRepo.UpdatePrice(priceChange);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery] string searchTerm)
    {
        return await _storeRepo.SearchProducts(searchTerm);
    }
}
