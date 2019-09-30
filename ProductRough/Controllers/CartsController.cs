using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using ProductRough.ContextFolder;
using BusinessLogic;

namespace ProductRough.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ProductContext _context;

        private CartBL _cartobj = new CartBL();


        public CartsController(ProductContext context)
        {
            _context = context;
        }



        //// GET: api/Carts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        //{
        //    return await _context.Carts.ToListAsync();
        //}

        //// GET: api/Carts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Cart>> GetCart(int id)
        //{
        //    var cart = await _context.Carts.FindAsync(id);

        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return cart;
        //}

        //// PUT: api/Carts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCart(int id, Cart cart)
        //{
        //    if (id != cart.CartId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cart).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CartExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Carts
        //[HttpPost]
        //public async Task<ActionResult<Cart>> PostCart(Cart cart)
        //{
        //    _context.Carts.Add(cart);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        //}

        //// DELETE: api/Carts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Cart>> DeleteCart(int id)
        //{
        //    var cart = await _context.Carts.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Carts.Remove(cart);
        //    await _context.SaveChangesAsync();

        //    return cart;
        //}

        //private bool CartExists(int id)
        //{
        //    return _context.Carts.Any(e => e.CartId == id);
        //}



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //post by get


        [HttpGet("getCart/{id}")]
        public IActionResult Getcartdetails(int id)
        {
            var result = _cartobj.GetCarts(id);
            return Ok(result);
        }


        //get by id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart()
        [HttpPost("addToCart")]
        public IActionResult Post([FromBody] Cart model)
        {
            var res = _cartobj.AddCart(model);



            return Ok(new { res });

        }

        //Remove From Cart
        [HttpPost("removeFromCart")]
        public IActionResult PostC([FromBody] Cart model)
        {
            var res = _cartobj.RemoveCart(model);
            return Ok(res);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("clearCart")]
        public void clear([FromBody] Cart model)
        {
            _cartobj.ClearCart(model);
        }
       


    }
}
