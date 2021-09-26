using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystemRepo.Models
{
    public class ActionLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string Action { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Msg { get; set; }
        public DateTime LoggedDate { get; set; }
        public Guid? UserId { get; set; }
        public TicketUser User { get; set; }
    }
}