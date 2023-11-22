using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Services.UserAnswerServices
{
    public interface IUserAnswerServices
    {
        Task<List<UserAnswerModel>> GetAllAnswer();
        Task<UserAnswerModel?> GetSingleAnswer(int id);
        Task<List<UserAnswerModel>> AddAnswer(UserAnswerModel answer);
       // Task<List<UserAnswerModel>?> UpdateAnswer(int id, UserAnswerModel request);
       // Task<List<UserAnswerModel>?> DeleteAnswer(int id);
       
    }
}