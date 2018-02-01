using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
    
        public string ProductDescription { get; set; }

        public double UnitPrice { get; set; }

        public Product(int id, string productName, string productDescription, double unitPrice)
        {
            this.Id = id;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.UnitPrice = unitPrice;
        }
    }
}