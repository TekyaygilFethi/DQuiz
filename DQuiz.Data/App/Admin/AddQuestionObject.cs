using System;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.App.Admin
{
    public class AddQuestionObject: AnswersEntity
    {
        public string Question { get; set; }
        public int TrueAnswer { get; set; }
    }
}
