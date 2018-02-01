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
        Product Get(int id);

        List<Product> Get();
    }
}
