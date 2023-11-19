using GeekyQuiz.DTO;
using OpenAI_API.Moderation;

namespace GeekyQuiz.Services.ResultServices
{
    public interface IResultServices 
    {
        List<Result> GetResult();
        string AddResult(int userId, CreateResultDto result);
        List<Result> GetByUserName(string userName);
    }
}
