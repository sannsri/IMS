using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        public IActionResult Billing()
        {
            return View();
        }
        public IActionResult SaveOrder(List<Product> products)
        {
            return View();
        }
        
        public IActionResult BillingProduct(int ProductCode)
        {
            if (ProductCode > 0)
            {
                Product prod = GetProduct(ProductCode);
                if (prod == null)
                {
                    ViewBag.Error = "ProductCode not in Stock.";
                    return View("Billing");

                }
                else
                {
                    return View("Billing", prod);
                }
            }
            else
            {
                return View("Billing");
            }
        }

        public IActionResult AddProductToGrid(Product Product, List<Product> ListProducts)
        {
            ListProducts.Add(Product);
            return PartialView("_BillingGrid", ListProducts);
        }

        public Product GetProduct(int ProductCode)
        {
            Product prod = _user.GetProduct(ProductCode);
            return prod;
        }

        [HttpPost]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
