using RushTickets.Application.Repositories.UserRepositories;
using RushTickets.Domain.Identity;
using RushTickets.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence.Repositories.UserRepositories
{
    public class UserReadRepository<T> : ReadRepository<User>, IUserReadRepository<User>
    {
        public UserReadRepository(RushTicketsDbContext context) : base(context)
        {
        }
    }
}
