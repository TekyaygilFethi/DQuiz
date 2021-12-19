using System;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Database.DbContexts
{
    public partial class DQuizDbContext:DbContext
    {
        public DQuizDbContext(DbContextOptions<DQuizDbContext> options) : base(options) { }

        public DQuizDbContext()
          : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureQuizEntities(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.EnableSensitiveDataLogging();
        }
    }
}
