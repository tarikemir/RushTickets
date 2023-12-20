using Microsoft.EntityFrameworkCore;
using RushTickets.Application.Repositories.TicketRepositories;
using RushTickets.Domain.Entities;
using RushTickets.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence.Repositories.TicketRepositories
{
    public class TicketReadRepository : ReadRepository<Ticket>, ITicketReadRepository
    {
        public TicketReadRepository(RushTicketsDbContext context) : base(context)
        {
        }
    }
}
