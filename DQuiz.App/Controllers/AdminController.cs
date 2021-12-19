using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DQuiz.Business.App.AdminManagerFolder;
using DQuiz.Business.UnitOfWorkFolder;
using DQuiz.Data.App.Admin;
using DQuiz.MVC.Controllers.Base;
using DQuiz.MVC.Filters;
using DQuiz.MVC.Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;

namespace GAIHPool.MVC.Controllers
{
    public class AdminController : BaseController
    {
        IAdminManagementService _adminManagementService;

        public AdminController(IUnitOfWork uow, IWebHostEnvironment environment, IHubContext<PoolHub> hubContext) :base(uow, environment, hubContext)
        {
            _adminManagementService = base.GetService<AdminManagementService>();
        }

        #region Admin

        #region Login
        public IActionResult Start()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Start(UserDTO user)
        {
            if(_adminManagementService.CheckUser(new UserDTO { Username = user.Username, Password = user.Password}))
            {
                HttpContext.Session.SetString("User", "GAIH");
                return RedirectToAction("StartContest", "Admin");
            }
            TempData["ErrorMessage"] = "Kullanıcı adı veya şifre yanlış!";
            return View();
        }
        #endregion

        #region Contest
        [ServiceFilter(typeof(AdminFilter))]
        public IActionResult StartContest()
        {
            return View();
        }

        [ServiceFilter(typeof(AdminFilter)), HttpPost]
        public IActionResult StartContestPost()
        {
            System.IO.File.WriteAllText(counterDateFilePath, DateTime.Now.AddSeconds(32).ToString("MM.dd.yy HH:mm:ss"));

            int currentQuestion = int.Parse(System.IO.File.ReadAllText(currentQuestionFilePath));

            if (currentQuestion == 0)
            {
                System.IO.File.WriteAllText(currentQuestionFilePath, "1");
            }

            this.HubContext.Clients.All.SendAsync("startcontest");
            return RedirectToAction("AdminContest");
        }
        

        [ServiceFilter(typeof(AdminFilter))]
        [ServiceFilter(typeof(EndContestFilter))]
        public IActionResult AdminContest()
        {
            int currentQuestionOrder = int.Parse(System.IO.File.ReadAllText(currentQuestionFilePath));

            var aco = _adminManagementService.GetCurrentQuestion(currentQuestionOrder);

            return View(aco);
        }

        [ServiceFilter(typeof(AdminFilter))]
        public JsonResult ChangeQuestion([FromQuery] string IsIncrement = "true")
        {
            int currentQuestionOrder = int.Parse(System.IO.File.ReadAllText(currentQuestionFilePath));


            if (IsIncrement == "true")
            {
                currentQuestionOrder += 1;
            }

            System.IO.File.WriteAllText(currentQuestionFilePath, currentQuestionOrder.ToString());

            if (currentQuestionOrder > 5)
            {
                return Json(new { Success = "Success", data = "redirect" });
            }

            this.HubContext.Clients.All.SendAsync("resetsinglebarchart");
            this.HubContext.Clients.All.SendAsync("changequestion");

            var aco = _adminManagementService.GetCurrentQuestion(currentQuestionOrder);

            System.IO.File.WriteAllText(counterDateFilePath, DateTime.Now.AddSeconds(32).ToString("MM.dd.yy HH:mm:ss"));
            return Json(new { Success = "Success", data = aco });
        }
        #endregion

        #endregion
        [ServiceFilter(typeof(AdminFilter))]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [ServiceFilter(typeof(AdminFilter))]
        [HttpPost]
        public JsonResult AddQuestion(AddQuestionObject aqo)
        {
            try
            {
                _adminManagementService.AddQuestion(aqo);
                base.SaveDb();

                return Json(new { Success = "Success" });
            }
            catch (Exception) {
                return Json(new { Success = "False" });
            }
            
        }
    }
}
