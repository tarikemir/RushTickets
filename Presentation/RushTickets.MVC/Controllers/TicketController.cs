using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RushTickets.Persistence.Contexts;
using System;
using System.Linq;
using RushTickets.Domain.Entities;
using RushTickets.Persistence;
using System.Net.Sockets;

namespace RushTicket.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly RushTicketsDbContext _dbContext;

        public TicketController(RushTicketsDbContext dbContext)
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
        public IActionResult CreateTicket(TicketDto ticketDto)
        {
            //if (string.IsNullOrEmpty(ticketDto.Name) || string.IsNullOrEmpty(ticketDto.Description))
            //{
            //    TempData["ErrorMessage"] = "Name and description are required.";
            //    return RedirectToAction("Index");
            //}


            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();


                ViewBag.ErrorMessages = errors;

                return View();

            }
            else
            {
                var ticket = new Ticket
                {

                    Name = ticketDto.Name,
                    Description = ticketDto.Description,
                    Price = ticketDto.Price
                };

                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");

            }


        }
    }
}