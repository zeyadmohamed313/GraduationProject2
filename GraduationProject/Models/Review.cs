using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }
        public User user { get; set; }
        [ForeignKey("menuItem")]
        public int MenuItemId { get; set; }
        public MenuItem menuItem { get; set; }
    }
}
