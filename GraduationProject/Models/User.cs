﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GraduationProject.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
       // public string Picture { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your username.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string Phone { get; set; }
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
