using System;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMP2139_Assignment1.DataLayer.SeedData
{
    internal class SeedRegistrations : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> entity)
        {
            entity.HasData(
                new Registration { ProductId = 1, CustomerId = 1 },
                new Registration { ProductId = 2, CustomerId = 1 },
                new Registration { ProductId = 3, CustomerId = 1 },
                new Registration { ProductId = 1, CustomerId = 2 },
                new Registration { ProductId = 2, CustomerId = 3 }
                );
        }
    }
}
