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

        /// <summary>
        /// Obtain an instance of the CartDatabase singleton.
        /// </summary>
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

  
        /// <summary>
        /// Retreive all items in the current basket
        /// </summary>
        /// <returns>A List of all OrderItems in the current basket</returns>
        public List<OrderItem> GetAll()
        {
            return currentBasket;          
        }


        /// <summary>
        /// Retreive a specific item in the basket.
        /// </summary>
        /// <param name="id">The item id of the requested item</param>
        /// <returns>The order item with the corresponding Id</returns>
        public OrderItem Get(int id)
        {
            return currentBasket.Where(p => p.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Updates the quantity of an item in the cart.
        /// </summary>
        /// <param name="id">The id of the item to update.</param>
        /// <param name="qty">The new quantity.</param>
        /// <returns>True upon successfully updating a quantity.</returns>
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


        /// <summary>
        /// Adds an item to the basket.
        /// NB. If the product already exists, it updates the quantity to add the new qty (not replace).
        ///     This is because we expect that a user will add a product again from the browse area and
        ///         their desired behaviour is to include what they have already + the new order amount.
        /// </summary>
        /// <param name="id">The product id of the item to add.</param>
        /// <param name="qty">The quantity of the given product to add.</param>
        /// <returns>True if the product id exists and can added.</returns>
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


        /// <summary>
        /// Sums the total cost of items in the cart.
        /// </summary>
        /// <returns>The sum total cost.</returns>
        public double SumCart()
        {
            return currentBasket.Select(item => item.UnitPrice * item.OrderQty).Sum();
        }


        /// <summary>
        /// Removed an item from the cart.
        /// </summary>
        /// <param name="id">The id of the item you wish to remove.</param>
        /// <returns>True if the item has successfully been removed.</returns>
        public bool Remove(int id)
        {
            OrderItem itemToRemove = currentBasket.Find(p => p.Id == id);
            return currentBasket.Remove(itemToRemove);
        }


        /// <summary>
        /// Empties the shopping cart.
        /// </summary>
        /// <returns>True, if the cart has successfully been emptied.</returns>
        public bool EmptyCart()
        {
            currentBasket = new List<OrderItem>();
            return true;
        }

    }
}