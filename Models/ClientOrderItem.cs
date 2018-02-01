﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    /// <summary>
    /// WebAPI Model to handle Post of order items.
    /// </summary>
    public class ClientOrderItem
    {

        public ClientOrderItem() { }

        [DataMember(Name = "Id")]
        public int Id { get; set; } = 0;

        [DataMember(Name = "qty")]
        private int qty;
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