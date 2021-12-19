using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DQuiz.MVC.Filters
{
    public class EndContestFilter : ActionFilterAttribute, IActionFilter
    {
        private IWebHostEnvironment Environment;
        private string filePath = string.Empty;

        public EndContestFilter(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            filePath = Path.Combine(this.Environment.WebRootPath, "files", "CurrentQuestion.txt"); // path doğru
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            int currentQuestion = int.Parse(File.ReadAllText(filePath));
            if (currentQuestion > 25)
            {
                context.Result = new RedirectToActionResult("EndContest","Home",null);
            }


        }
    }
}
