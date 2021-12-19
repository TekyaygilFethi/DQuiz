using System;
using System.ComponentModel.DataAnnotations.Schema;
using DQuiz.Data.Base.Classes;

namespace DQuiz.Data.POCO
{
    [Table("UserTable")]
    public class User : PrimaryKeyEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
