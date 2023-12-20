using Microsoft.EntityFrameworkCore;
using RushTickets.Application.Repositories;
using RushTickets.Domain.Entities;
using RushTickets.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase<Guid>
    {
        private readonly RushTicketsDbContext _context;
        public ReadRepository(RushTicketsDbContext context)
        {
            _context = context;
        }

        public Microsoft.EntityFrameworkCore.DbSet<T> Table => _context.Set<T>();

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(string id)
        {
            return Table.FirstOrDefault(x => x.Id == Guid.Parse(id));
        }
        
    }
}
