
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Model;

[Route("api/[controller]")]
[ApiController]

public class ProductsController : ControllerBase
{
    private readonly H60AssignmentDbZlContext _context;

    public ProductsController(H60AssignmentDbZlContext context)
    {
        _context = context;
    }

    [HttpGet]
   public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

}
