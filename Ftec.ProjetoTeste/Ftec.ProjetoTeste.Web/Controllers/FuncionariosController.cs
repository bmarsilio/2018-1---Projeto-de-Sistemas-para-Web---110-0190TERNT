using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET
        public IActionResult Listar()
        {
            ViewData["Message"] = "Listar funcionarios.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Gravar()
        {
            ViewData["Message"] = "Gravar funcionarios.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Excluir()
        {
            ViewData["Message"] = "Excluir funcionarios.";
            
            return
            View();
        }
        
        // GET
        public IActionResult Procurar()
        {
            ViewData["Message"] = "Procurar funcionarios.";
            
            return
            View();
        }
    }
}