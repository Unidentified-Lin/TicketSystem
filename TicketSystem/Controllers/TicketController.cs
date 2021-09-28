using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketSystem.Models;
using TicketSystem.Models.ViewModels;
using TicketSystem.Services.Interfaces;

namespace TicketSystem.Controllers
{
    [Authorize(Policy = "readpolicy")]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _service;

        public TicketController(ITicketService service, ILogger<TicketController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "writepolicy")]
        public JsonResult NewTicket([FromBody] TicketViewModel vm)
        {
            var result = _service.AddTicket(vm, User);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetTickets()
        {
            var tickets = _service.GetTickets();
            return Json(tickets);
        }

        [HttpPost]
        [Authorize(Policy = "resolvepolicy")]
        public JsonResult Resolve([FromBody] Guid ticketId)
        {
            var result = _service.Resolve(ticketId, User);
            return Json(result);
        }
    }
}