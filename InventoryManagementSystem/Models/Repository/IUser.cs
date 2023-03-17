using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public interface IUser
    {
        Order SaveOrder(List<Product> productList);
        Product GetProduct(int productCode);
    }
}
