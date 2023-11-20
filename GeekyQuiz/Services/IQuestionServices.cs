using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.QuestionServices
{
    public interface IQuestionServices
    {
       
        Task<List<QuestionModel>?> DeleteQuestion(int id);
        Task<List<QuestionModel>> GetAllQuestion();
        Task<string> AddQuestion(QuestionModel question);
        Task<QuestionModel?> GetSingleQuestion(int id);
        Task<string> UpdateQuestion(int id, QuestionModel request);


        

    }
}