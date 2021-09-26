using System;
using System.Collections.Generic;
using AutoMapper;
using TicketSystemRepo.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystem.Services.AutoMapper
{
    public class DBToDomainProfile : Profile
    {
        public DBToDomainProfile()
        {
            CreateMap<Ticket, TicketViewModel>();
        }
    }
}
