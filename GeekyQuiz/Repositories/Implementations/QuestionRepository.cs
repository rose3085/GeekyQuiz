using GeekyQuiz.Repositories.Interfaces;

namespace GeekyQuiz.Repositories.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }
        public async Task<Question> GetById(int id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x=>x.QuestionId == id);
            if (question != null)
            {
                return question;
            }
            return null;
        }
        public async Task<string> AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return "New question added succesfully";
        }
        public async Task<string> EditQuestion(int id, Question ques)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x=>x.QuestionId==id);
            if (question != null)
            {
                question = ques;
                await _context.SaveChangesAsync();
                return "Question edited";
            }
            return "Question not found";
        }
    }
}
