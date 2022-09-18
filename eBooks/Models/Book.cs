using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//model for the table books
namespace eBooks.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; } 
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public double BookPrice { get; set; }
        public string BookImageURL { get; set; }
        public DateTime BookPublicationDate { get; set; }

      
        public List<Review> Reviews { get; set; }
        public List<Author_Book> Author_Books { get; set; }


    
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        
        public int PublicationID { get; set; }
        [ForeignKey("PublicationID")]

        public Publication Publication { get; set; }
    }
}
