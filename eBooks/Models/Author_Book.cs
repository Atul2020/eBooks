using System.ComponentModel.DataAnnotations;
//table that has the authorID with the respective BookID's
//Many to many relationship
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
