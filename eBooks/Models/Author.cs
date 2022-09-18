using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
//Model containing the author details
namespace eBooks.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture is Mandatory")]
        public string AuthorProfilePicture { get; set; }
        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Name is Mandatory")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Should be between 3 and 30 characters")]
        public string AuthorName { get; set; }
        [Display(Name = "Author Bio")]
        [Required(ErrorMessage = "Biography is Mandatory")]
        public string AuthorBio { get; set; }

        [ValidateNever]
        public List<Author_Book> Author_Books { get; set; }


    }
}
