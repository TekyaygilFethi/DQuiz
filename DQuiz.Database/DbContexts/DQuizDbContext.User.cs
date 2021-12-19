using System;
using DQuiz.Data.POCO;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Database.DbContexts
{
    public partial class DQuizDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
