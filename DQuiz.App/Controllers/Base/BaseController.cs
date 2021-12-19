using System;
using Microsoft.AspNetCore.Mvc;
using DQuiz.Business.UnitOfWorkFolder;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using DQuiz.MVC.Hubs;

namespace DQuiz.MVC.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _uow;
        private IWebHostEnvironment Environment;
        protected string currentQuestionFilePath = string.Empty;
        protected string counterDateFilePath = string.Empty;
        protected IHubContext<PoolHub> HubContext { get; set; }
        //private readonly IMapper _mapper;

        public BaseController(IUnitOfWork uow, IWebHostEnvironment environment, IHubContext<PoolHub> hubContext)
        {
            _uow = uow;
            Environment = environment;

            currentQuestionFilePath = Path.Combine(this.Environment.WebRootPath, "files", "CurrentQuestion.txt");
            counterDateFilePath = Path.Combine(this.Environment.WebRootPath, "files", "CounterDate.txt");
            HubContext = hubContext;
            //_mapper = mapper;
        }

        protected TService GetService<TService>() where TService : class
        {
            return (TService)Activator.CreateInstance(typeof(TService), new object[] { _uow, /*_mapper*/ });
        }

        protected void SaveDb()
        {
            _uow.Save();
        }
    }
}
