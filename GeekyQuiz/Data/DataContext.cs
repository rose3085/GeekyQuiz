using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace GeekyQuiz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<QuestionModel>()
        //        .HasMany(q => q.Choices)
        //        .WithOne(o => o.QuestionId)
        //        .HasForeignKey(o => o.QuestionId);
        //}

        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserAnswerModel> Answers { get; set; }
        public DbSet<ChoiceModel> Choices { get; set; }
        public DbSet<ResultModel> Results { get; set; }
    }
}