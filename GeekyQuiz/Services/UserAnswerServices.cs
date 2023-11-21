using GeekyQuiz.DTO;
using Microsoft.EntityFrameworkCore;

namespace GeekyQuiz.Services.UserAnswerServices
{
    public class UserAnswerServices : IUserAnswerServices
    {
       
        private readonly DataContext _context;
        public UserAnswerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserAnswerModel>> AddAnswer(UserAnswerDto answer)
        {
            var answerDto = new UserAnswerDto()
            {
                UserAnswer = answer.UserAnswer,
            };
            //await _context.Answers.AnyAsync(answer);
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
    }
}
