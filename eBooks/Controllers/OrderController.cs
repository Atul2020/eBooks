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
       
        public async Task<IActionResult> Index()
        {

           string userId = "";
           var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Book).Where(n => n.UserId == userId).ToListAsync();
           return View(orders);

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
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BookID = item.Book.BookID,
                    OrderId = order.OrderId,
                    Price = item.Book.BookPrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();

            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }

    



    }
}
