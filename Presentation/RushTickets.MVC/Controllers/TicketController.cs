using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RushTickets.Persistence.Contexts;
using System;
using System.Linq;
using RushTickets.Persistence.Repositories.TicketRepositories;
using RushTickets.Domain.Entities;
namespace RushTicket.MVC.Controllers
{
    public class TicketController : Controller
    {
        //private readonly RushTicketsDbContext _dbContext;

        //public TicketController( RushTicketsDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        private readonly TicketReadRepository _ticketReadRepository;
        private readonly TicketWriteRepository _ticketWriteRepository;
    

        public TicketController(TicketReadRepository ticketReadRepository, TicketWriteRepository ticketWriteRepository)
        {
            _ticketReadRepository = ticketReadRepository;
            _ticketWriteRepository = ticketWriteRepository;
            
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            List<Ticket> tickets = _ticketReadRepository.GetAll();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult CreateTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTicket(string name, string description, decimal price)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                TempData["ErrorMessage"] = "Name and description are required.";
                return RedirectToAction("Index");
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }
            var ticket = new Ticket
            {
                CreatedByUserId = User.Identity.Name,
                Name = name,
                Description = description,
                Price = price
            };

            _ticketWriteRepository.Add(ticket);
            _ticketWriteRepository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}