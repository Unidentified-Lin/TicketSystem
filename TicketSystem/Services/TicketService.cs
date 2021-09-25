using AutoMapper;
using TicketSystem.Services.Interfaces;
using TicketSystemRepo.Interfaces;
using TicketSystemRepo.Models;

namespace TicketSystem.Services
{
    public class TicketService : GenericService<Ticket>, ITicketService
    {
        private readonly IUnitOfWorks _unitofWorks;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWorks unitOfWorks, IMapper mapper) : base(unitOfWorks, mapper)
        {
            _unitofWorks = unitOfWorks;
            _mapper = mapper;
        }
    }
}