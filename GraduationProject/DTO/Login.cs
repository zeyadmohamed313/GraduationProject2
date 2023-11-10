using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTO
{
    public class Login
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
