using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class SpecializationsForDoctors
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }

    }
}
