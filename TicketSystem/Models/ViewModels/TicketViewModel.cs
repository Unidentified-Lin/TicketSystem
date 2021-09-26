using System;
using TicketSystemRepo.Models;

namespace TicketSystem.Models.ViewModels
{
    public class TicketViewModel
    {
        public Guid Guid { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool Resolved { get; set; }
        public Guid? CreaterId { get; set; }
        public TicketUser Creater { get; set; }
        public Guid? ResolverId { get; set; }
        public TicketUser Resolver { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
    }
}