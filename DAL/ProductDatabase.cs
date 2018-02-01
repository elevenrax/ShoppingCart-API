using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    /// <summary>
    /// A mock database context storing products for sale via this fictitious online storefront. 
    /// </summary>
    public class ProductDatabase : ProductDatabaseInterface
    {

        List<Product> productList;

        public ProductDatabase()
        {
            productList = new List<Product>();
            productList.Add(new Product(1, "Asiago", "1kg. A mild cheese", 45.50));
            productList.Add(new Product(2, "Brie", "300g. A delicious cheese", 22.15));
            productList.Add(new Product(3, "Corija", "5kg. Made from unpasturized cow's milk", 292.00));
            productList.Add(new Product(4, "Feta", "2kg. Salty and Crumbly", 45.50));
            productList.Add(new Product(5, "Gorgonzola", "500g. A product of Italy", 19.00));
            productList.Add(new Product(6, "Jarlsberg", "200g. Made in Norway, great aroma", 12.85));
            productList.Add(new Product(7, "Mozzarella", "1kg. From South Italy", 33.33));
            productList.Add(new Product(8, "Pepper Jack", "800g. Strong and peppery, brave customers only", 66.20));
        }

        public Product Get(int id)
        {
            return productList.Find(p => p.Id == id);
        }

        public List<Product> Get()
        {
            return productList;
        }
    }
}