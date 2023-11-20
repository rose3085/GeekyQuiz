namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetById(int id);
        Task<string> AddQuestion(Question question);
        Task<string> EditQuestion(int id, Question ques);
    }
}
