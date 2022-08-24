using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_Assignment1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        [StringLength(51, ErrorMessage = "First name must have at least 1 and less than 51 characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1, ErrorMessage = "Last name must have at least 1 and less than 51 characters")]

        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please enter your city.")]
        [StringLength(51, MinimumLength = 1, ErrorMessage = "City must have at least 1 and less than 51 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(51, MinimumLength = 1, ErrorMessage = "Address must have at least 1 and less than 51 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your state.")]
        [StringLength(51, MinimumLength = 1, ErrorMessage = "State must have at least 1 and less than 51 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your postal code.")]
        [StringLength(21, MinimumLength = 1, ErrorMessage = "Postal Code must have at least 1 and less than 51 characters")]
        public string PostalCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please number must be in (999) 999-9999")]
        [DisplayFormat(DataFormatString = "{0:(###)###-####}")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please select country.")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        [StringLength(21, MinimumLength = 1, ErrorMessage = "Email must have at least 1 and less than 51 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid Email address")]
        [Display(Name = "Email")]
        [Remote("CheckEmail", "Validation")]
        public string Email { get; set; }

        //nagivgation property to linking entity
        public ICollection<Registration> Registrations { get; set; }

    }
}
