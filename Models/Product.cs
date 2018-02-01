using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    [DataContract(Name = "Product")]
    public class Product
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; } = 0;

        [DataMember(Name = "ProductName")]
        public string ProductName { get; set; } = "";

        [DataMember(Name = "ProductDescription")]
        public string ProductDescription { get; set; } = "";

        [DataMember(Name = "UnitPrice")]
        public double UnitPrice { get; set; } = 0;

        public Product(int id, string productName, string productDescription, double unitPrice)
        {
            this.Id = id;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.UnitPrice = unitPrice;
        }
    }
}