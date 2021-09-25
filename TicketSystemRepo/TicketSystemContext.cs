using System;
using TicketSystemRepo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemRepo
{
    public class TicketSystemContext : IdentityDbContext<TicketUser, IdentityRole<Guid>, Guid>
    {
        // public DbSet<Device> Devices { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }

        public TicketSystemContext()
        {
        }

        public TicketSystemContext(DbContextOptions<TicketSystemContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<TicketUser>(b => b.ToTable("Users"));
            // modelBuilder.Entity<IdentityRole<Guid>>(b => b.ToTable("Roles"));
            // modelBuilder.Entity<IdentityUserRole<Guid>>(b => b.ToTable("UserRoles"));
            // modelBuilder.Entity<IdentityUserClaim<Guid>>(b => b.ToTable("UserClaims"));
            // modelBuilder.Entity<IdentityUserLogin<Guid>>(b => b.ToTable("UserLogins"));
            // modelBuilder.Entity<IdentityUserToken<Guid>>(b => b.ToTable("UserToken"));
            // modelBuilder.Entity<IdentityRoleClaim<Guid>>(b => b.ToTable("RoleClaims"));
        }
    }
}
