using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TicketSystemRepo.Models
{
    public class TicketUser : IdentityUser<Guid>
    {
        //Custom fields

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<ActionLog> ActionLogs { get; set; }
    }
}
