using System;
namespace DQuiz.Data.App.Quiz
{
    public class ContestPostObject
    {
        public int QuestionMetricID { get; set; }

        public int QuestionID { get; set; }

        public int AnswerID { get; set; }

        public int Random1 { get; set; }

        public int Random2 { get; set; }

        public int SumCaptcha { get; set; }
    }
}
