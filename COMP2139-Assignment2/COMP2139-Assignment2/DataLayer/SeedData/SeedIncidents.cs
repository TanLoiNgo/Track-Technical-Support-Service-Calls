using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedIncidents : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(
                new Incident
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Title = "Error launching program",
                    Description = "Program fails with error code 510, unable to open database",
                    TechnicianId = 1,
                    DateOpened = new DateTime(2020, 10, 1),
                    DateClosed= new DateTime(2021, 1, 1)
                },
                new Incident
                {
                    Id = 2,
                    CustomerId = 3,
                    ProductId = 2,
                    Title = "Could not install",
                    Description = "Program fails with error code 500, unable to open database",
                    TechnicianId = 2,
                    DateOpened = new DateTime(2020, 12, 1)
                },
                new Incident
                {
                    Id = 3,
                    CustomerId = 3,
                    ProductId = 3,
                    Title = "Error importing data",
                    Description = "Program fails with error code 510, unable to open database",
                    DateOpened = new DateTime(2021, 1, 1)
                },
                new Incident
                {
                    Id = 4,
                    CustomerId = 2,
                    ProductId = 2,
                    Title = "Error launching program",
                    Description = "Program fails with error code 510, unable to open database",
                    DateOpened = new DateTime(2020, 10, 1),
                    DateClosed = new DateTime(2021, 3, 1)
                }
                );
        }
    }
}
