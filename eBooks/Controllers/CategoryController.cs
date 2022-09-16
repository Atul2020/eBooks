using eBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookDbContext _context;
        public CategoryController(BookDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Categories.ToList();
            return View(data);
        }
    }
}
