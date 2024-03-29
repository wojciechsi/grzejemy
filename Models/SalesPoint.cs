﻿using Microsoft.AspNetCore.Identity;
namespace grzejemy.Models
{
    public class SalesPoint
    {
        public SalesPoint()
        {
            Vendor = new IdentityUser();
            Name = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            PostCode = string.Empty;
            City = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public IdentityUser Vendor { get; set; }
    }
}
