using eBooks.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _context.Books
                .Include(x => x.Publication).Include(x => x.Category)
                .Include(x => x.Author_Books).ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookID == id);
            return View(bookDetails);
        }
    }

}
