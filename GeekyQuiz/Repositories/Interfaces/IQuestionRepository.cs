namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        List<Question> GetAllQuestions();
        Question GetById(int id);
        string AddQuestion(Question question);
        string EditQuestion(int id, Question ques);
    }
}
