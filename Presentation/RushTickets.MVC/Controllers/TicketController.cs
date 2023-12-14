using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RushTickets.Persistence.Contexts;
using System;
using System.Linq;
using RushTickets.Domain.Entities;
namespace RushTicket.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly RushTicketsDbContext _dbContext;

        public TicketController( RushTicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Ticket> tickets = _dbContext.Tickets.ToList();
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

            var ticket = new Ticket
            {

                Name = name,
                Description = description,
                Price = price
            };

            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}