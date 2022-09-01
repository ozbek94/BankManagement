using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Services
{
    public class AccountTransactionService
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IConfiguration _config;

        public AccountTransactionService(IAccountTransactionRepository accountTransactionRepository,
             IConfiguration config)
        {
            this._accountTransactionRepository = accountTransactionRepository;
            this._config = config;
        }

        public async Task AccountTransactionsCreater(Guid guid, TransactionTypeEnum transactionTypeId, int amount,
            CommissionCase commissionCase, int senderId, int? receiverId, int systemId, int systemBsmvId)
        {
            DateTime dateTime = DateTime.Now;

            if ((int)commissionCase.ComissionAmount > 0)
            {

                List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

                AddingAccountTransactionItemForComission(commissionCase, accountTransactions);

                AddingDataForAccountTransactionsColumn(guid, commissionCase, dateTime, accountTransactions,
                    senderId, receiverId, amount, systemId, systemBsmvId);

                await _accountTransactionRepository.CreateAccountTransactions(accountTransactions);
            }

            else if ((int)commissionCase.ComissionAmount == 0)
            {

                AccountTransaction accountTransaction = new AccountTransaction
                {
                    TransactionId = guid,
                    TransactionTypeId = ((int)TransactionTypeEnum.Deposit),
                    PartyId = senderId,
                    Debit = 0,
                    Credit = (amount * 100),
                    InsertTime = dateTime,
                    TransactionTypeName = TransactionTypeEnum.Deposit.ToString()
                };
                AccountTransaction accountTransaction1 = new AccountTransaction
                {
                    TransactionId = guid,
                    TransactionTypeId = ((int)TransactionTypeEnum.Deposit),
                    PartyId = 999,
                    Debit = (amount * 100),
                    Credit = 0,
                    InsertTime = dateTime,
                    TransactionTypeName = TransactionTypeEnum.Deposit.ToString()
                };

                List<AccountTransaction> accountTransactions = new List<AccountTransaction>();
                accountTransactions.Add(accountTransaction);
                accountTransactions.Add(accountTransaction1);

                await _accountTransactionRepository.CreateAccountTransactions(accountTransactions);
            }
            else
            {
                throw new Exception();
            }
        }

        private static void AddingDataForAccountTransactionsColumn(Guid guid, CommissionCase commissionCase,
            DateTime dateTime, List<AccountTransaction> accountTransactions, int senderId, int? recieverId,
            int amount, int systemId, int systemBsmvId)
        {
            foreach (var item in accountTransactions)
            {
                item.TransactionId = guid;
                item.TransactionTypeId = (int)commissionCase.TransactionTypeId;
                item.InsertTime = dateTime;
            }
                accountTransactions[0].Credit = 0;
                accountTransactions[1].Credit = (amount * 100);
                accountTransactions[2].Credit = 0;
                accountTransactions[3].Credit = ((commissionCase.ComissionAmount - commissionCase.Bsmv()) * 100);
                accountTransactions[4].Credit = 0;
                accountTransactions[5].Credit = (commissionCase.Bsmv() * 100);

                accountTransactions[0].Debit  = (amount * 100);
                accountTransactions[1].Debit = 0;
                accountTransactions[2].Debit = ((commissionCase.ComissionAmount - commissionCase.Bsmv()) * 100);
                accountTransactions[3].Debit = 0;
                accountTransactions[4].Debit = (commissionCase.Bsmv() * 100);
                accountTransactions[5].Debit = 0;

                accountTransactions[0].PartyId = senderId;
                accountTransactions[3].PartyId = systemId;
                accountTransactions[5].PartyId = systemBsmvId;

            if ((int)commissionCase.TransactionTypeId == (int)TransactionTypeEnum.Transfer)
            {
                foreach (var item in accountTransactions)
                {
                    item.TransactionTypeName = TransactionTypeEnum.Transfer.ToString();
                }
                accountTransactions[1].PartyId = (int)recieverId;
                accountTransactions[2].PartyId = (int)recieverId;
                accountTransactions[4].PartyId = (int)recieverId;
            }

            if ((int)commissionCase.TransactionTypeId == (int)TransactionTypeEnum.Withdraw)
            {
                foreach (var item in accountTransactions)
                {
                    item.TransactionTypeName = TransactionTypeEnum.Withdraw.ToString();
                }
                accountTransactions[1].PartyId = systemId;
                accountTransactions[2].PartyId = senderId;
                accountTransactions[4].PartyId = senderId;

            }
        }
        
        private static void AddingAccountTransactionItemForComission(CommissionCase commissionCase, 
           List<AccountTransaction> accountTransactions)
        {
            if(commissionCase.ComissionAmount > 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransactions.Add(accountTransaction);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransactions.Add(accountTransaction);
                }
            }
        }
        
    }
}