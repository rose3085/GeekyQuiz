﻿using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace GeekyQuiz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = .\\SQLExpress;Database=GeekyQuizDb;Trusted_Connection=true;TrustServerCertificate=true;");

        }
        public DbSet<UserDetail> Users { get; set; }
        
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserAnswerModel> Answers { get; set; }
        public DbSet<ChoiceModel> Choices { get; set; }

    }
}
