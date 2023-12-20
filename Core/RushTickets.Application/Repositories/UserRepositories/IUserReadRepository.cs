using RushTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Application.Repositories.UserRepositories
{
    public interface IUserReadRepository<T>: IReadRepository<T> where T : EntityBase<T>
    {
    }
}
