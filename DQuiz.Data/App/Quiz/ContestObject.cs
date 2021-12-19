using System;
using System.Collections.Generic;

namespace DQuiz.Data.App.Quiz
{
    public class ContestObject
    {
        public int QuestionID { get; set; }

        public int QuestionOrder { get; set; }

        public string QuestionText { get; set; }

        public int QuestionMetricID { get; set; }

        public IEnumerable<ContestObjectAnswer> ShowcaseAnswers { get; set; }
    }
}