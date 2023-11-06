using GeekyQuiz.Models.DTOs;
using GeekyQuiz.Repositories.Interfaces;

namespace GeekyQuiz.Repositories.Implementations
{
    public class ResultRepository : IResultRepository
    {
        private readonly DataContext _context;
        public ResultRepository(DataContext context)
        {
            _context = context;
        }
        public List<Result> GetResult()
        {
            var allResult = _context.Results.ToList();
            return allResult;
        }
        public string AddResult(int userId, CreateResultDto result)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if(existingUser == null)
            {
                return "User not found";
            }
            var _result = new Result()
            {
                User = existingUser,
                Score = result.Score,
                StartTime = result.StarTime,
                EndTime = result.EndTime,
            };
            _context.Add(_result);
            _context.SaveChanges();
            return "Result added";
        }
        public List<Result> GetByUserName(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            var results = _context.Results.Where(x => x.User == user).ToList();
            return results;
        }
    }
}
