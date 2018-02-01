using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{

    /**
     *   A singleton to represent the cart. 
     *   As per the specification, can be stored in memory. 
     *   No need for data persistence.   
     */
    public class CartDatabase
    {

        private ProductDatabase productDb;
        private List<OrderItem> currentBasket;

        public CartDatabase()
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

            currentBasket.Add(new OrderItem(prod, qty));
            return true;
        }

    }
}