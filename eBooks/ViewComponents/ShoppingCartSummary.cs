using eBooks.Cart;
using Microsoft.AspNetCore.Mvc;
//view component file for a particular part of a view
namespace eBooks.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
               _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items=_shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
        
    }
}
