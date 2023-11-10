using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Image { get; set; }
        public bool HasDelivery { get; set; }
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
        [ForeignKey("menu")]
        public int MenuId { get; set; }
        public Menu menu{ get; set; }

        [ForeignKey("categoryForRestaurant")]
        public int CategoryResturandId { get; set; }
        public CategoryForRestaurant categoryForRestaurant { get; set; }
        //  public object Description { get; internal set; }

        //time for open
        //description for address
    }
}
