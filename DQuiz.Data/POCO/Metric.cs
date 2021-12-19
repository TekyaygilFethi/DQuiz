using System;
using System.ComponentModel.DataAnnotations.Schema;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.POCO
{
    [Table("MetricTable")]
    public class Metric : PrimaryKeyEntity
    {
        public int TrueCount { get; set; } = 0;

        public int FalseCount { get; set; } = 0;

        public Question Question { get; set; }

        public int QuestionId {get;set;}
    }
}
