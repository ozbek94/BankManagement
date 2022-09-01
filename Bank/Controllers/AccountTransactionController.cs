using AutoMapper;
using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using BankUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    [Route("AccountTransaction")]
    [ApiController]
    public class AccountTransactionController : ControllerBase
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IMapper _mapper;
        public AccountTransactionController(IAccountTransactionRepository accountTransactionRepository, 
            IMapper mapper)
        {
            this._accountTransactionRepository = accountTransactionRepository;
            this._mapper = mapper;
        }

        [HttpGet("AccountTransactionByTransactionTypeId")]
        public async Task<IActionResult> TransactionByTransactionTypeName(int transactionTypeId)
        {
            var AccountTransactions =  _mapper.Map<IEnumerable<AccountTransactionModel>>(await _accountTransactionRepository
                .GetAccountTransactionsByTransactionType(transactionTypeId));

            if (AccountTransactions != null)
            {
                return Ok(AccountTransactions);
            }
            else
            {
                return NoContent();
            }
        }

        private static List<AccountTransaction> NewMethod(string TransactionTypeName, List<AccountTransaction> AccountTransactions)
        {
            List<AccountTransaction> AccountTransactionsTypeNames = new List<AccountTransaction>();
            foreach (var item in AccountTransactions)
            {
                if (item.TransactionTypeName != null)
                {
                    if (item.TransactionTypeName.ToLower() == (TransactionTypeName.ToLower()))
                    {
                        AccountTransactionsTypeNames.Add(item);
                    }
                }
                //else if (item.TransactionTypeName.ToLower() == (TransactionTypeName.ToLower()))
                //{
                //    AccountTransactionsTypeNames.Add(item);
                //}
                //else
                //{
                //    continue;
                //}
            }

            return AccountTransactionsTypeNames;
        }
    }
}
