using eBooks.Cart;
using eBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBooks.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly BookDbContext _context;
        public OrderController(ShoppingCart shoppingCart, BookDbContext context)
        {
            _shoppingCart = shoppingCart;
            _context = context;
        }
        public async Task<IActionResult> ShoppingCart()
        {
           var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _context.Books
                .Include(x => x.Publication).Include(x => x.Category)
                .Include(x => x.Author_Books).ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookID == id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> DeleteItemFromShoppingCart(int id)
        {
            var item = await _context.Books
                .Include(x => x.Publication).Include(x => x.Category)
                .Include(x => x.Author_Books).ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookID == id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

    }
}
