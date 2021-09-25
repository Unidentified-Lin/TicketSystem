using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystemRepo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TicketSystem.Areas.Identity
{
    public class TicketUserManager : UserManager<TicketUser>
    {
        public TicketUserManager(IUserStore<TicketUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TicketUser> passwordHasher, IEnumerable<IUserValidator<TicketUser>> userValidators, IEnumerable<IPasswordValidator<TicketUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TicketUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        // public DateTime GetJoinDate(TicketUser user)
        // {
        //     return user.JoinDate;
        // }

        // public async Task<IdentityResult> SetJoinDateAsync(TicketUser user, DateTime joinDate)
        // {
        //     user.JoinDate = joinDate;
        //     var result = await Store.UpdateAsync(user, CancellationToken);
        //     return result;
        // }
    }
}