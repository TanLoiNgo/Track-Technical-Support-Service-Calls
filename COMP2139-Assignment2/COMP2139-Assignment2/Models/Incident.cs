using System;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [Range(1, 10000, ErrorMessage = "Please choose customer.")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Range(1, 10000, ErrorMessage = "Please choose product.")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int? TechnicianId { get; set; }

        public Technician Technician { get; set; }

        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }
    }
}
