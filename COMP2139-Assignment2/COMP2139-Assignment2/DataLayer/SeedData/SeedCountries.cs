using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedCoutries : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Australia"
                },
                new Country
                {
                    Id = 2,
                    Name = "Brazil"
                },
                new Country
                {
                    Id = 3,
                    Name = "Canada"
                },
                new Country
                {
                    Id = 4,
                    Name = "France"
                },
                new Country
                {
                    Id = 5,
                    Name = "Germany"
                },
                new Country
                {
                    Id = 6,
                    Name = "USA"
                },
                new Country
                {
                    Id = 7,
                    Name = "Vietnam"
                }

                );
        }
    }
}
