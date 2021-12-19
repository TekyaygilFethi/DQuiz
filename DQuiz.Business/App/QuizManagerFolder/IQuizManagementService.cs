using System;
using System.Collections.Generic;
using DQuiz.Data.App.Quiz;

namespace DQuiz.Business.App.QuizManagerFolder
{
    public interface IQuizManagementService
    {
        public ContestObject GetQuestionObject(int currentQuestionOrder);
        public void AnswerQuestion(AnswerQuestionObject aqo);
        public TrueFalseCount GetTotalSum();
        public List<int> GetChosenCounts(int currentQuestionOrder);
    }
}
