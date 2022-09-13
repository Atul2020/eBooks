using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Book> Books { get; set; }
    }
}
