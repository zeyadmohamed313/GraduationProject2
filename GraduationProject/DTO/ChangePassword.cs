using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTO
{
    public class ChangePassword
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }

    }
}
