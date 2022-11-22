﻿using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace AspUI.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The name must be a minimum of 3 characters and a maximum of 20 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field cannot be left empty!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field cannot be left blank!")]
        [EmailAddress(ErrorMessage = "This field must be a mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field cannot be left blank!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field cannot be left blank!")]
        public string Password { get; set; }
    }
}
