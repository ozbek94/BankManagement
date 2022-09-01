using AutoMapper;
using Bank.Domain.Entities;
using BankUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Profiles
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {

            CreateMap<TransferModel, Transfer>()
                .ForMember(
                dest => dest.SenderId,
                opt => opt.MapFrom(src => src.SenderId))
                .ForMember(
                dest => dest.ReceiverId,
                opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(
                dest => dest.SenderAccountId,
                opt => opt.MapFrom(src => src.SenderAccountId))
                .ForMember(
                dest => dest.ReceiverAccountId,
                opt => opt.MapFrom(src => src.ReceiverAccountId))
                .ForMember(
                dest => dest.CompletionTime,
                opt => opt.MapFrom(src => src.CompletionTime))
                .ForMember(
                dest => dest.IsCompleted,
                opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(
                dest => dest.AccountTransactionId,
                opt => opt.MapFrom(src => src.AccountTransactionId));

            CreateMap<Transfer, TransferModel>()
               .ForMember(
               dest => dest.SenderId,
               opt => opt.MapFrom(src => src.SenderId))
               .ForMember(
               dest => dest.ReceiverId,
               opt => opt.MapFrom(src => src.ReceiverId))
               .ForMember(
               dest => dest.SenderAccountId,
               opt => opt.MapFrom(src => src.SenderAccountId))
               .ForMember(
               dest => dest.ReceiverAccountId,
               opt => opt.MapFrom(src => src.ReceiverAccountId))
               .ForMember(
               dest => dest.CompletionTime,
               opt => opt.MapFrom(src => src.CompletionTime))
               .ForMember(
               dest => dest.IsCompleted,
               opt => opt.MapFrom(src => src.IsCompleted))
               .ForMember(
               dest => dest.AccountTransactionId,
               opt => opt.MapFrom(src => src.AccountTransactionId));

        }
    }
}
