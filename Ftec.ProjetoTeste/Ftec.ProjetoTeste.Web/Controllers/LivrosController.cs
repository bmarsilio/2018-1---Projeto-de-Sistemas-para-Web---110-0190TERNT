using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class LivrosController : Controller
    {
        // GET
        public IActionResult Listar()
        {
            ViewData["Message"] = "Listar livros.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Gravar()
        {
            ViewData["Message"] = "Gravar livros.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Excluir()
        {
            ViewData["Message"] = "Excluir livros.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Procurar()
        {
            ViewData["Message"] = "Procurar livros.";
            
            return
            View();
        }
    }
}