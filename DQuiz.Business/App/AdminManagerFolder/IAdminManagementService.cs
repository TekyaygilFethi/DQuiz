using System;
using DQuiz.Data.App.Admin;

namespace DQuiz.Business.App.AdminManagerFolder
{
    public interface IAdminManagementService
    {
        public bool CheckUser(UserDTO user);
        public void AddQuestion(AddQuestionObject question);
        public AdminContestObject GetCurrentQuestion(int currentQuestionOrder);
    }
}
