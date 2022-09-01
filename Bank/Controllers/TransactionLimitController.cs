using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    [Route("TransactionLimit")]
    [ApiController]
    public class TransactionLimitController : ControllerBase
    {
        private readonly ITransactionLimitRepository _transactionLimitRepository;
        public TransactionLimitController(ITransactionLimitRepository transactionLimitRepository)
        {
            this._transactionLimitRepository = transactionLimitRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCase(TransactionLimit transactionLimit)
        {
            await _transactionLimitRepository.CreateTransactionLimit(transactionLimit);

            return Ok();
        }
    }
}
