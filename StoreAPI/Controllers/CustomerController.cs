using Microsoft.AspNetCore.Mvc;
using StoreAPI.Model;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IStoreRepo _storeRepo;

        public CustomerController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _storeRepo.GetCustomers();
            return customers;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int? customerId)
        {
            var customer = await _storeRepo.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _storeRepo.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.CustomerId }, customer);
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, Customer customer)
        {
            customer.CustomerId = customerId;
            _storeRepo.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            _storeRepo.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
