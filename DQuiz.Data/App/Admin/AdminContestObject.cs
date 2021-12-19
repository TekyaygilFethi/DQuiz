using System;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.App.Admin
{
    public class AdminContestObject: AnswersEntity
    {
        public string Question { get; set; }
    }
}
