using RushTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : EntityBase<Guid>
    {
        List<T> GetAll();
        T GetById(string id);
    }
}
