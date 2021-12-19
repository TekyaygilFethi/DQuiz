using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.POCO
{
    [Table("QuestionTable")]
    public class Question : PrimaryKeyEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order { get; set; }

        public string Text { get; set; }
        
        public Metric Metric { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
