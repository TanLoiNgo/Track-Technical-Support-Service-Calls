using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Email = "kanthoni@gpe.com",
                    City = "San Francisco",
                    State = "LA",
                    PostalCode = "M6N 3W5",
                    CountryId = 1,
                    Phone = "416 555 1111",
                    Address = "55 Lapp St"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Email = "ania@mma.nidc.com",
                    City = "Washington",
                    State = "LA",
                    PostalCode = "M6N 3W5",
                    CountryId = 1,
                    Phone = "416 547 3543",
                    Address = "55 Lapp St"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Gonzaloo",
                    LastName = "Keeton",
                    Email = "Zoon@mma.nidc.com",
                    City = "Toronto",
                    State = "ON",
                    PostalCode = "M6N 3W5",
                    CountryId = 3,
                    Phone = "416 547 5555",
                    Address = "71 Lapp St"
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "King",
                    LastName = "Kee",
                    Email = "King@mma.nidc.com",
                    City = "Toronto",
                    State = "ON",
                    PostalCode = "M6N 3W5",
                    CountryId = 3,
                    Phone = "416 547 9999",
                    Address = "111 Lapp St"
                }
                );
        }
    }
}
