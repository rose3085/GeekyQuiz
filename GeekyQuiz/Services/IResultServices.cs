using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Services
{
    public interface IResultServices
    {
        Task<List<ResultModel>> GetAllResult();
        Task<List<ResultModel>> GetSingleResult(int id);
        Task<List<ResultModel>> AddResult(ResultModel user);
        Task<List<ResultModel>> UpdateResult(int id, ResultModel request);
        Task<List<ResultModel>> DeleteResult(int id);
        
    }
}
