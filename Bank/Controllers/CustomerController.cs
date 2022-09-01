using AutoMapper;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Domain.Repositories;
using BankUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICommissionCaseRepository _commissionCaseRepository;
        private readonly ITransactionLimitRepository _transactionLimitRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IDepositRepository _depositRepository;
        private readonly IWithdrawRepository _withdrawRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerRepository customerRepository, IAccountRepository accountRepository,
            ICommissionCaseRepository commissionCaseRepository, IMapper mapper, IConfiguration config,
            ITransactionLimitRepository transactionLimitRepository, IDepositRepository depositRepository,
            IAccountTransactionRepository accountTransactionRepository, IWithdrawRepository withdrawRepository,
            ITransferRepository transferRepository, ILogger<CustomerController> logger)
        {
            this._customerRepository = customerRepository;
            this._accountRepository = accountRepository;
            this._commissionCaseRepository = commissionCaseRepository;
            this._mapper = mapper;
            this._transactionLimitRepository = transactionLimitRepository;
            this._accountTransactionRepository = accountTransactionRepository;
            this._config = config;
            this._depositRepository = depositRepository;
            this._withdrawRepository = withdrawRepository;
            this._transferRepository = transferRepository;

            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Customer(CustomerModel customerCreationModel)
        {   
            var customer = _mapper.Map<Customer>(customerCreationModel);
            
            await _customerRepository.CreateCustomer(customer);

            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customerModel = _mapper.Map<CustomerModel> (await _customerRepository.GetByCustomerId(id));

            _logger.Log(LogLevel.Information, "Kaan Geçir");
                
            if (customerModel != null)
            {
                return Ok(customerModel);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> Customers()
        {

            var customerModels = _mapper.Map<IEnumerable<CustomerModel>>(await _customerRepository.GetCustomers());

            if (customerModels != null)
            {
                return Ok(customerModels);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerModel customerModel)
        {
            var customer = await _customerRepository.GetByCustomerId(id);

            if (customer == null)
            {
                return BadRequest("Customer is not found..");
            }

            customer.Name = customerModel.Name;
            await _customerRepository.Update(customer);

            return NoContent();
        }
        [HttpPut("withdraw")]
        public async Task<IActionResult> WithdrawCustomerAccount(int customerId, int accountId, int amount)
        {
            Guid guid = Guid.NewGuid();
            var SystemId = _config.GetValue<int>("PartyId:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");
            int transactionTypeId = (int)TransactionTypeEnum.Withdraw;
            var customer = await _customerRepository.GetByCustomerId(customerId);
            if (customer == null)
            {
                return BadRequest("Customer is not found..");
            }

            var account = await _accountRepository.GetByAccountId(accountId);

            if (account == null)
            {
                return BadRequest("Account is not found..");
            }

            if (account.Balance < amount)
            {
                return BadRequest("insufficient balance");
            }

            var commissionCase = await _commissionCaseRepository.GetByCaseTransactionId(transactionTypeId);

            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }

            var transactionLimit = await _transactionLimitRepository.GetByTransactionLimitId(2); 

            if (amount + commissionCase.ComissionAmount > transactionLimit.TransferTypeLimit)
            {
                return BadRequest("Over the Withdraw Limit");
            }

            Withdraw withdraw = new Withdraw()
            {
                PartyId = customerId,
                Amount = amount,
                AccountId = accountId,
                AccountTransactionId = guid
            };

            await _withdrawRepository.CreateWithdraaw(withdraw);

            account.withdraw(amount);

            return NoContent();
        }

       

        [HttpPut("deposit")]
        public async Task<IActionResult> DepositCustomerAccount(int customerId, int accountId, int amount)
        {
            Guid guid = Guid.NewGuid();
            var SystemId = _config.GetValue<int>("PartyId:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");
            int transactionTypeId = (int)TransactionTypeEnum.Deposit;

            var customer = await _customerRepository.GetByCustomerId(customerId);
            
            if (customer == null)
            {

                return BadRequest("Customer is not found..");
            }

            var account = await _accountRepository.GetByAccountId(accountId);

            if (account == null)
            {
                return BadRequest("Account is not found..");
            }

            var commissionCase = await _commissionCaseRepository.GetByCaseTransactionId(transactionTypeId);

            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }

            var transactionLimit = await _transactionLimitRepository.GetByTransactionLimitId(1);

            if (amount > transactionLimit.TransferTypeLimit)
            {
                return BadRequest("Over the Deposit Limit");
            }

            Deposit deposit = new Deposit()
            {
                PartyId = customerId,
                Amount = amount,
                AccountId = accountId,
                AccountTransactionId = guid
            };

            await _depositRepository.CreateDeposit(deposit);

            

            return NoContent();
        }

        [HttpPut("transfer")]
        public async Task<IActionResult> TransferAccountToOtherAccounnt(int senderId, int receiverId, int accountId, 
            int accountId1, int amount)
        {
            Guid guid = Guid.NewGuid();
            //string TransactionType = "transfer";

            int transactionTypeId = (int)TransactionTypeEnum.Transfer;

            var SystemId = _config.GetValue<int>("PartyId:SystemId");
            var SystemBsmvId = _config.GetValue<int>("PartyId:SystemBsvmId");

            var customer = await _customerRepository.GetByCustomerId(senderId);
            var customer1 = await _customerRepository.GetByCustomerId(receiverId);

            if (customer == null && customer1 == null)
            {
                return BadRequest("Customer is not found..");
            }

            var account = await _accountRepository.GetByAccountIMd(accountId);
            var account1 = await _accountRepository.GetByAccountId(accountId1);
            

            if (account == null && account1 == null)
            {
                return BadRequest("Account is not found..");
            }
            
            if(account.Balance < amount)
            {
                return BadRequest("insufficient balance");
            }

            var commissionCase = await _commissionCaseRepository.GetByCaseTransactionId(transactionTypeId);

            if (commissionCase == null)
            {
                return BadRequest("Case is not found..");
            }

            var transactionLimit = await _transactionLimitRepository.GetByTransactionLimitId(3);

            if (amount > transactionLimit.TransferTypeLimit)
            {
                return BadRequest("Over the Transfer Limit");
            }


            Transfer transfer = new Transfer()
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Amount = amount,
                SenderAccountId = accountId,
                ReceiverAccountId = accountId1,
                AccountTransactionId = guid
            };
            await _transferRepository.CreateTransfer(transfer);

            return NoContent();
        }


        [HttpPost("Assing")]
        public async Task<IActionResult> AssingAccountModelToCustomer(AccountModel accountModel, int customerId)
        {
            var customer = _customerRepository.GetByCustomerId(customerId);
            if(customer == null)
            {
                return BadRequest("Customer is not found");
            }
            
            var account = _mapper.Map<Account>(accountModel);
            account.CustomerId = customerId;
            await _accountRepository.CreateAccount(account);
            
            return Ok();
        }
    }
}
