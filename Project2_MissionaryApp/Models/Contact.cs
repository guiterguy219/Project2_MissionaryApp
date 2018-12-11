using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2_MissionaryApp.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }
    }
}