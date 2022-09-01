using AutoMapper;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Domain.Repositories;
using Bank.Domain.Services;
using BankUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    public class WithdrawController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWithdrawRepository _withdrawRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly ICommissionCaseRepository _comissioncaseRepository;
        private readonly AccountTransactionService _accountTransactionService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public WithdrawController(IWithdrawRepository withdrawRepository, ICustomerRepository customerRepository,
            IAccountRepository accountRepository, IAccountTransactionRepository accountTransactionRepository,
            ICommissionCaseRepository comissioncaseRepository, AccountTransactionService accountTransactionService,
            IConfiguration config, IMapper mapper)
        {
            this._withdrawRepository = withdrawRepository;
            this._customerRepository = customerRepository;
            this._accountRepository = accountRepository;
            this._accountTransactionRepository = accountTransactionRepository;
            this._comissioncaseRepository = comissioncaseRepository;
            this._accountTransactionService = accountTransactionService;
            this._config = config;
            this._mapper = mapper;
        }
        [HttpPut ("WithdrawForOparator")]
        public async Task<IActionResult> WithdrawCheck(int withdrawId)
        {
            var SystemId = _config.GetValue<int>("PartyId:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");

            Withdraw withdraw = await _withdrawRepository.GetByWithdrawId(withdrawId);
            if (withdraw == null && withdraw.IsCompleted != false)
            {
                return BadRequest("Withdraw is Not Fount");
            }
            Customer customer = await _customerRepository.GetByCustomerId(withdraw.PartyId);
            if (customer == null)
            {
                return BadRequest("Customer is not found..");
            }

            Account account = await _accountRepository.GetByAccountId(withdraw.AccountId);
            if (account == null)
            {
                return BadRequest("Account is not found..");
            }

            var commissionCase = await _comissioncaseRepository.GetByCaseTransactionId((int)TransactionTypeEnum.Withdraw);
            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }

            account.withdraw(withdraw.Amount);
            await _accountRepository.UpdateAccount(account);

            withdraw.CompletionTime = DateTime.Now;
            withdraw.IsCompleted = true;

            await _withdrawRepository.Update(withdraw);

            await _accountTransactionService.AccountTransactionsCreater(withdraw.AccountTransactionId,
                TransactionTypeEnum.Withdraw, withdraw.Amount,
                commissionCase, withdraw.PartyId, 0,
                 SystemId, SystemBsmvId);

            return NoContent();
        }
        [HttpGet("Witdraws")]
        public async Task<IActionResult> Withdraws()
        {
            return Ok(_mapper.Map <IEnumerable<WithdrawModel>>(await _withdrawRepository.GetWithdraws()));
        }
    }
}
