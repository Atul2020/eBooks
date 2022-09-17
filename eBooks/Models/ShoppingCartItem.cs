using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        public Book Book { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
