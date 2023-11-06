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
        public List<Question> GetAllQuestions()
        {
            var questions = _context.Questions.ToList();
            return questions;
        }
        public Question GetById(int id)
        {
            var question = _context.Questions.FirstOrDefault(x=>x.QuestionId == id);
            if (question != null)
            {
                return question;
            }
            return null;
        }
        public string AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return "New question added succesfully";
        }
        public string EditQuestion(int id, Question ques)
        {
            var question = _context.Questions.FirstOrDefault(x=>x.QuestionId==id);
            if (question != null)
            {
                question = ques;
                _context.SaveChanges();
                return "Question edited";
            }
            return "Question not found";
        }
    }
}
