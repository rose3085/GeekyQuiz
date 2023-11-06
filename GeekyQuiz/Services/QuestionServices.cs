
namespace GeekyQuiz.Services.QuestionServices
{
    public class QuestionServices : IQuestionServices
    {
        public static List<QuestionModel> questions = new List<QuestionModel>
        {
            new QuestionModel
            {
                QuestionId=1,
                Question = "What does IP stands for?"
            },
            new QuestionModel
            {
                QuestionId = 2,
                Question = "Which one of the following is not Http Protocol?"
            }
        };
        private readonly DataContext _context;
        public QuestionServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<QuestionModel>> AddQuestion(QuestionModel question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return await _context.Questions.ToListAsync();
        }
        public async Task<List<QuestionModel>?> DeleteQuestion(int id)
        {
            var results = await _context.Questions.FindAsync(id);
            if (results is null)
            {
                return null;
            }
            _context.Questions.Remove(results);
            await _context.SaveChangesAsync();
            return await _context.Questions.ToListAsync();
        }
       
        public async Task<List<QuestionModel>> GetAllQuestion()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<QuestionModel?> GetSingleQuestion(int id)
        {
            var result = await _context.Questions.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<QuestionModel>?> UpdateQuestion(int id, QuestionModel request)
        {
            var result = await _context.Questions.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            result.Question = request.Question;
            await _context.SaveChangesAsync();
            return await _context.Questions.ToListAsync();
        }
        public async Task<List<QuestionModel>> GetRandomQuestions(int numberOfQuestions)
        {
            var randomQuestions = _context.Questions
                .OrderBy(q => Guid.NewGuid()) // Shuffling the questions
                .Take(numberOfQuestions)
                .ToList();

            return randomQuestions;

        }


    }
}