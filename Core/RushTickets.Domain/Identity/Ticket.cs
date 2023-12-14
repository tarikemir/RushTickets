﻿using System;
namespace RushTickets.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}