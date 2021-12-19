using System;
using System.ComponentModel.DataAnnotations.Schema;
using DQuiz.Data.Base;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.POCO
{
    [Table("AnswerTable")]
    public class Answer : PrimaryKeyEntity
    {
        public string Text { get; set; }

        public Question Question {get;set;}
        public int QuestionId { get; set; }

        public bool IsTrue { get; set; } = false;

        public int ChosenCount { get; set; } = 0;
    }
}
