using System;
using DQuiz.Data.POCO;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Database.DbContexts
{
    public partial class DQuizDbContext
    {
		public DbSet<Answer> Answers { get; set; }

		public DbSet<Metric> Metrics { get; set; }

		public DbSet<Question> Questions { get; set; }

		private void ConfigureQuizEntities(ModelBuilder builder)
		{
			builder.ConfigureQuizBuilder();
			builder.Seed();
		}
	}
}
