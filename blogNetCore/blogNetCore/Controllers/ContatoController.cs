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
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Contatos";
            
            return View();
        }
    }
}