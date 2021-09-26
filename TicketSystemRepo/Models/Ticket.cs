using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystemRepo.Models
{
    public class Ticket
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Summary { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }
        public bool Resolved { get; set; }
        public int Severity { get; set; }
        public int Priotiry { get; set; }
        public Guid? CreaterId { get; set; }
        public TicketUser Creater { get; set; }
        public Guid? ResolverId { get; set; }
        public TicketUser Resolver { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
    }
}