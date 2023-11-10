using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string TimeOfWork { get; set; }

    }
}
