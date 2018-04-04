using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }

    }
}