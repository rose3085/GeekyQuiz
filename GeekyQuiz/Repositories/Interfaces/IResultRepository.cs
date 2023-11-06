using GeekyQuiz.Models.DTOs;

namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IResultRepository
    {
        List<Result> GetResult();
        string AddResult(int userId, CreateResultDto result);
       List<Result> GetByUserName(string userName);
    }
}
