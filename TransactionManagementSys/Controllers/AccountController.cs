using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionManagement.Model.ViewModel;
using TransactionManagement.Service;

namespace TransactionManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _account;

        public AccountController(AccountService account)
        {
            _account = account;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAccount(CreateAccountVM accountVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _account.CreateAccount(accountVM);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
