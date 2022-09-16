using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class Publication
    {
        [Key]
        public int PublicationID { get; set; }
        public string PublicationLogo { get; set; }
        public string PublicationName { get; set; }
        public string PublicationFamousBooks { get; set; }
        [ValidateNever]
        public List<Book> Books { get; set; }
    }
}
