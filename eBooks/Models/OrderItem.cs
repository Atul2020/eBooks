using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBooks.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int BookID { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
