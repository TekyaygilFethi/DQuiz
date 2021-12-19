using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace DQuiz.MVC.Filters
{
    public class QuestionPageFilter : ActionFilterAttribute, IActionFilter
    {
        private IWebHostEnvironment Environment;
        private string filePath = string.Empty;
        public QuestionPageFilter(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            filePath = Path.Combine(this.Environment.WebRootPath, "files", "CurrentQuestion.txt"); // path doğru
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string currentQuestion = File.ReadAllText(filePath);
            if (currentQuestion == "0")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}