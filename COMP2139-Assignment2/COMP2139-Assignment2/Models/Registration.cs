using System;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1.Models
{
    public class Registration
    {

        [Range(1, 10000, ErrorMessage = "Please choose product.")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Range(1, 10000, ErrorMessage = "Please choose customer.")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
