using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    public class ProductDatabase : ProductDatabaseInterface
    {

        ProductDatabase products;
        CartDatabase cart;

        public ProductDatabase()
        {
            products = new ProductDatabase();
            cart = CartDatabase.Instance;
        }


        public Product Get(int id)
        {
            return new Product(); // TODO - implement
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }
    }
}