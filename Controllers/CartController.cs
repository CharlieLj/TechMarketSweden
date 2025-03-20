using Microsoft.AspNetCore.Mvc;
using TechMarketSweden.Data;
using TechMarketSweden.Models;
using Microsoft.EntityFrameworkCore;

namespace TechMarketSweden.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<CartItem> Cart = new List<CartItem>();

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(Cart);

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var cartItem = Cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null)
                cartItem.Quantity++;
            else
                Cart.Add(new CartItem { ProductId = id, Product = product, Quantity = 1 });

            return RedirectToAction("Index");
        }

        public IActionResult Checkout() => View();

        [HttpPost]
        public IActionResult CompleteCheckout()
        {
            Cart.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
