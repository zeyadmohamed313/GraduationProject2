using System.Collections.Generic;
namespace GraduationProject.Models
{
    public class CategoryForRestaurant 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
