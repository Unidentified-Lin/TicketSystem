using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketSystem.Models.ViewModels;
using TicketSystemRepo.Models;

namespace TicketSystem.Services.Interfaces
{
    public interface ITicketService : IService<Ticket>
    {
        IEnumerable<TicketViewModel> GetTickets();
        Task<string> AddTicket(TicketViewModel vm, ClaimsPrincipal user);
    }
}
