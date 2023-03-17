using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Repository
{
    public class AdminBL : IAdmin
    {
        private readonly InventoryContext _context;

        public AdminBL(InventoryContext context)
        {
            _context = context;
        }

        public Product AddStock(Product product)
        {
            try
            {
                var prod = new Product()
                {
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    MinQuantity = product.MinQuantity,
                    Quantity = product.Quantity
                };

                Product IsExits = _context.Products.Where(p => p.ProductCode == prod.ProductCode).FirstOrDefault();

                if (IsExits != null)
                {
                    prod.IsSuccess = false;
                    return prod;
                }
                else
                {
                    _context.Products.Add(prod);
                    _context.SaveChanges();
                    prod = _context.Products.OrderByDescending(p => p.Id).FirstOrDefault();
                    prod.IsSuccess = true;
                    return prod;
                }
            }
            catch (Exception)
            {
                return new Product();
            }

        }
        public Product EditStock(Product product)
        {
            try
            {
                var prod = new Product()
                {
                    Id = product.Id,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    MinQuantity = product.MinQuantity,
                    Quantity = product.Quantity
                };

                Product IsExits = _context.Products.Where(p => p.ProductCode == prod.ProductCode).FirstOrDefault();

                if (IsExits == null)
                {
                    prod.IsSuccess = false;
                    return prod;
                }
                else
                {
                    Product prodDBEnitity = _context.Products.Where(p => p.ProductCode == product.ProductCode).FirstOrDefault();

                    prodDBEnitity.ProductName = product.ProductName;
                    prodDBEnitity.Price = product.Price;
                    prodDBEnitity.MinQuantity = product.MinQuantity;
                    prodDBEnitity.Quantity = product.Quantity;

                    _context.Products.Update(prodDBEnitity);
                    _context.SaveChanges();
                    prodDBEnitity.IsSuccess = true;
                    return prodDBEnitity;
                }
            }
            catch (Exception)
            {

                return null;
            }
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


        public bool DeleteStock(int productCode)
        {
            try
            {
                Product prodDBEnitity = _context.Products.Where(p => p.ProductCode == productCode).FirstOrDefault();
                if (prodDBEnitity != null)
                {
                    _context.Products.Remove(prodDBEnitity);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Order> GetSales()
        {
            var sales = _context.Orders.ToList();

            return sales;
        }
    }
}
