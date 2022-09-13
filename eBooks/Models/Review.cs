using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBooks.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string BookReview { get; set; }
        public int BookRating { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }
        //public int UserID { get; set; }
    }
}
