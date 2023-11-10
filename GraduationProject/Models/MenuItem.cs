using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Taste { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [ForeignKey("menu")]
        public int MenuId { get; set; }
        public Menu menu { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
