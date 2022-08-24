using System;
using COMP2139_Assignment1.DataLayer.SeedData;
using Microsoft.EntityFrameworkCore;
namespace COMP2139_Assignment1.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite primary key for Registration
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.CustomerId, r.ProductId });

            //One-to-many relationship between Product and Customer
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.CustomerId);

            //One-to-many relationship between Product and Customer
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Registrations)
                .HasForeignKey(r => r.ProductId);

            //Seed data
            modelBuilder.ApplyConfiguration(new SeedCoutries());
            modelBuilder.ApplyConfiguration(new SeedCustomers());
            modelBuilder.ApplyConfiguration(new SeedIncidents());
            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedRegistrations());
            modelBuilder.ApplyConfiguration(new SeedTechnicians());
        }
    }
}
