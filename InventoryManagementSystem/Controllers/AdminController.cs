using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;

        }
        public IActionResult AddStock(Product product)
        {
            if (product.ProductCode == 0)
            {
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (product.ProductCode > 0 && product.ProductName != null && product.Price > 0 && product.MinQuantity > 0 && product.Quantity > 0)
                    {
                        Product prod = _admin.AddStock(product);
                        if (prod.IsSuccess == true)
                        {
                            ViewBag.Success = "ProductCode " + prod.ProductCode + " Added Successfully";
                        }
                        else
                        {
                            ViewBag.Error = "ProductCode " + prod.ProductCode + " already exists.";
                        }
                        return View(prod);
                    }
                    else
                    {
                        if (product.ProductCode == 0)
                        {
                            ModelState.AddModelError("ProductCode", "!Required field.");
                        }
                        if (product.ProductName == null)
                        {
                            ModelState.AddModelError("ProductName", "!Required field.");
                        }
                        if (product.Price == 0)
                        {
                            ModelState.AddModelError("Price", "!Required field.");
                        }
                        if (product.MinQuantity == 0)
                        {
                            ModelState.AddModelError("ProductCode", "!Required field.");
                        }
                        if (product.Quantity == 0)
                        {
                            ModelState.AddModelError("ProductCode", "!Required field.");
                        }
                        return View();
                    }
                }
                else
                {
                    if (product.ProductCode == 0)
                    {
                        ModelState.AddModelError("ProductCode", "!Required field.");
                    }
                    if (product.ProductName == null)
                    {
                        ModelState.AddModelError("ProductName", "!Required field.");
                    }
                    if (product.Price == 0)
                    {
                        ModelState.AddModelError("Price", "!Required field.");
                    }
                    if (product.MinQuantity == 0)
                    {
                        ModelState.AddModelError("MinQuantity", "!Required field.");
                    }
                    if (product.Quantity == 0)
                    {
                        ModelState.AddModelError("Quantity", "!Required field.");
                    }
                    return View();
                }
            }
        }
        public IActionResult EditStock(Product product)
        {
            if (product.ProductCode == 0)
            {
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (product.ProductCode > 0 && product.ProductName != null && product.Price > 0 && product.MinQuantity > 0 && product.Quantity > 0)
                    {
                        Product prod = _admin.EditStock(product);
                        if (prod.IsSuccess == true)
                        {
                            ViewBag.Success = "ProductCode" + prod.ProductCode + "Edited Successfully";
                        }
                        else
                        {
                            ViewBag.Error = "Unable to Save the Data/Invalid Product code.";
                        }
                        return View(prod);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
        }
        public IActionResult DeleteStock(int productCode)
        {
            if (productCode == 0)
            {
                return View();
            }
            else
            {
                bool prod = _admin.DeleteStock(productCode);
                if (prod == true)
                {
                    ViewBag.Success = "ProductCode" + productCode + "Deleted Successfully";
                }
                else
                {
                    ViewBag.Error = "ProductCode" + productCode + "not exists.";
                }
                return View();
            }
        }
        public IActionResult ViewSales(int orderId)
        {
            return View();
        }
        public IActionResult GetSales()
        {
            _admin.GetSales();
            return View();
        }

        public IActionResult EditProduct(int ProductCode)
        {
            if (ProductCode > 0)
            {
                Product prod = GetProduct(ProductCode);
                if (prod == null)
                {
                    ViewBag.Error = "ProductCode not in Stock.";
                    return View("EditStock");
                }
                else
                {
                    return View("EditStock", prod);
                }
            }
            else
            {
                return View("EditStock");
            }

        }
        public IActionResult DeleteProduct(int ProductCode)
        {
            if (ProductCode > 0)
            {
                Product prod = GetProduct(ProductCode);
                if (prod == null)
                {
                    ViewBag.Error = "ProductCode not in Stock.";
                    return View("DeleteStock");
                }
                else
                {
                    return View("DeleteStock", prod);
                }
            }
            else
            {
                return View("DeleteStock");
            }
        }
        public Product GetProduct(int ProductCode)
        {
            Product prod = _admin.GetProduct(ProductCode);
            return prod;
        }

        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
