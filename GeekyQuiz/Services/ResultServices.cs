using GeekyQuiz.DTO;

using OpenAI_API.Moderation;

namespace GeekyQuiz.Services.ResultServices
{
    public class ResultServices : IResultServices
    {
        private readonly DataContext _context;
        public ResultServices(DataContext context)
        {
            _context = context;
        }
        public async Task< List<ResultModel>> GetResult()
        {
            var allResult = await _context.Results.ToListAsync();
            return allResult;
        }
        public async Task<List<ResultModel>> AddResult(int userId, CreateResultDto result)
        {
            var existingUser = _context.User.FirstOrDefault(x => x.Id == userId);
            if (existingUser == null)
            {
                return null;
            }
            var _result = new ResultModel()
            {
                Users = existingUser,
                Score = result.Score,
                StartTime = result.StarTime,
                EndTime = result.EndTime,
            };
            await _context.AddAsync(_result);
            await _context.SaveChangesAsync();
            return await _context.Results.ToListAsync();
        }
        public async Task<List<ResultModel>> GetByUserName(string userName)
        {
            var user =await _context.User.FindAsync(userName);
            var results =await _context.Results.Where(x => x.Users == user).ToListAsync();
            return results;
        }
    }
}
