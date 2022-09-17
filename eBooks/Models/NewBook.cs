
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eBooks.Models
{
    public class NewBook
    {
        public int BookID { get; set; }

        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Book Name is required")]
        public string BookName { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Book Description is required")]
        public string BookDescription { get; set; }

        [Display(Name = "Price in Rs.")]
        [Required(ErrorMessage = "Book Price is required")]
        public double BookPrice { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string BookImageURL { get; set; }

        [Display(Name = "Publication Date")]
        [Required(ErrorMessage = "Publication Date is required")]
        public DateTime BookPublicationDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Book category is required")]
        public int CategoryID { get; set; }

        //Relationships
        [Display(Name = "Select Author")]
        [Required(ErrorMessage = "Book Author is required")]
        public List<int> AuthorIDs { get; set; }

        [Display(Name = "Select a Publication")]
        [Required(ErrorMessage = "Publication is required")]
        public int PublicationID { get; set; }

    }
}
