using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_commerceProj.Context;
using e_commerceProj.Models;

namespace e_commerceProj.Controllers
{
    // [Route("/Cart")]
    public class CartController : Controller
    {
        private readonly ProductContext _context;

        public CartController(ProductContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            return _context.Carts != null ?
                        View(await _context.Carts.Include(c => c.CartProducts).ThenInclude(cp => cp.Product).FirstOrDefaultAsync()) :
                        Problem("Entity set 'ProductContext.Carts'  is null.");
        }

        // GET: Cart
        [HttpGet("/Cart/Add/{Id}")]
        public async Task<ActionResult> Add(int Id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }

            // Add Cart
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product != null)
            {
                var cart = await _context.Carts.FirstOrDefaultAsync();
                if (cart is null)
                {
                    cart = new Cart();
                    cart.Total += product.Price;
                    _context.Carts.Add(cart);
                }
                else
                {
                    cart.Total += product.Price;
                    _context.Carts.Update(cart);
                }
                await _context.SaveChangesAsync();
                _context.CartProducts.Add(new CartProduct
                {
                    CartID = cart.Id,
                    ProductID = product.Id,
                    Quantity = 1
                });

                await _context.SaveChangesAsync();
            }

            return Redirect("/Cart");
        }

    }
}
