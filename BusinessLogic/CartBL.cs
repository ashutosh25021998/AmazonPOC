using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using ProductRough.ContextFolder;
using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public interface ICartBL
    {
        bool AddCart(Cart cart);
    }
    public class CartBL: ICartBL
    {
        ProductContext obj = new ProductContext();

        Cart cartobj = new Cart();

        //ADD to cart Basic Operation
        public bool AddCart(Cart cartobj)
        {
            var inStock = obj.ProductItemes.Where(p => p.ProductItemId == cartobj.ProductItemId).FirstOrDefault();
            var quantity = inStock?.Quantity;

            if (quantity.HasValue && quantity > cartobj.Quantitycart)
            {
                var verify = obj.Carts.Where(p => p.ProductItemId == cartobj.ProductItemId && p.OperatorId == cartobj.OperatorId).FirstOrDefault();
                if (verify == null)
                {                    
                    obj.Carts.Add(cartobj);
                    var price = inStock.Price;                

                    cartobj.Totalprice = cartobj.Quantitycart * price;
                    obj.SaveChanges();
                    return true;
                }
                else
                {
                    verify.Quantitycart = verify.Quantitycart + cartobj.Quantitycart;
                    verify.Totalprice = verify.Totalprice + (verify.ProductItems.Price * cartobj.Quantitycart);
                    obj.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //Remove Cart
        public bool RemoveCart(Cart item)
        {
            var verify = obj.Carts.Where(p => p.ProductItemId == item.ProductItemId && p.OperatorId == item.OperatorId).FirstOrDefault();
            if (verify.Quantitycart == 1)
            {
                obj.Entry(verify).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                obj.SaveChanges();
                return true;

            }
            else if (verify.Quantitycart > 1)
            {
                verify.Quantitycart = verify.Quantitycart - item.Quantitycart;
                verify.Totalprice = verify.Totalprice - (item.ProductItems.Price * item.Quantitycart);
                obj.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //Clear the Cart
        public void ClearCart(Cart clear)
        {
            var carts = obj.Carts.Where(p => p.ProductItemId == clear.ProductItemId && p.OperatorId == clear.OperatorId);
            
            obj.Carts.RemoveRange(carts);
            obj.SaveChanges();
        }
       
        public List<Cart> GetCarts(int userId)
        {
            return obj.Carts.Include(p=>p.ProductItems).Where(c => c.OperatorId == userId).ToList();
        }
       

    }
}
