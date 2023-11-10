using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class ForgetPassword
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ChangePass { get; set; }
    }
}
