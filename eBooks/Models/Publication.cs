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

        public List<Book> Books { get; set; }
    }
}
