using System.Collections.Generic;
using System;

namespace GraduationProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public int TotalPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order() { }
        public Order(string UserId)
        {
            this.UserId = UserId;
        }
    }
}
