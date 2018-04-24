using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace blogNetCore.Filtro
{
    public class FiltroAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("usuario");
            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { action = "Index", controller = "Login" }
                    )
                );
            }
        }
    }
}