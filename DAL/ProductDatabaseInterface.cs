using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL
{
    interface ProductDatabaseInterface
    {
        Product Get(int id);

        List<Product> Get();
    }
}
