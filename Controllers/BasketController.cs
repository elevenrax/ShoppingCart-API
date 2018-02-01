using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Responsible for managing a user's shopping basket of items.
    /// </summary>
    public class BasketController : ApiController
    {
        ProductDatabase products;
        CartDatabase shoppingCart;

        public BasketController()
        {
            products = new ProductDatabase();
            shoppingCart = CartDatabase.Instance;
        }

        // GET: api/Basket
        public IEnumerable<OrderItem> Get()
        {
            return 
        }

        // GET: api/Basket/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Basket
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Basket/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Basket/5
        public void Delete(int id)
        {
        }
    }
}
