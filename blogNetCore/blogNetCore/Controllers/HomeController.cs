using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;

namespace blogNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            ViewBag.subtitulo = "Home";
            ViewBag.imagemFundo = "home-bg.jpg";
            
            return View();
        }
        
        public IActionResult Sobre()
        {
            ViewData["title"] = "Sobre";
            ViewBag.subtitulo = "Sobre";
            ViewBag.imagemFundo = "about-bg.jpg";
            
            return View();
        }
        
        public IActionResult Contato()
        {
            ViewData["title"] = "Contato";
            ViewBag.subtitulo = "Contato";
            ViewBag.imagemFundo = "contact-bg.jpg";
            
            return View();
        }
        
        public IActionResult Post()
        {
            ViewData["title"] = "Post";
            ViewBag.subtitulo = "Post 123";
            ViewBag.imagemFundo = "post-bg.jpg";
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}