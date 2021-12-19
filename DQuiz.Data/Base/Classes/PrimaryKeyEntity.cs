using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DQuiz.Data.Base.Interfaces;

namespace DQuiz.Data.Base.Classes
{
    public class PrimaryKeyEntity : IPrimaryKey<int>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
