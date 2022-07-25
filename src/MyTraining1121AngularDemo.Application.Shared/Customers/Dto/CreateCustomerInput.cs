using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class CreateCustomerInput
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}

