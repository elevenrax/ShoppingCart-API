using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    /// <summary>
    /// An Order Item that extends from Product. 
    /// This model is added to the ShoppingCart and tracks the number of units to order for a given product.
    /// </summary>
    [DataContract(Name = "OrderItem")]
    public class OrderItem : Product
    {

        public OrderItem(Product prod, int qty) 
            : base(prod.Id, prod.ProductName, prod.ProductDescription, prod.UnitPrice)
        {
            this.OrderQty = qty;
        }


        private int qty;
        /// <summary>
        /// The Quantity of the given product to order.
        /// </summary>
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