using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;
using Microsoft.AspNetCore.Http;

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
            if (usuario == "admin" && senha == "admin")
            {
                HttpContext.Session.SetString("usuario", usuario);
                
                return RedirectToAction("Index", "Post");     
            }
         
            ViewData["error"] = "Usuário ou senha incorretos";
            
            return View("Index");
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index", "Home");
        }
    }
}