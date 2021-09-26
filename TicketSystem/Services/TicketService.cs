using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TicketSystem.Models.ViewModels;
using TicketSystem.Services.Interfaces;
using TicketSystemRepo.Interfaces;
using TicketSystemRepo.Models;

namespace TicketSystem.Services
{
    public class TicketService : GenericService<Ticket>, ITicketService
    {
        private readonly IUnitOfWorks _unitofWorks;
        private readonly IMapper _mapper;
        private readonly UserManager<TicketUser> _manager;

        public TicketService(IUnitOfWorks unitOfWorks, IMapper mapper, UserManager<TicketUser> manager) : base(unitOfWorks, mapper)
        {
            _unitofWorks = unitOfWorks;
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<string> AddTicket(TicketViewModel vm, ClaimsPrincipal user)
        {
            try
            {
                vm.CreatedDate = DateTime.Now;
                TicketUser theUser = await _manager.GetUserAsync(user);
                vm.Creater = theUser;
                vm.CreaterId = theUser.Id;
                this.CreateViewModelToDatabase(vm);
                return "ticket added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<TicketViewModel> GetTickets()
        {
            var vms = this.GetListToViewModel<TicketViewModel>();
            return vms;
        }

        public async Task<string> Resolve(Guid ticketId, ClaimsPrincipal user)
        {
            try
            {
                var repo = _unitofWorks.Repository<Ticket>();
                Ticket theTicket = repo.GetById(ticketId);
                if (theTicket.Resolved)
                {
                    return "Already resolved";
                }
                theTicket.ResolvedDate = DateTime.Now;
                theTicket.Resolved = true;
                TicketUser theUser = await _manager.GetUserAsync(user);
                theTicket.ResolverId = theUser.Id;

                repo.Update(theTicket);
                _unitofWorks.SaveChange();

                return "Resolved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}