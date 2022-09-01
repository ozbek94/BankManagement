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
    public class TransferController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWithdrawRepository _withdrawRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly ICommissionCaseRepository _comissioncaseRepository;
        private readonly AccountTransactionService _accountTransactionService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public TransferController(IWithdrawRepository withdrawRepository, ICustomerRepository customerRepository,
            IAccountRepository accountRepository, IAccountTransactionRepository accountTransactionRepository,
            ICommissionCaseRepository comissioncaseRepository, AccountTransactionService accountTransactionService,
            IConfiguration config, ITransferRepository transferRepository, IMapper mapper)
        {
            this._withdrawRepository = withdrawRepository;
            this._customerRepository = customerRepository;
            this._accountRepository = accountRepository;
            this._accountTransactionRepository = accountTransactionRepository;
            this._comissioncaseRepository = comissioncaseRepository;
            this._accountTransactionService = accountTransactionService;
            this._config = config;
            this._transferRepository = transferRepository;
            this._mapper = mapper;
        }
        [HttpPut("TransferForOperator")]
        public async Task<IActionResult> TransferCheck(int transferId)
        {
            var SystemId = _config.GetValue<int>("applicationUrl:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");

            Transfer transfer = await _transferRepository.GetByTransferId(transferId);
            if (transfer == null && transfer.IsCompleted != false)
            {
                return BadRequest("Transfer is not found..");
            }
            Customer sender = await _customerRepository.GetByCustomerId(transfer.SenderId);
            if (sender == null)
            {
                return BadRequest("Customer is not found..");
            }

            Customer receiver = await _customerRepository.GetByCustomerId(transfer.ReceiverId);
            if (sender == null)
            {
                return BadRequest("Customer is not found..");
            }

            Account senderAccount = await _accountRepository.GetByAccountId(transfer.SenderAccountId);
            if (senderAccount == null)
            {
                return BadRequest("Account is not found..");
            }

            Account receiverAccount = await _accountRepository.GetByAccountId(transfer.ReceiverAccountId);
            if (receiverAccount == null)
            {
                return BadRequest("Account is not found..");
            }

            var commissionCase = await _comissioncaseRepository.GetByCaseTransactionId((int)TransactionTypeEnum.Transfer);
            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }

            senderAccount.withdraw(transfer.Amount);
            receiverAccount.deposit(transfer.Amount - commissionCase.ComissionAmount);

            await _accountRepository.UpdateAccount(senderAccount);
            await _accountRepository.UpdateAccount(receiverAccount);

            transfer.CompletionTime = DateTime.Now;
            transfer.IsCompleted = true;

            await _transferRepository.Update(transfer);

            await _accountTransactionService.AccountTransactionsCreater(transfer.AccountTransactionId,
               TransactionTypeEnum.Transfer, transfer.Amount,
               commissionCase, transfer.SenderId, transfer.ReceiverId,
                SystemId, SystemBsmvId);

            return NoContent();
        }

        [HttpGet("Transfers")]
        public async Task<IActionResult> Transfers()
        {
            return Ok(_mapper.Map<IEnumerable<TransferModel>>(await _transferRepository.GetTransfers()));
        }
    }
}
