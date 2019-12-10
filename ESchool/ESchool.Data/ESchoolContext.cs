using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using ESchool.Data.Configurations;
using ESchool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESchool.Data
{
    public class ESchoolContext : IdentityDbContext<User>
    {
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamsQuestions { get; set; }
        public DbSet<ExamQuestionAnswer> ExamsQuestionsAnswers { get; set; }
        public DbSet<OfferedAnswer> OfferedAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }




        public ESchoolContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
