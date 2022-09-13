using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class Author_Book
    {
       
        public int AuthorID { get; set; }
        public Book Book { get; set; }

        public int BookID { get; set; }
        public Author Author{ get; set; }
    }
}
