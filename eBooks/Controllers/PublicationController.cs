using eBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBooks.Controllers
{
    public class PublicationController : Controller
    {
        private readonly BookDbContext _context;
        public static Publication a;
        public PublicationController(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data= await _context.Publications.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publication p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            await _context.Publications.AddAsync(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Author Details
        public async Task<IActionResult> Details(int id)
        {
            a = _context.Publications.Find(id);
            if (a == null) return View("NotFound");
            return View(a);

        }

        public async Task<IActionResult> Edit(int id)
        {
            a = _context.Publications.Find(id);
            if (a == null) return View("NotFound");
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Publication p)
        {
            if (ModelState.IsValid)
            {
                _context.Publications.Update(p);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            a = await _context.Publications.FindAsync(id);
            if (a == null) return View("NotFound");
            return View(a);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteNewAsync(int id)
        {
            a = await _context.Publications.FindAsync(id);
            if (a == null) return View("NotFound");
            _context.Publications.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
