using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTO
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your username.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters.")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

      //  public string Picture { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number can only contain numbers.")]
        [StringLength(11, ErrorMessage = "Phone number cannot exceed 11 characters.")]
        public string Phone { get; set; }
     
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

    }
}
