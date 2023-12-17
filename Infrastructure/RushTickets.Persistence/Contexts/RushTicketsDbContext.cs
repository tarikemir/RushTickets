using Microsoft.EntityFrameworkCore;
using RushTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence.Contexts
{
    public class RushTicketsDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public RushTicketsDbContext(DbContextOptions<RushTicketsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }


    }
}
