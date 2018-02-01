using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class OrderItem : Product
    {

        public OrderItem(Product prod, int qty) 
            : base(prod.Id, prod.ProductName, prod.ProductDescription, prod.UnitPrice)
        {
            this.qty = qty;
        }

        private int qty;
        public int OrderQty
        {
            get
            {
                return OrderQty;
            }
            set
            {
                qty = value;
            }
        }

    }
}