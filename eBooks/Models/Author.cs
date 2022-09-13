using System.ComponentModel.DataAnnotations;

namespace eBooks.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorProfilePicture { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBio { get; set; }

        public List<Author_Book> Author_Books { get; set; }


    }
}
