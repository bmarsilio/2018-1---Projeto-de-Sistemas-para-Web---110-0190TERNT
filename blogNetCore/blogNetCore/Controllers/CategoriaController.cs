using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;

namespace blogNetCore.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Categorias";
            
            return View();
        }
        
        public IActionResult Create()
        {
            ViewData["title"] = "Nova Categoria";
            
            return View();
        }
        
        public IActionResult Edit()
        {
            ViewData["title"] = "Edição Categoria";
            
            return View();
        }
    }
}