using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.UserAnswerServices
{
    public interface IUserAnswerServices
    {
        Task<List<UserAnswerModel>> GetAllAnswer();
        Task<UserAnswerModel?> GetSingleAnswer(int id);
        Task<List<UserAnswerModel>> AddAnswer(UserAnswerDto answer);
       

    }
}

