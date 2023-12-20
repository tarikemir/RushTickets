using RushTickets.Domain.Enums;
using RushTickets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Domain.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>, ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {
        public virtual TKey Id { get; set; }

        public virtual string CreatedByUserId { get; set; }
        public virtual DateTimeOffset CreatedOn { get; set; }
        public virtual string? ModifiedByUserId { get; set; }
        public virtual DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public virtual string? DeletedByUserId { get; set; }
        public virtual DateTimeOffset? DeletedOn { get; set; }

        public bool Equals(TKey? other)
        {
            throw new NotImplementedException();
        }
    //    public class Ticket : EntityBase<Ticket>
    //    {
    //        public Guid Id { get; set; }
    //        public string Name { get; set; }
    //        public string Description { get; set; }
    //        public decimal Price { get; set; }

    //    }
    //    public class User : EntityBase<User>
    //    {
    //        public string FirstName { get; set; }
    //        public string SurName { get; set; }

    //        public DateTimeOffset? BirthDate { get; set; }
    //        public Gender Gender { get; set; }

    //        public UserSetting UserSetting { get; set; }

    //        public string CreatedByUserId { get; set; }
    //        public DateTimeOffset CreatedOn { get; set; }
    //        public string? ModifiedByUserId { get; set; }
    //        public DateTimeOffset? LastModifiedOn { get; set; }
    //    }
    }
}
