using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DQuiz.MVC.Filters
{
    public class AdminFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("User") == null)
            {
                context.Result = new RedirectToRouteResult(
    new RouteValueDictionary(new { controller = "Home", action = "Index" })
);
            }
        }
    }
}
