using eBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eBooks.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;
        public BookController(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Books.Include(x => x.Publication).Include(x => x.Category).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _context.Books.Include(x => x.Publication).Include(x => x.Category).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = data.Where(n => n.BookName.Contains(searchString) || n.BookDescription.Contains(searchString)|| n.Category.CategoryName.Contains(searchString)) .ToList();

                return View("Index", filteredResultNew);
            }

                return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _context.Books
                .Include(x => x.Publication).Include(x => x.Category)
                .Include(x => x.Author_Books).ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookID == id);
            return View(bookDetails);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewBag.Publications = new SelectList(_context.Publications, "PublicationID", "PublicationName");
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBook data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "CategoryID", "CategoryName");
                ViewBag.Publications = new SelectList(_context.Publications, "PublicationID", "PublicationName");
                ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");

                return View(data);
            }

            var newbook = new Book()
            {
                BookName = data.BookName,
                BookDescription = data.BookDescription,
                BookPrice = data.BookPrice,
                BookImageURL = data.BookImageURL,

                BookPublicationDate = data.BookPublicationDate,

                CategoryID = data.CategoryID,
                PublicationID = data.PublicationID,
            };
            await _context.Books.AddAsync(newbook);
            await _context.SaveChangesAsync();

            //Add Authors
            foreach (var AuthorID in data.AuthorIDs)
            {
                var newAuthorBook = new Author_Book()
                {
                    BookID = newbook.BookID,
                    AuthorID = AuthorID
                };
                await _context.Author_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var a = await _context.Books.Include(x => x.Publication).Include(x => x.Category).Include(x => x.Author_Books).ThenInclude(x => x.Author).FirstOrDefaultAsync(x => x.BookID == id);
            if (a == null) return View("NotFound");

            var response = new NewBook()
            {
                BookID = a.BookID,
                BookName = a.BookName,
                BookDescription = a.BookDescription,
                BookPrice = a.BookPrice,
                BookImageURL = a.BookImageURL,
                BookPublicationDate = a.BookPublicationDate,
                CategoryID = a.CategoryID,
                PublicationID = a.PublicationID,
                AuthorIDs = a.Author_Books.Select(x => x.AuthorID).ToList(),
            };
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            ViewBag.Publications = new SelectList(_context.Publications, "PublicationID", "PublicationName");

            return View(response);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBook book)
        {
            if (id != book.BookID) return View("NotFound");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "CategoryID", "CategoryName");
                ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
                ViewBag.Publications = new SelectList(_context.Publications, "PublicationID", "PublicationName");

                return View(book);
            }

            var dbBook = await _context.Books.FirstOrDefaultAsync(x => x.BookID == book.BookID);

            if (dbBook != null)
            {
                dbBook.BookName = book.BookName;
                dbBook.BookDescription = book.BookDescription;
                dbBook.BookPrice = book.BookPrice;
                dbBook.BookImageURL = book.BookImageURL;
                dbBook.BookPublicationDate =book.BookPublicationDate;
                dbBook.CategoryID = book.CategoryID;
                dbBook.PublicationID = book.PublicationID;
                await _context.SaveChangesAsync();
            }

            //Remove existing authors
            var existingAuthorsDb = _context.Author_Books.Where(x => x.BookID == book.BookID).ToList();
            _context.Author_Books.RemoveRange(existingAuthorsDb);
            await _context.SaveChangesAsync();

            //Add Book Authors
            foreach (var authorId in book.AuthorIDs)
            {
                var newAuthorMovie = new Author_Book()
                {
                    BookID = book.BookID,
                    AuthorID = authorId
                };
                await _context.Author_Books.AddAsync(newAuthorMovie);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }



}
