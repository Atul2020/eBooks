using eBooks.Data.Static;
using eBooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AuthorController : Controller
    {
        private readonly BookDbContext _context;
        public static Author a;
        public AuthorController(BookDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = _context.Authors.ToList();
            return View(data);
        }
        //Creating an author
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            await _context.Authors.AddAsync(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Author Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            a = _context.Authors.Find(id);
            if (a == null) return View("NotFound");
            return View(a);

        }
        //Editing the author details
        public async Task<IActionResult> Edit(int id)
        {
            a = _context.Authors.Find(id);
            if (a == null) return View("NotFound");
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( Author a)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(a);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
           a =await _context.Authors.FindAsync(id);
            if (a == null) return View("NotFound");
            return View(a);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteNewAsync(int id)
        {
            a =await _context.Authors.FindAsync(id);
            if (a == null) return View("NotFound");
            _context.Authors.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
