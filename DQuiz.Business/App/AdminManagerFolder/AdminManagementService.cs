using System;
using System.Collections.Generic;
using System.Linq;
using DQuiz.Business.RepositoryFolder;
using DQuiz.Business.UnitOfWorkFolder;
using DQuiz.Data.App.Admin;
using DQuiz.Data.POCO;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Business.App.AdminManagerFolder
{
    public class AdminManagementService: IAdminManagementService
    {
        IRepository<User> _userRepository;
        IRepository<Metric> _metricRepository;
        IRepository<Question> _questionRepository;
        IRepository<Answer> _answerRepository;

        public AdminManagementService(IUnitOfWork uow)
        {
            _userRepository = uow.GetRepository<User>();
            _metricRepository = uow.GetRepository<Metric>();
            _questionRepository = uow.GetRepository<Question>();
            _answerRepository = uow.GetRepository<Answer>();
        }

        public bool CheckUser(UserDTO user)
        {
            return _userRepository.Any(w => w.Username == user.Username && w.Password == user.Password);
        }

        public AdminContestObject GetCurrentQuestion(int currentQuestionOrder)
        {
            return _questionRepository
                .GetBy(b => b.Order == currentQuestionOrder)
                .Include(i => i.Answers)
                .ToList()
                .Select(s => new AdminContestObject
                {
                    Question = s.Text,
                    Answer1 = s.Answers[0].Text,
                    Answer2 = s.Answers[1].Text,
                    Answer3 = s.Answers[2].Text,
                    Answer4 = s.Answers[3].Text,
                }).FirstOrDefault();
        }

        public void AddQuestion(AddQuestionObject aqo)
        {
            Metric metric = new();

            Question question = new Question
            {
                Metric = metric,
                Text = aqo.Question
            };

            var answers = new List<Answer>
            {
                new Answer { Text = aqo.Answer1 },
                new Answer { Text = aqo.Answer2 },
                new Answer { Text = aqo.Answer3 },
                new Answer { Text = aqo.Answer4 }
            };

            answers.ForEach(each => each.Question = question);
            answers[aqo.TrueAnswer - 1].IsTrue = true;
            question.Answers = answers;

            _metricRepository.Insert(metric);
            _questionRepository.Insert(question);
            _answerRepository.Insert(answers);
        }
    }
}
