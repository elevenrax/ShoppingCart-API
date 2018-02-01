using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    /// <summary>
    /// WebAPI Model that handles PUT and POST for Update and Create when adding a product to the CartDatabase.
    /// </summary>
    public class ClientOrderItem
    {

        public ClientOrderItem() { }

        /// <summary>
        /// The ID of a product available for sale.
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; set; } = 0;

        private int qty;

        /// <summary>
        /// The Quantity of the product to order.
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