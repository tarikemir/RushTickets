using Microsoft.EntityFrameworkCore;
using RushTickets.Domain.Entities;
using RushTickets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
