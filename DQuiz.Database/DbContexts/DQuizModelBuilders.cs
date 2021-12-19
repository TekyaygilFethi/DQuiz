using System;
using DQuiz.Data.POCO;
using Microsoft.EntityFrameworkCore;

namespace DQuiz.Database.DbContexts
{
    public static class DQuizModelBuilders
    {
        public static void ConfigureQuizBuilder(this ModelBuilder builder)
        {
            builder.Entity<Answer>()
                .HasOne(o => o.Question)
                .WithMany(m => m.Answers)
                .HasForeignKey(fk => fk.QuestionId);

            builder.Entity<Metric>()
               .HasOne(o => o.Question)
               .WithOne(m => m.Metric)
               .HasForeignKey<Metric>(fk => fk.QuestionId);

            builder.HasSequence<int>("OrderSequence")
                              .StartsAt(6).IncrementsBy(1);

            builder.Entity<Question>()
               .Property(x => x.Order)
               .HasDefaultValueSql("NEXT VALUE FOR OrderSequence");
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Question 1

            Question q1 = new Question
            {
                Id = 1,
                Text = "Star Wars evreninde Anakin Skywalker'ın ustası kimdir?",
                Order = 1
            };

            Metric q1m = new Metric { Id = 1, QuestionId = 1 };

            Answer q1a1 = new Answer
            {
                Id = 1,
                Text = "Adi Gallia",
                IsTrue = false,
                QuestionId = 1
            };

            Answer q1a2 = new Answer
            {
                Id = 2,
                Text = "Mace Windu",
                IsTrue = false,
                QuestionId = 1
            };

            Answer q1a3 = new Answer
            {
                Id = 3,
                Text = "Obi-Wan Kenobi",
                IsTrue = true,
                QuestionId = 1
            };

            Answer q1a4 = new Answer
            {
                Id = 4,
                Text = "Sheev Palpatine",
                IsTrue = false,
                QuestionId = 1
            };

            modelBuilder.Entity<Question>().HasData(
                q1
            );

            modelBuilder.Entity<Answer>().HasData(
                q1a1, q1a2, q1a3, q1a4
                );

            modelBuilder.Entity<Metric>().HasData(
                q1m);

            #endregion

            #region Question 2


            Question q2 = new Question
            {
                Id = 2,
                Text = "Metal Gear Solid serisinde Naked Snake, Big Boss ünvanını nasıl kazanmıştır?",
                Order = 2
            };

            Metric q2m = new Metric { Id = 2, QuestionId = 2 };

            Answer q2a1 = new Answer
            {
                Id = 5,
                Text = "Eski mentörü olan Boss'u öldürerek",
                IsTrue = true,
                QuestionId = 2
            };

            Answer q2a2 = new Answer
            {
                Id = 6,
                Text = "Eski mentörü olan Boss'u Amerika'ya teslim ederek",
                IsTrue = false,
                QuestionId = 2
            };

            Answer q2a3 = new Answer
            {
                Id = 7,
                Text = "Ünlü bilim adamı Sokolov'u Ruslardan kaçırarak",
                IsTrue = false,
                QuestionId = 2
            };

            Answer q2a4 = new Answer
            {
                Id = 8,
                Text = "Ocelot ile olan mücadelesini kazanarak",
                IsTrue = false,
                QuestionId = 2
            };

            modelBuilder.Entity<Question>().HasData(
                q2
            );

            modelBuilder.Entity<Answer>().HasData(
                q2a1, q2a2, q2a3, q2a4
                );

            modelBuilder.Entity<Metric>().HasData(
                q2m);

            #endregion

            #region Question 3

            Question q3 = new Question
            {
                Id = 3,
                Text = "Final Fantasy 7 Remake oyununda kahramanlarımız kaderi değiştirdiğinde, \"The Price of Freedom is Steep\" repliğiye akıllara kazınan ve ölmesi gerekirken ölmeyen karakter hangisidir?",
                Order = 3
            };

            Metric q3m = new Metric { Id = 3, QuestionId = 3 };


            Answer q3a1 = new Answer
            {
                Id = 9,
                Text = "Zack Fair",
                IsTrue = true,
                QuestionId = 3
            };

            Answer q3a2 = new Answer
            {
                Id = 10,
                Text = "Sephiroth",
                IsTrue = false,
                QuestionId = 3
            };

            Answer q3a3 = new Answer
            {
                Id = 11,
                Text = "Cloud",
                IsTrue = false,
                QuestionId = 3
            };

            Answer q3a4 = new Answer
            {
                Id = 12,
                Text = "Noctis",
                IsTrue = false,
                QuestionId = 3
            };

            modelBuilder.Entity<Question>().HasData(
                q3
            );

            modelBuilder.Entity<Answer>().HasData(
                q3a1, q3a2, q3a3, q3a4
                );

            modelBuilder.Entity<Metric>().HasData(
                q3m);

            #endregion

            #region Question 4

            Question q4 = new Question
            {
                Id = 4,
                Text = "Nier Replicant oyununda Devola ve Popola'nın tavernada söylediği şarkının adı nedir?",
                Order = 4
            };

            Metric q4m = new Metric { Id = 4, QuestionId = 4 };

            Answer q4a1 = new Answer
            {
                Id = 13,
                Text = "The Prestigious Mask",
                IsTrue = false,
                QuestionId = 4
            };

            Answer q4a2 = new Answer
            {
                Id = 14,
                Text = "Kaine Escape",
                IsTrue = false,
                QuestionId = 4
            };

            Answer q4a3 = new Answer
            {
                Id = 15,
                Text = "Deep Crimson Foe",
                IsTrue = false,
                QuestionId = 4
            };

            Answer q4a4 = new Answer
            {
                Id = 16,
                Text = "Song of The Ancient",
                IsTrue = true,
                QuestionId = 4
            };

            modelBuilder.Entity<Question>().HasData(
                q4
            );

            modelBuilder.Entity<Answer>().HasData(
                q4a1, q4a2, q4a3, q4a4
                );

            modelBuilder.Entity<Metric>().HasData(
                q4m);

            #endregion

            #region Question 5
            Question q5 = new Question
            {
                Id = 5,
                Text = "Silent Hill 2 oyununda kahramanımızın eşine tıpatıp benzeyen ve kahramanımızı cezalandırmak için gönderilen karakterin adı nedir?",
                Order = 5
            };

            Metric q5m = new Metric { Id = 5, QuestionId = 5 };

            Answer q5a1 = new Answer
            {
                Id = 17,
                Text = "Laura",
                IsTrue = false,
                QuestionId = 5
            };

            Answer q5a2 = new Answer
            {
                Id = 18,
                Text = "Maria",
                IsTrue = true,
                QuestionId = 5
            };

            Answer q5a3 = new Answer
            {
                Id = 19,
                Text = "Angela",
                IsTrue = false,
                QuestionId = 5
            };

            Answer q5a4 = new Answer
            {
                Id = 20,
                Text = "Eileen",
                IsTrue = false,
                QuestionId = 5
            };

            modelBuilder.Entity<Question>().HasData(
                q5
            );

            modelBuilder.Entity<Answer>().HasData(
                q5a1, q5a2, q5a3, q5a4
                );

            modelBuilder.Entity<Metric>().HasData(
                q5m);

            #endregion

            #region User
            User user = new User
            {
                Id = 1,
                Username = "GAIH",
                Password = "12345"
            };

            modelBuilder.Entity<User>().HasData(
                user);

            #endregion
        }
    }
}
