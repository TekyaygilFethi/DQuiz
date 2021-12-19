using System;
namespace DQuiz.Data.App.Quiz
{
    public class QuestionBasedTrueFalseObject : TrueFalseCount
    {
        public int Answer1ChosenCount { get; set; }
        public int Answer2ChosenCount { get; set; }
        public int Answer3ChosenCount { get; set; }
        public int Answer4ChosenCount { get; set; }
    }
}
