using System;
using System.Collections.Generic;
using System.Linq;
using DQuiz.Business.RepositoryFolder;
using DQuiz.Business.UnitOfWorkFolder;
using DQuiz.Data.App.Quiz;
using DQuiz.Data.POCO;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Business.App.QuizManagerFolder
{
    public class QuizManagementService: IQuizManagementService
    {
        IRepository<Question> _questionRepository;
        IRepository<Metric> _metricRepository;
        IRepository<Answer> _answerRepository;

        public QuizManagementService(IUnitOfWork uow)
        {
            _questionRepository = uow.GetRepository<Question>();
            _metricRepository = uow.GetRepository<Metric>();
            _answerRepository = uow.GetRepository<Answer>();
        }

        public ContestObject GetQuestionObject(int currentQuestionOrder)
        {
            return _questionRepository.GetBy(b => b.Order == currentQuestionOrder)
                .Include(i => i.Answers)
                .ToList()
                .Select(s => new ContestObject
                {
                    QuestionID = s.Id,
                    QuestionMetricID = s.Id,
                    QuestionOrder = s.Order,
                    QuestionText = s.Text,
                    ShowcaseAnswers = s.Answers.Select(a => new ContestObjectAnswer { AnswerID = a.Id, AnswerText = a.Text })
                }).SingleOrDefault();
        }

        public void AnswerQuestion(AnswerQuestionObject aqo)
        {
            var questionObject = _questionRepository.GetBy(b => b.Id == aqo.QuestionId)
                .Include(i => i.Answers)
                .Include(i => i.Metric)
                .ToList()
                .FirstOrDefault();

            _questionRepository.Attach(questionObject);

            var chosenAnswer = questionObject.Answers.FirstOrDefault(f => f.Id == aqo.ChosenAnswerId);
            chosenAnswer.ChosenCount += 1;

            if (chosenAnswer.IsTrue)
                questionObject.Metric.TrueCount += 1;
            else
                questionObject.Metric.FalseCount += 1;
        }


        public TrueFalseCount GetTotalSum()
        {
            int totalTrue = 0;
            int totalFalse = 0;

            _metricRepository.GetAllQueryable()
                .Select(s => new { s.TrueCount, s.FalseCount })
                .ToList().ForEach(each => TotalSumFunction(ref totalTrue, ref totalFalse, each));


            return new TrueFalseCount
            {
                TotalTrue = totalTrue,
                TotalFalse = totalFalse
            };
            
        }

        private void TotalSumFunction(ref int totalTrue, ref int totalFalse, dynamic metric)
        {
            totalTrue += metric.TrueCount;
            totalFalse += metric.FalseCount;
        }

        public List<int> GetChosenCounts(int currentQuestionOrder)
        {
            return _answerRepository.GetBy(b => b.QuestionId == currentQuestionOrder)
                .OrderBy(o => o.Id)
                .Select(s => s.ChosenCount)
                .ToList();
        }
    }
}
