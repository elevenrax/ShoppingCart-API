using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    public class ProductDatabase
    {

        List<Product> products = new List<Product>();
        

        public ProductDatabase()
        {
            

        }


        public Product Get(int id)
        {
            return new Product(); // TODO - implement
        }
        
    }
}