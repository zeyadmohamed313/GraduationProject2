using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin Admin { get; set; }

        public ICollection<CategoryForRestaurant> categoryFoRestaurants { get; set; }
        public ICollection<SpecializationsForDoctors> categoryForDoctors { get; set; }
       
    }
}
