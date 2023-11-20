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
        public async Task<List<Result>> GetResult()
        {
            var allResult = await _context.Results.ToListAsync();
            return allResult;
        }
        public async Task<string> AddResult(int userId, CreateResultDto result)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
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
            await _context.SaveChangesAsync();
            return "Result added";
        }
        public async Task<List<Result>> GetByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            var results = await _context.Results.Where(x => x.User == user).ToListAsync();
            return results;
        }
    }
}
