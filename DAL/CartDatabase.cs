using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    /// <summary>
    /// Class used to maintain the user's purchases. 
    /// Assumption: The specification does not require (1) user accounts and (2) a method to manage multiple carts.
    /// Could have used Sessions object to persist a given users cart as follows:
    /// public static CartDatabase Instance
    /// {
    ///     get
    ///     {
    ///         var cart = HttpContext.Current.Session["Cart"] as CartDatabase;
    ///         if (null == cart)
    ///         {
    ///             cart = new CartDatabase();
    ///             HttpContext.Current.Session["Cart"] = cart;
    ///         }
    ///         return cart;
    ///     }
    /// }
    ///
    /// However by the server preserving sessions, this would no longer be RESTful as it violates the `Stateless` constraint.
    /// </summary>
    public class CartDatabase
    {
        private ProductDatabase productDb;
        private List<OrderItem> currentBasket;


        private static CartDatabase instance;
        public static CartDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDatabase();
                }
                return instance;
            }
        }


        private CartDatabase()
        {
            productDb = new ProductDatabase();
            currentBasket = new List<OrderItem>();
        }

  
        public List<OrderItem> GetAll()
        {
            return currentBasket;          
        }


        public OrderItem Get(int id)
        {
            return currentBasket.Where(p => p.Id == id).FirstOrDefault();
        }


        public bool UpdateQuantity(int id, int qty)
        {
            OrderItem item = currentBasket.Find(p => p.Id == id);

            if (item != null)
            {
                item.OrderQty = qty;
                return true;
            }

            return false;
        }


        public bool Add(int id, int qty)
        {
            Product prod = productDb.Get(id);
            if (prod == null) return false;

            OrderItem item = currentBasket.Find(p => p.Id == id);
            if (item != null)
            {
                item.OrderQty = item.OrderQty += qty;
            }
            else
            {
                currentBasket.Add(new OrderItem(prod, qty));
            }
            return true;
        }


        public bool Remove(int id)
        {
            OrderItem itemToRemove = currentBasket.Find(p => p.Id == id);
            return currentBasket.Remove(itemToRemove);
        }

        public bool EmptyCart()
        {
            currentBasket = new List<OrderItem>();
            return true;
        }

    }
}