using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogin _loginUser;
        public AccountController(ILogin loguser)
        {
            _loginUser = loguser;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (userName != null && password != null)
            {
                bool isSuccess = _loginUser.AuthenticateUser(userName, password);


                if (isSuccess)
                {
                    if (userName.ToLower() == "admin")
                    {
                        HttpContext.Session.SetString("userId", userName);
                        TempData["username"] = "Hi " + userName;
                        return RedirectToAction("AdminIndex", "Home");
                    }
                    else if (userName.ToLower() == "user")
                    {
                        HttpContext.Session.SetString("userId", userName);
                        TempData["username"] = "Hi " + userName;
                        return RedirectToAction("UserIndex", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("userId", userName);
                        TempData["username"] = "Hi " + userName;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.username = string.Format("Login Failed ", userName);
                    return View();
                }
            }
            else
            {
                if (userName == null)
                {
                    ModelState.AddModelError("UserName", "!Required field.");
                }
                if (password == null)
                {
                    ModelState.AddModelError("Password", "!Required field.");
                }
                return View();
            }
        }
    }
}
