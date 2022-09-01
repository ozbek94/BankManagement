using AutoMapper;
using Bank.Domain.Entities;
using BankUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                dest => dest.Accounts,
                opt => opt.MapFrom(src => src.Accounts))
                .ForMember(
                dest => dest.Adresses,
                opt => opt.MapFrom(src => src.Adresses))
                .ForMember(
                dest => dest.NationalId,
                opt => opt.MapFrom(src => src.NationalId))
                .ForMember(
                dest => dest.Gsms,
                opt => opt.MapFrom(src => src.Gsms))
                .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<Customer, CustomerModel>()
               .ForMember(
               dest => dest.Name,
               opt => opt.MapFrom(src => src.Name))
               .ForMember(
               dest => dest.Surname,
               opt => opt.MapFrom(src => src.Surname))
               .ForMember(
               dest => dest.Accounts,
               opt => opt.MapFrom(src => src.Accounts))
               .ForMember(
               dest => dest.Adresses,
               opt => opt.MapFrom(src => src.Adresses))
               .ForMember(
               dest => dest.NationalId,
               opt => opt.MapFrom(src => src.NationalId))
               .ForMember(
               dest => dest.Gsms,
               opt => opt.MapFrom(src => src.Gsms))
               .ForMember(
               dest => dest.DateOfBirth,
               opt => opt.MapFrom(src => src.DateOfBirth));
        }
    }
}
