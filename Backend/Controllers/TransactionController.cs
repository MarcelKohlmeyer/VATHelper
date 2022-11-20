
using System.Text;
using Microsoft.AspNetCore.Mvc;
using VATHelper.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionWorker _worker;
        public TransactionController(ITransactionWorker transactionWorker)
        {
            _worker = transactionWorker;
        }
        
        [HttpGet]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult("TransactionController works!");
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionFromFile(IFormFile file)
        {
            var input = new StringBuilder();
            using var reader = new StreamReader(file.OpenReadStream());
            while (reader.Peek() >= 0)
                input.AppendLine(reader.ReadLine());
            Guid result =  await _worker.AddTransaction(input.ToString(), file.FileName);
            return Ok(result);
        }
    }
}

