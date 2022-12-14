using eBooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eBooks.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly BookDbContext _context;
        public static Review a;
        public ReviewController(BookDbContext context)
        {
            _context = context;
        }

        //displays the reviews based on id
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            var data = await _context.Reviews.Include(x=>x.Book).Where(x=>x.BookID==id).ToListAsync();
            return View(data);
        }
        //Gets all the reviews available
        public async Task<IActionResult> GetAllReviews()
        {
            var data = _context.Reviews.Include(x=>x.Book).ToList();
            return View(data);
        }
        //creates the review
        public IActionResult Create()
        {
            var result = _context.Books.ToList();
            ViewBag.BookID = new SelectList(result, "BookID", "BookName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review r)
        {
            if (!ModelState.IsValid)
            {
                return View(r);
            }
            await _context.Reviews.AddAsync(r);
            _context.SaveChanges();
            return RedirectToAction("GetAllReviews");
        }
        //Edit the review
        public async Task<IActionResult> Edit(int id)
        {
            a = _context.Reviews.Find(id);
            var result = _context.Books.ToList();
            ViewBag.BookID = new SelectList(result, "BookID", "BookName");
            if (a == null) return View("NotFound");
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Review a)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Update(a);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllReviews");

        }
        //delete the review
        public async Task<IActionResult> Delete(int id)
        {
            a = await _context.Reviews.Include(x => x.Book).Where(x => x.ReviewID == id).SingleAsync();
            if (a == null) return View("NotFound");
            return View(a);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteNewAsync(int id)
        {
            a = await _context.Reviews.FindAsync(id);
            if (a == null) return View("NotFound");
            _context.Reviews.Remove(a);
           await _context.SaveChangesAsync();
            return RedirectToAction("GetAllReviews");
        }
    }
}
