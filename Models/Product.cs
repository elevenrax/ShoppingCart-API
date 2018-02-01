using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCart.Models
{
    /// <summary>
    /// A product available for sale.
    /// </summary>
    [DataContract(Name = "Product")]
    public class Product
    {
        /// <summary>
        /// Unique product identifier.
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Name of the given product.
        /// </summary>
        [DataMember(Name = "ProductName")]
        public string ProductName { get; set; } = "";

        /// <summary>
        /// Description for the given product.
        /// </summary>
        [DataMember(Name = "ProductDescription")]
        public string ProductDescription { get; set; } = "";

        /// <summary>
        /// Price per unit of the given product.
        /// </summary>
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