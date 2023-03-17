using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public class UserBL : IUser
    {
        private readonly InventoryContext _context;
        public UserBL(InventoryContext context)
        {
            _context = context;
        }

        public Order SaveOrder(List<Product> productList)
        {
            throw new NotImplementedException();
        }
        public Product GetProduct(int productCode)
        {
            try
            {
                var prod = _context.Products.Where(p => p.ProductCode == productCode).FirstOrDefault();

                if (prod != null)
                {
                    prod.IsSuccess = true;
                    return prod;
                }
                else
                {

                    return prod;
                }


            }
            catch (Exception)
            {

                return new Product();
            }
        }
    }
}
