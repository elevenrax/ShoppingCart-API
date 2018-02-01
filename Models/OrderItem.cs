using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    [DataContract(Name = "OrderItem")]
    public class OrderItem : Product
    {

        public OrderItem(Product prod, int qty) 
            : base(prod.Id, prod.ProductName, prod.ProductDescription, prod.UnitPrice)
        {
            this.OrderQty = qty;
        }

        private int qty;
        [DataMember(Name = "OrderQty")]
        public int OrderQty
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
            }
        }

    }
}