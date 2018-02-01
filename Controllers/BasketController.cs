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


        /// <summary>
        /// Get a list of all items in the shopping cart.
        /// </summary>
        /// <returns>A list of items in the shopping cart.</returns>
        [Route("api/Basket")]
        [HttpGet]
        public List<OrderItem> Get()
        {
            return shoppingCart.GetAll();
        }


        /// <summary>
        /// Get a specific item, by id, from the shopping cart.
        /// </summary>
        /// <param name="id">The ID for a specific item in the cart that you want to get.</param>
        /// <returns></returns>
        [Route("api/Basket/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var item = shoppingCart.Get(id);
            if (item == null)
            {
                return BadRequest("No product in catague with id=" + id);
            }
            return Ok(shoppingCart.Get(id));
        }


        /// <summary>
        /// Get the sum total of all items in the shopping cart.
        /// </summary>
        /// <returns>The total value of the goods in the shopping cart.</returns>
        [Route("api/Basket/total")]
        [HttpGet]
        public double GetTotal()
        {
            return shoppingCart.SumCart();
        }


        /// <summary>
        /// Add a product to the shopping cart. 
        /// </summary>
        /// <param name="Id">The product ID to add to cart.</param>
        /// <param name="OrderQuantity">The quantity of the given product to add to the cart.</param>
        /// <returns>HttpStatus: {201=Created}. {400=Bad Request: If Id of product does not exist in Product Database.}</returns>
        [Route("api/Basket")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ClientOrderItem order)
        {
            if ( shoppingCart.Add(order.Id, order.OrderQty) )
            {
                return Request.CreateResponse(HttpStatusCode.Created, order.Id);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No product in catalogue with id=" + order.Id);
        }


        /// <summary>
        /// Change the quantity of product already in the shopping cart.
        /// </summary>
        /// <param name="Id">The product ID of the product whose quantity you want to change.</param>
        /// <param name="OrderQuantity">The new quantity to order for the given product.</param>
        /// <returns>HttpStatus: {200=Ok}. {400=Bad Request: If Id of product does not exist in current Shopping Cart.}</returns>
        [Route("api/Basket")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]ClientOrderItem order)
        {
            OrderItem orderItem = shoppingCart.Get(order.Id);
            if (orderItem != null && order.OrderQty > 0)
            {
                orderItem.OrderQty = order.OrderQty;
                return Request.CreateResponse(HttpStatusCode.OK, order.Id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Cannot update product with id=" + order.Id + ". Item not in basket");
        }


        /// <summary>
        /// Deletes a product (with a given ID) from the shopping cart.
        /// </summary>
        /// <param name="id">The id of the product to remove from the Shopping Cart.</param>
        /// <returns>HttpStatus: {200=Ok}. {404=Not Found: If Id of product does not exist in current Shopping Cart.}</returns>
        [Route("api/Basket/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (shoppingCart.Remove(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Cannot delete product with id=" + id + ". Item not in basket");
        }

    
        /// <summary>
        /// Empties the entire shopping cart.
        /// </summary>
        [Route("api/Basket")]
        [HttpDelete]
        // DELETE: api/Basket
        public void Delete()
        {
            shoppingCart.EmptyCart();
        }
    }
}
