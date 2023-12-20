using Microsoft.EntityFrameworkCore;
using RushTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RushTickets.Application.Repositories
{
    public interface IRepository<T> where T : EntityBase<Guid>
    {
        DbSet<T> Table {  get; }
    }
}
