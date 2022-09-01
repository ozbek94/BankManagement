using AutoMapper;
using Bank.Domain.Entities;
using BankUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Profiles
{
    public class WithdrawProfile : Profile
    {
        public WithdrawProfile()
        {
            CreateMap<WithdrawModel, Withdraw>()
                .ForMember(
                dest => dest.PartyId,
                opt => opt.MapFrom(src => src.PartyId))
                .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.AccountId))
                .ForMember(
                dest => dest.CompletionTime,
                opt => opt.MapFrom(src => src.CompletionTime))
                .ForMember(
                dest => dest.IsCompleted,
                opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(
                dest => dest.Amount,
                opt => opt.MapFrom(src => src.Amount))
                .ForMember(
                dest => dest.AccountTransactionId,
                opt => opt.MapFrom(src => src.AccountTransactionId));

            CreateMap<Withdraw, WithdrawModel>()
                .ForMember(
                dest => dest.PartyId,
                opt => opt.MapFrom(src => src.PartyId))
                .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.AccountId))
                .ForMember(
                dest => dest.CompletionTime,
                opt => opt.MapFrom(src => src.CompletionTime))
                .ForMember(
                dest => dest.IsCompleted,
                opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(
                dest => dest.Amount,
                opt => opt.MapFrom(src => src.Amount))
                .ForMember(
                dest => dest.AccountTransactionId,
                opt => opt.MapFrom(src => src.AccountTransactionId));

        }
    }
}
