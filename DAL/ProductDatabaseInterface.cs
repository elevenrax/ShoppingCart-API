using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL
{
    /// <summary>
    /// The interface and constructor based DI allow us to switch out databases
    /// in our WebAPI Controller.
    /// </summary>
    interface ProductDatabaseInterface
    {
        /// <summary>
        /// Get a specific product from the database.
        /// </summary>
        /// <param name="id">The id of the product to return</param>
        /// <returns></returns>
        Product Get(int id);

        /// <summary>
        /// Get all products in the database.
        /// </summary>
        /// <returns>A List of all Products in the database.</returns>
        List<Product> Get();
    }
}
