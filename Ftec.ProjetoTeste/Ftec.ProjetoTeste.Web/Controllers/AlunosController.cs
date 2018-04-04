using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class AlunosController : Controller
    {
        // GET
        public IActionResult Listar()
        {
            ViewData["Message"] = "Listar alunos.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Gravar()
        {
            ViewData["Message"] = "Gravar alunos.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Excluir()
        {
            ViewData["Message"] = "Excluir alunos.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Procurar()
        {
            ViewData["Message"] = "Procurar alunos.";
            
            return
            View();
        }
    }
}