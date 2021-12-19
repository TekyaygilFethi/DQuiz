using System;
namespace DQuiz.Data.Base.Interfaces
{
    public interface IHasAnswers
    {
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
}
