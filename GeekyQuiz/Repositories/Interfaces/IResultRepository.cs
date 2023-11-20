using GeekyQuiz.Models.DTOs;

namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<List<Result>> GetResult();
        Task<string> AddResult(int userId, CreateResultDto result);
       Task<List<Result>> GetByUserName(string userName);
    }
}
