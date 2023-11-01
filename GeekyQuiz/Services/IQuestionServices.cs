namespace GeekyQuiz.Services.QuestionServices
{
    public interface IQuestionServices
    {
        Task<List<QuestionModel>> AddQuestion(QuestionModel question);
        Task<List<QuestionModel>?> DeleteQuestion(int id);
        Task<List<QuestionModel>> GetAllQuestion();
        Task<QuestionModel?> GetSingleQuestion(int id);
        Task<List<QuestionModel>?> UpdateQuestion(int id, QuestionModel request);
    }
}