using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public interface IAdmin
    {
        Product AddStock(Product product);
        Product EditStock(Product product);

        bool DeleteStock(int productCode);
        List<Order> GetSales();

        Product GetProduct(int productCode);
    }
}
