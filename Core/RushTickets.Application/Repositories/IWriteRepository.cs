using RushTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : EntityBase<Guid>
    {
        void Add(T entity);
        void Delete(string id);
        void SaveChanges();
    }
}
