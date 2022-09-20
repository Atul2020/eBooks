using eBooks.Data.Static;
using Microsoft.AspNetCore.Identity;
//The file where dummy data is inserted into the table through code-first approach
namespace eBooks.Models
{
    public class BookDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookDbContext>();

                context.Database.EnsureCreated();

                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            AuthorProfilePicture = "https://i.ibb.co/k9Q1cc4/Jkrowling.jpg",
                            AuthorName = "JK Rowling",
                            AuthorBio = "J.K. Rowling is the author of the much-loved series of seven Harry Potter novels, originally published between 1997 and 2007."
                        },
                        new Author()
                        {
                            AuthorProfilePicture = "https://i.ibb.co/30FhTPj/roalddahl.jpg",
                            AuthorName = "Roald Dahl",
                            AuthorBio = "Roald Dahl was a British novelist, short-story writer, poet, screenwriter, and wartime fighter pilot of Norwegian descent."
                        },
                        new Author()
                        {
                            AuthorProfilePicture = "https://i.ibb.co/4FXk69D/jacqueline-wilson.jpg",
                            AuthorName = "Jacqueline Wilson",
                            AuthorBio = "Dame Jacqueline Wilson DBE FRSL is an English novelist known for her popular children's literature."
                        },
                        new Author()
                        {
                            AuthorProfilePicture = "https://i.ibb.co/7kwXPBG/williamshakespeare.jpg",
                            AuthorName = "William Shakespeare",
                            AuthorBio = "William Shakespeare was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's greatest dramatist."
                        },
                        new Author()
                        {
                            AuthorProfilePicture = "https://i.ibb.co/SXj59Vj/stephen-king.jpg",
                            AuthorName = "Stephen King",
                            AuthorBio = "Stephen Edwin King is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels."
                        }
                    });
                    context.SaveChanges();
                }
                //Publication
                if (!context.Publications.Any())
                {
                    context.Publications.AddRange(new List<Publication>()
                    {
                        new Publication()
                        {
                            PublicationLogo = "https://i.ibb.co/b6zswNr/bloomsbury.jpg",
                            PublicationName = "Bloomsbury Publishing",
                            PublicationFamousBooks= "Harry Potter and the Philosopher's Stone (1997), Harry Potter and the Chamber of Secrets (1998)"
                        },
                        new Publication()
                        {
                            PublicationLogo = "https://i.ibb.co/BynY8VC/penguinrandomhouse.jpg",
                            PublicationName = "Penguin Random House",
                            PublicationFamousBooks = "The Dragons Promise,Soul Taken",

                        },
                        new Publication()
                        {
                            PublicationLogo = "https://i.ibb.co/p2p3SHh/graywolfpress.png",
                            PublicationName = "Graywolf Press ",
                            PublicationFamousBooks= "The Apprentice,The Argonauts"

                        },
                        new Publication()
                        {
                            PublicationLogo = "https://i.ibb.co/QPzCmfW/akshaic-books.png",
                            PublicationName = "Akashic Books ",
                            PublicationFamousBooks= "My mom: secret novelist,Black Sheep ",

                        },
                        new Publication()
                        {
                            PublicationLogo = "https://i.ibb.co/CtDs7mv/hangingloosepress.png",
                            PublicationName= "Hanging Loose Press",
                            PublicationFamousBooks = "Making Maxine's Baby,Stone Fences",

                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName="Adventure"
                        },
                        new Category()
                        {
                            CategoryName="Mystery"
                        },
                        new Category()
                        {
                            CategoryName="Romance"
                        },
                        new Category()
                        {
                            CategoryName="Sci-Fy"
                        },
                        new Category()
                        {
                            CategoryName="Contemporary"

                        }
                    });
                    context.SaveChanges();
                }
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            BookName = "Harry Potter and the Deathly Hallows",
                            BookDescription = "Harry Potter and the Deathly Hallows is a fantasy novel written by British author J. K. Rowling",
                            BookPrice = 39.50,
                            BookImageURL = "https://i.ibb.co/m4B98f5/harrypotteranddeathlyhallows.jpg",
                            BookPublicationDate = Convert.ToDateTime("22/07/2007"),
                            PublicationID = 1,
                            CategoryID=1
                        },
                        new Book()
                        {
                            BookName = "Charlie and the Chocolate Factory",
                            BookDescription = "Charlie and the Chocolate Factory is a 1964 children's novel by British author Roald Dahl.",
                            BookPrice = 100.50,
                            BookImageURL = "https://i.ibb.co/7CsVLHd/Charlieandthe-Chocolate-Factory.jpg",
                            BookPublicationDate = Convert.ToDateTime("23/05/2007"),
                            PublicationID =2,
                            CategoryID=2
                        },
                        new Book()
                        {
                            BookName = "The Suitcase Kid",
                            BookDescription = "The Suitcase Kid is a children's novel written by Jacqueline Wilson and illustrated by Nick Sharratt. ",
                            BookPrice = 80.50,
                            BookImageURL = "https://i.ibb.co/f0yhhDd/The-Suitcase-Kid.jpg",
                            BookPublicationDate = Convert.ToDateTime("30/06/1992"),
                            PublicationID = 3,
                            CategoryID=3
                        },

                        new Book()
                        {
                            BookName = "Hamlet",
                            BookDescription = "The Tragedy of Hamlet, Prince of Denmark, often shortened to Hamlet is a tragedy written by William Shakespeare sometime between 1599 and 1601.",
                            BookPrice = 76.50,
                            BookImageURL = "https://i.ibb.co/vj7Zc5S/hamlet.jpg",
                            BookPublicationDate = Convert.ToDateTime("23/07/2007"),
                            PublicationID = 4,
                            CategoryID=4
                        },
                        new Book()
                        {
                            BookName = "The Stand",
                            BookDescription = "The Stand is a post-apocalyptic dark fantasy novel written by American author Stephen King and first published in 1978 by Doubleday.",
                            BookPrice = 45.50,
                            BookImageURL = "https://i.ibb.co/NnZdYm2/thestand.jpg",
                            BookPublicationDate = Convert.ToDateTime("15/02/2007"),
                            PublicationID = 5,
                            CategoryID=5
                        }
                    });
                    context.SaveChanges();
                }

                //Books and Authors
                if (!context.Author_Books.Any())
                {
                    context.Author_Books.AddRange(new List<Author_Book>()
                    {
                        new Author_Book()
                        {
                            BookID = 1,
                            AuthorID = 1
                        },
                        new Author_Book()
                        {
                            BookID = 1,
                            AuthorID = 3
                        },

                         new Author_Book()
                        {
                            BookID = 2,
                            AuthorID = 1
                        },
                         new Author_Book()
                        {
                            BookID = 2,
                            AuthorID = 4
                        },

                        new Author_Book()
                        {
                            BookID = 3,
                            AuthorID = 1
                        },
                        new Author_Book()
                        {
                            BookID = 3,
                            AuthorID = 2
                        },
                        new Author_Book()
                        {
                            BookID = 3,
                            AuthorID = 5
                        },


                        new Author_Book()
                        {
                            BookID = 4,
                            AuthorID = 2
                        },
                        new Author_Book()
                        {
                            BookID = 4,
                            AuthorID= 3
                        },
                        new Author_Book()
                        {
                            BookID = 4,
                            AuthorID = 4
                        },


                        new Author_Book()
                        {
                            BookID = 5,
                            AuthorID = 2
                        },
                        new Author_Book()
                        {
                            BookID = 5,
                            AuthorID= 3
                        },
                        new Author_Book()
                        {
                            BookID = 5,
                            AuthorID = 4
                        },
                        new Author_Book()
                        {
                            BookID = 5,
                           AuthorID = 5
                        },


                     
                        new Author_Book()
                        {
                            BookID = 1,
                            AuthorID = 4
                        },
                        new Author_Book()
                        {
                            BookID = 2,
                            AuthorID = 5
                        },
                    });
                    context.SaveChanges();
                }
                //Review
                if (!context.Reviews.Any())
                {
                    context.Reviews.AddRange(new List<Review>()
                    {
                        new Review()
                        {
                            BookReview="The book is really good",
                            BookRating=5,
                            BookID=1
                        },
                        new Review()
                        {
                            BookReview="nice book",
                            BookRating=3,
                            BookID=2
                        },
                        new Review()
                        {
                            BookReview="terrible book",
                            BookRating=2,
                            BookID=3
                        },
                        new Review()
                        {
                            BookReview="easy to read and enjoyable",
                            BookRating=4,
                            BookID=4
                        },
                        new Review()
                        {
                            BookReview="awesome book to read",
                            BookRating=5,
                            BookID=5
                        },
                    });
                    context.SaveChanges();
                }






            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@ebooks.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "admin");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@ebooks.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "user");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}
