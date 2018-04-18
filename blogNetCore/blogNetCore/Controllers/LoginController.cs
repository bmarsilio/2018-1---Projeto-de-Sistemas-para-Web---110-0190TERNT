using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;

namespace blogNetCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Login";
            
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string usuario, string senha)
        {
            return RedirectToAction("Index", "Post");
        }
        
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}