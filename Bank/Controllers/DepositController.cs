using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Bank.Domain.Services;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace BankUI.Controllers
{
    [Route("Deposit")]
    [ApiController]

    public class DepositController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDepositRepository _depositRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly ICommissionCaseRepository _comissioncaseRepository;
        private readonly AccountTransactionService _accountTransactionService;
        private readonly IConfiguration _config;

        public DepositController(IDepositRepository depositRepository, ICustomerRepository customerRepository,
            IAccountRepository accountRepository, IAccountTransactionRepository accountTransactionRepository,
            ICommissionCaseRepository comissioncaseRepository, AccountTransactionService accountTransactionService,
            IConfiguration config)
        {
            this._depositRepository = depositRepository;
            this._customerRepository = customerRepository;
            this._accountRepository = accountRepository;
            this._accountTransactionRepository = accountTransactionRepository;
            this._comissioncaseRepository = comissioncaseRepository;
            this._accountTransactionService = accountTransactionService;
            this._config = config;
        }
        [HttpPut("DepositCheck")]

        public async Task<IActionResult> DepositCheck(int depositId)
        {
            var SystemId = _config.GetValue<int>("PartyId:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");

            Deposit deposit = await _depositRepository.GetByDepositId(depositId);
            if(deposit == null && deposit.IsCompleted != false)
            {
                return BadRequest("Deposit is not found..");
            }
            Customer customer = await _customerRepository.GetByCustomerId(deposit.PartyId);
            if (customer == null)
            {
                return BadRequest("Customer is not found..");
            }

            Account account = await _accountRepository.GetByAccountId(deposit.AccountId);
            if (account == null) 
            {
                return BadRequest("Account is not found..");
            }

            var commissionCase = await _comissioncaseRepository.GetByCaseId(5);
            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }
            

            account.deposit(deposit.Amount);
            await _accountRepository.UpdateAccount(account);
            
            deposit.CompletionTime = DateTime.Now;
            deposit.IsCompleted = true;
            
            await _depositRepository.Update(deposit);

            await _accountTransactionService.AccountTransactionsCreater(deposit.AccountTransactionId,
                TransactionTypeEnum.Deposit, deposit.Amount,
                commissionCase, deposit.PartyId, 0,
                 SystemId, SystemBsmvId);


            return NoContent();

        }
    }
}
