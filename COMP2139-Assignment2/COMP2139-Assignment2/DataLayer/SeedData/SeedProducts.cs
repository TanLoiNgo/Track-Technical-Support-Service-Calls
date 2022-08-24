using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product
                {
                    Id = 1,
                    Code = "TRNY10",
                    Name = "Tournament Master 1.0",
                    YearlyPrice = 4.99,
                    ReleasedDate = new DateTime(2015, 1, 12, 12, 0, 0)
                },
                new Product
                {
                    Id = 2,
                    Code = "LEAG10",
                    Name = "League Scheduler 1.0",
                    YearlyPrice = 4.99,
                    ReleasedDate = new DateTime(2016, 5, 2, 12, 0, 0)
                },
                new Product
                {
                    Id = 3,
                    Code = "LEAGD",
                    Name = "League Scheduler Deluxe 1.0",
                    YearlyPrice = 7.99,
                    ReleasedDate = new DateTime(2017, 1, 12, 12, 0, 0)
                }
                );
        }
    }
}
