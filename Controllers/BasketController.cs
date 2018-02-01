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


        [Route("api/Basket")]
        [HttpGet]
        // GET: api/Basket
        public List<OrderItem> Get()
        {
            return shoppingCart.GetAll();
        }


        [Route("api/Basket/{id}")]
        [HttpGet]
        // GET: api/Basket/{id}
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            return Ok(shoppingCart.Get(id));
        }


        [Route("api/Basket/total")]
        [HttpGet]
        // GET: api/Basket
        public double GetTotal()
        {
            return shoppingCart.SumCart();
        }


        [Route("api/Basket")]
        [HttpPost]
        // POST: api/Basket
        public void Post([FromBody] ClientOrderItem order)
        {
            shoppingCart.Add(order.Id, order.OrderQty);
        }


        [Route("api/Basket")]
        [HttpPut]
        // PUT: api/Basket
        public void Put([FromBody]ClientOrderItem order)
        {
            OrderItem orderItem = shoppingCart.Get(order.Id);
            if (orderItem != null && order.OrderQty > 0)
            {
                orderItem.OrderQty = order.OrderQty;
            }
        }


        [Route("api/Basket")]
        [HttpDelete]
        // DELETE: api/Basket/5
        public void Delete(int id)
        {
            shoppingCart.Remove(id);
        }

    
        [Route("api/Basket")]
        [HttpDelete]
        // DELETE: api/Basket
        public void Delete()
        {
            shoppingCart.EmptyCart();
        }
    }
}
