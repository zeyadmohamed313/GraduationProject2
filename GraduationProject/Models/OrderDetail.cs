using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class OrderDetail
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


        [ForeignKey("menuItem")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }//null //eager loading 

        public OrderDetail() { }
        public OrderDetail(int OrderId, int MenuItemId)
        {
            this.OrderId = OrderId;
            this.MenuItemId = MenuItemId;
            Quantity = 0;

        }
    }
}
