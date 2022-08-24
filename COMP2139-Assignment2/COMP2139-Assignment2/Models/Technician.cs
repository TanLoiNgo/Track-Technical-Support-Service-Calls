using System;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1.Models
{
    public class Technician
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone.")]
        public string Phone { get; set; }

    }
}
