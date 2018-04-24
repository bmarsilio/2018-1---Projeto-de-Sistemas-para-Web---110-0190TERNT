using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using blogNetCore.Filtro;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;

namespace blogNetCore.Controllers
{
    [FiltroAcesso]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Posts";
            
            return View();
        }
        
        public IActionResult Create()
        {
            ViewData["title"] = "Novo Post";
            
            return View();
        }
        
        public IActionResult Edit()
        {
            ViewData["title"] = "Edição Post";
            
            return View();
        }
    }
}