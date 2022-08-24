using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedTechnicians : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
                new Technician
                {
                    Id = 1,
                    Name = "Alison Diaz",
                    Email = "alison@sportsprosoftware.com",
                    Phone = "800 555 0443"
                },
                new Technician
                {
                    Id = 2,
                    Name = "Andrew Wilson",
                    Email = "AWilson@sportsprosoftware.com",
                    Phone = "800 555 9999"
                },
                new Technician
                {
                    Id = 3,
                    Name = "Gina Fiori",
                    Email = "GFiori@sportsprosoftware.com",
                    Phone = "800 555 7777"
                }
                );
        }
    }
}
