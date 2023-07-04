using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoHashingPassword.Services;
using DemoHashingPassword.Models;

namespace DemoHashingPassword.Controllers
{
    public class UserTableController : Controller
    {
        private readonly UserTableServices userTableServices;
        public UserTableController()
        {
            userTableServices = new UserTableServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        #region FOR REGISTRATION 
        //Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            userTableServices.RegisterUser(user);
            return RedirectToAction("Login");
        }
        #endregion

        #region FOR LOGIN 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (userTableServices.IsAuthenticatedUser(login))
                ViewBag.Message = "Password Matched";
            else
                ViewBag.Message = "password Mis Matched";
            return View();
        }
        #endregion

    }
}
