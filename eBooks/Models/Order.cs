using System.ComponentModel.DataAnnotations;
//model for the table order
namespace eBooks.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
