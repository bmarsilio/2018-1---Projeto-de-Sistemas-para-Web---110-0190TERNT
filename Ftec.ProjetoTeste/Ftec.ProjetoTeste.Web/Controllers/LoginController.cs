using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
                View();
        }

        [HttpPost]
        public IActionResult Autenticar(string usuario, string senha)
        {
            if (usuario == "bruno" && senha == "123")
            {
                HttpContext.Session.SetString("usuario", usuario);
                
                return RedirectToAction("Index", "Categoria");       
            }

            return View("Index");
        }

    }
}