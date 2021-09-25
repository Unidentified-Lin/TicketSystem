using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TicketSystemRepo.Models
{
    public class TicketUser : IdentityUser<Guid>
    {
        //Custom fields

        public ICollection<Ticket> CreateTickets { get; set; }
        public ICollection<Ticket> ResolveTickets { get; set; }
        public ICollection<ActionLog> ActionLogs { get; set; }
    }
}
