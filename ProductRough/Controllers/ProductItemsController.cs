using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductRough.ContextFolder;
using ProductRough.Models;

namespace ProductRough.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductItemsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/ProductItems/id(Details of ProductItems)
        [HttpGet("getbyid/{id}")]
        public IActionResult TakeProductItems(int id)
        {
            var productitems = (from pro in _context.ProductItemes
                                join supplier in _context.Suppliers on pro.SupplierId equals supplier.SupplierId
                                select new Supplierdetails
                                {
                                    SupplierName = supplier.SupplierName,
                                    ProductItemName = pro.ProductItemName,
                                    Quantity = pro.Quantity,
                                    Price = pro.Price,
                                    image = pro.image,
                                    Description = pro.Description
                                }).FirstOrDefault();


            if (productitems == null)
            {
                return NotFound();
            }

            return Ok(productitems);
        }


        // GET: api/ProductItems/id(Updation of ProductItems)
        [HttpGet("getvaluebyid/{id}")]
        public IActionResult CarryProductItems(int id)
        {
            var productitems = (from pro in _context.ProductItemes
                                where pro.ProductItemId == id
                                select pro).FirstOrDefault();
           


            if (productitems == null)
            {
                return NotFound();
            }

            return Ok( productitems);
        }






        // GET: api/ProductItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItems>>> GetProductItemes()
        {
            return await _context.ProductItemes.ToListAsync();
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public IActionResult GetProductItems(int id)
        {
            var productItems = (from pro in _context.ProductItemes
                                where pro.ProductId == id
                                select pro).ToArray();


            if (productItems == null)
            {
                return NotFound();
            }

            return Ok(productItems);
        }



        // PUT: api/ProductItems/5
        [HttpPut]
        public async Task<IActionResult> PutProductItems([FromBody] ProductItems productItems)
        {

            _context.Entry(productItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }



        // POST: api/ProductItems
        [HttpPost]
        public async Task<ActionResult<ProductItems>> PostProductItems(ProductItems productItems)
        {
            _context.ProductItemes.Add(productItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductItems", new { id = productItems.ProductItemId }, productItems);
        }



        // DELETE: api/ProductItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductItems>> DeleteProductItems(int id)
        {
            var productItems = await _context.ProductItemes.FindAsync(id);
            if (productItems == null)
            {
                return NotFound();
            }

            _context.ProductItemes.Remove(productItems);
            await _context.SaveChangesAsync();

            return productItems;
        }

        private bool ProductItemsExists(int id)
        {
            return _context.ProductItemes.Any(e => e.ProductItemId == id);
        }
    }
}
