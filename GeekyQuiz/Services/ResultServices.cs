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
        public  List<Result> GetResult()
        {
            var allResult = _context.Results.ToList();
            return allResult;
        }
        public string AddResult(int userId, CreateResultDto result)
        {
            var existingUser = _context.User.FirstOrDefault(x => x.Id == userId);
            if (existingUser == null)
            {
                return "User not found";
            }
            var _result = new ResultModel()
            {
                Users = existingUser,
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
            var user = _context.User.FirstOrDefault(x => x.UserName == userName);
            var results = _context.Results.Where(x => x.Users == user).ToList();
            return results;
        }
    }
}
