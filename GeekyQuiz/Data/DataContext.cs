using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace GeekyQuiz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<UserDetail> User { get; set; }
        
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<ResultModel> Results { get; set; }
        public DbSet<OptionModel> Options{ get; set; }
        public DbSet<UserAnswerModel> Answers { get; set; }

    }
}
