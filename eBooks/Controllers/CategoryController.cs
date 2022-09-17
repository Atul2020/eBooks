using eBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookDbContext _context;
        public static Category a;
        public CategoryController(BookDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Categories.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            a = await _context.Categories.FindAsync(id);
            if (a == null) return View("NotFound");
            return View(a);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteNewAsync(int id)
        {
            a = await _context.Categories.FindAsync(id);
            if (a == null) return View("NotFound");
            _context.Categories.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
