
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VATHelper.Interfaces;
using VATHelper.Models;

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
        public async Task<IActionResult> GetTransactions()
        {
            return Ok(await _worker.GetTransactions());
        }

        [HttpPost("ByFile")]
        public async Task<IActionResult> AddTransactionFromFile(IFormFile file)
        {
            var input = new StringBuilder();
            using var reader = new StreamReader(file.OpenReadStream());
            while (reader.Peek() >= 0)
                input.AppendLine(reader.ReadLine());
            Guid result = await _worker.AddTransaction(input.ToString(), file.FileName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionManually([FromBody]Transaction input)
        {
            return Ok();
        }
    }
}

