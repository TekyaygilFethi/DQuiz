using System;
using DQuiz.Data.Base.Interfaces;

namespace DQuiz.Data.Base.Classes
{
    public class AnswersEntity: IHasAnswers
    {
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
}
