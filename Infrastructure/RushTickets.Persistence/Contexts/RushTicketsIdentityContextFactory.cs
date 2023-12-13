using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushTickets.Infrastructure.Contexts;

namespace RushTickets.Persistence.Contexts
{
    public class RushTicketsIdentityContextFactory : IDesignTimeDbContextFactory<RushTicketsIdentityContext>
    {
        public RushTicketsIdentityContext CreateDbContext(string[] args)
        {
            /*
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("PrivateInformations.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RushTicketsIdentityContext>();

            var connectionString = configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

            optionsBuilder.UseNpgsql(connectionString);

            return new RushTicketsIdentityContext(optionsBuilder.Options);
            */
        }
    }
}
