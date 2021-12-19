using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DQuiz.MVC.Filters;
using DQuiz.MVC.Hubs;
using Microsoft.AspNetCore.SignalR;
using DQuiz.MVC.Controllers.Base;
using DQuiz.Business.UnitOfWorkFolder;
using DQuiz.Business.App.QuizManagerFolder;
using DQuiz.Data.App.Quiz;
using System;

namespace DQuiz.MVC.Controllers
{
    public class HomeController : BaseController
    {
        IQuizManagementService _quizManagementService;

        public HomeController(IUnitOfWork uow, IWebHostEnvironment environment, IHubContext<PoolHub> hubContext) : base(uow, environment, hubContext)
        {
            _quizManagementService = base.GetService<QuizManagementService>();
        }

        [ServiceFilter(typeof(IndexFilter))]
        public IActionResult Index()
        {
            return View();
        }

        #region Contest

        [ServiceFilter(typeof(EndContestFilter)), ServiceFilter(typeof(QuestionPageFilter))]
        [Route("yarisma"), ActionName("Contest")]        
        public IActionResult Contest()
        {
            int currentQuestionOrder = int.Parse(System.IO.File.ReadAllText(currentQuestionFilePath));

            var question = _quizManagementService.GetQuestionObject(currentQuestionOrder);

            return View(question);
        }

        [ServiceFilter(typeof(QuestionPageFilter))]
        [HttpPost]
        public JsonResult Contest(ContestPostObject cpo)
        {
            if (cpo.Random1 + cpo.Random2 != cpo.SumCaptcha)
            {
                return Json(new { IsSuccess = "False" });
            }

            _quizManagementService.AnswerQuestion(new AnswerQuestionObject { ChosenAnswerId = cpo.AnswerID, QuestionId = cpo.QuestionID });

            base.SaveDb();

            this.HubContext.Clients.All.SendAsync("BroadcastByQuestion", new { info = GetChosenCounts() });
            this.HubContext.Clients.All.SendAsync("Broadcast", new { info = GetTotalSum() });
            return Json(new { IsSuccess = "True" });
        }

        private TrueFalseCount GetTotalSum()
        {
            return _quizManagementService.GetTotalSum();
        }

        public JsonResult GetTotalSumJson()
        {
           return Json(new { data = GetTotalSum() });
        }

        [ServiceFilter(typeof(EndContestFilter))]
        [Route("sonuclar")]
        public IActionResult SeeResults()
        {
            return View();
        }


        public JsonResult SeeResultsJson()
        {
            var chosenCounts = GetChosenCounts();

            return Json(new { data = chosenCounts });
        }

        private ChosenCountObject GetChosenCounts()
        {
            string currentQuestionOrder = System.IO.File.ReadAllText(currentQuestionFilePath);

            var chosenCounts = _quizManagementService.GetChosenCounts(int.Parse(currentQuestionOrder));

            return new ChosenCountObject() { ChosenCounts = chosenCounts, CurrentQuestion = currentQuestionOrder };
        }

        public JsonResult EndCountdown()
        {
            return Json(new { IsSuccess = "True" });
        }

        [HttpGet]
        public JsonResult GetTimeDifference()
        {
            var newDate = DateTime.ParseExact(System.IO.File.ReadAllText(counterDateFilePath), "MM.dd.yy HH:mm:ss", null);

            var now = DateTime.Now;
            var difference = (newDate - now).Seconds;

            this.HubContext.Clients.All.SendAsync("UpdateCounter", difference);

            if (difference <= 0)
            {
                this.HubContext.Clients.All.SendAsync("EndCountdown");
            }
            return Json(new { seconds = difference });
        }
        #endregion


        [Route("kapanis"), ActionName("EndContest")]
        public IActionResult EndContest()
        {
            return View();
        }
    }
}