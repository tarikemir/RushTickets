﻿namespace RushTickets.Domain.Entities
{
    public interface IModifiedByEntity
    {
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}