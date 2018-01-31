using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class OrderItem : Product
    {

        public OrderItem()
        {
            this.qty = 0;
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