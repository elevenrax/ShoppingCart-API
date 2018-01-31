using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{

    /**
     *   A singleton to represent the cart. 
     *   As per the specification, can be stored in memory. 
     *   No need for data persistence.   
     */
    public class CartDatabase
    {
        private static CartDatabase instance;

        private CartDatabase() { }

        public static CartDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDatabase();
                }
                return instance;
            }
        }


    }
}