﻿
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult("TransactionController works!");
        }
    }
}

