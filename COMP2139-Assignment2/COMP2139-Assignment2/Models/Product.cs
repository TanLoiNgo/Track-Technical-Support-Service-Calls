using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter product's code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter product's name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter product's name.")]
        public double YearlyPrice { get; set; }

        [Required(ErrorMessage = "Please enter product's released date.")]
        public DateTime ReleasedDate { get; set; }

        //nagivgation property to linking entity
        public ICollection<Registration> Registrations { get; set; }


    }
}
