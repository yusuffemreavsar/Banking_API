﻿using Banking_API.Domain.Entities.Common;
using Banking_API.Domain.Entities.Identity;

namespace Banking_API.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
