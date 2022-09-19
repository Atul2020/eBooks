using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//model for the table reviews
namespace eBooks.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string BookReview { get; set; }
        public int BookRating { get; set; }
        [Display(Name ="Book Name")]
        
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        [ValidateNever]
        public Book Book { get; set; }

     
    }
}
