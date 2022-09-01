using AutoMapper;
using Bank.Domain.Entities;
using BankUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>()
                .ForMember(
                dest => dest.AccountNumber,
                opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember( 
                dest => dest.Balance,
                opt => opt.MapFrom(src => src.Balance));
                
        }
    }
}
