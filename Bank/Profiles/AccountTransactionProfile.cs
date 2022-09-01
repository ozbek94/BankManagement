using AutoMapper;
using Bank.Domain.Entities;
using BankUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Profiles
{
    public class AccountTransactionProfile : Profile
    {
        public AccountTransactionProfile()
        {
            CreateMap<AccountTransactionModel, AccountTransaction>()
                .ForMember(
                dest => dest.Credit,
                opt => opt.MapFrom(src => src.Credit))
                .ForMember(
                dest => dest.Debit,
                opt => opt.MapFrom(src => src.Debit))
                .ForMember(
                dest => dest.PartyId,
                opt => opt.MapFrom(src => src.PartyId))
                .ForMember(
                dest => dest.TransactionTypeName,
                opt => opt.MapFrom(src => src.TransactionTypeName))
                .ForMember(
                dest => dest.TransactionId,
                opt => opt.MapFrom(src => src.TransactionId));

            CreateMap<AccountTransaction, AccountTransactionModel>()
                .ForMember(
                dest => dest.Credit,
                opt => opt.MapFrom(src => src.Credit))
                .ForMember(
                dest => dest.Debit,
                opt => opt.MapFrom(src => src.Debit))
                .ForMember(
                dest => dest.PartyId,
                opt => opt.MapFrom(src => src.PartyId))
                .ForMember(
                dest => dest.TransactionTypeName,
                opt => opt.MapFrom(src => src.TransactionTypeName))
                .ForMember(
                dest => dest.TransactionId,
                opt => opt.MapFrom(src => src.TransactionId));
        }
    }
}
