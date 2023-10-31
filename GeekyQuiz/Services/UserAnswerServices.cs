namespace GeekyQuiz.Services.UserAnswerServices
{
    public class UserAnswerServices : IUserAnswerServices
    {
        public static List<UserAnswerModel> AnswerList = new List<UserAnswerModel>
        {
            new UserAnswerModel
            {
               AnswerId = 1,
               PlayId=1,
               QuestionId = 1,
               UserAnswer = "A",
               IsCorrect = true
            }
        };
        private readonly DataContext _context;
        public UserAnswerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserAnswerModel>> AddAnswer(UserAnswerModel answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return await _context.Answers.ToListAsync();
        }

        public async Task<List<UserAnswerModel>?> DeleteAnswer(int id)
        {
            var results = await _context.Answers.FindAsync(id);
            if (results is null)
            {
                return null;
            }
            _context.Answers.Remove(results);
            await _context.SaveChangesAsync();
            return await _context.Answers.ToListAsync();
        }

        public async Task<List<UserAnswerModel>> GetAllAnswer()
        {
           var results = await _context.Answers.ToListAsync();
            return results;
        }

        public async Task<UserAnswerModel?> GetSingleAnswer(int id)
        {
            var results = await _context.Answers.FindAsync(id);
            if (results is null)
            {
                return null;
            }
            return results;
        }

        public async Task<List<UserAnswerModel>?> UpdateAnswer(int id, UserAnswerModel request)
        {
            var results = await _context.Answers.FindAsync(id);
            if (results is null)
            {
                return null;
            }

            results.PlayId = request.PlayId;
            results.AnswerId = request.AnswerId;
            results.UserAnswer = request.UserAnswer;
            results.IsCorrect = request.IsCorrect;

            _context.Answers.Update(results);
            await _context.SaveChangesAsync();
            return await _context.Answers.ToListAsync();
        }
    }
}
