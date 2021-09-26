using System;
using AutoMapper;
using TicketSystemRepo.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystem.Services.AutoMapper
{
    public class DomainToDBProfile : Profile
    {
        public DomainToDBProfile()
        {
            CreateMap<TicketViewModel, Ticket>();
        }
    }
}
