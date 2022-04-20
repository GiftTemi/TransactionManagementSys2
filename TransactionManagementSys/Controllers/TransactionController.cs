using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionManagement.Model.ViewModel;
using TransactionManagement.Service;

namespace TransactionManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transation;

        public TransactionController(TransactionService transation)
        {
            _transation = transation;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostTransactions(CreateTransactionVM transactionVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _transation.PostTransactions(transactionVM);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
