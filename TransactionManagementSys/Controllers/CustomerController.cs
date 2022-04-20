using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionManagement.Model.ViewModel;
using TransactionManagement.Service;

namespace TransactionManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customer;

        public CustomerController(CustomerService customer)
        {
            _customer = customer;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _customer.CreateCustomer(customerVM);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
