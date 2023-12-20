using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    public class RushTicketsIdentityContext : IdentityDbContext<User, Role, Guid>
    {
        public RushTicketsIdentityContext(DbContextOptions<RushTicketsIdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
          foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    ((ICreatedByEntity)entry.Entity).CreatedOn = DateTime.UtcNow;
                }
                if (entry.State ==EntityState.Modified)
                {
                    ((IModifiedByEntity)entry.Entity).LastModifiedOn = DateTime.UtcNow;
                }
            }


            return base.SaveChanges();
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
