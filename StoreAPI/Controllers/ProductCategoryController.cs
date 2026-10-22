using Microsoft.AspNetCore.Mvc;
using StoreAPI.Model;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IStoreRepo _storeRepo;

        public ProductCategoryController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategory>>> GetCategories()
        {
            return await _storeRepo.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetCategory(int id)
        {
            var category = await _storeRepo.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public IActionResult CreateCategory(ProductCategory category)
        {
            _storeRepo.addCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.ProductCategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, ProductCategory category)
        {
            if (id != category.ProductCategoryId)
            {
                return BadRequest();
            }
            _storeRepo.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _storeRepo.DeleteCategory(id);
            return NoContent();
        }
    }
}
