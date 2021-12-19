using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DQuiz.MVC.Filters
{
    public class IndexFilter : ActionFilterAttribute, IActionFilter
    {
        private IWebHostEnvironment Environment;
        private string filePath = string.Empty;

        public IndexFilter(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            filePath = Path.Combine(this.Environment.WebRootPath, "files", "CurrentQuestion.txt"); // path doğru
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int currentQuestion = int.Parse(File.ReadAllText(filePath));
            if (currentQuestion > 0)
            {
                context.Result = new RedirectToActionResult("Contest", "Home", null);
            }

        }
    }
}
