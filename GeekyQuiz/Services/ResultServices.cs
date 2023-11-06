using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Services
{
    public class ResultServices : IResultServices
    {
        private readonly DataContext _context;

        public ResultServices(DataContext context)
        {
            _context = context;
        }

        public Task<List<ResultModel>> AddResult(ResultModel user)
        {
            throw new NotImplementedException();
        }

        //public Task<List<ResultModel>> AddResult(ResultModel user)
        //{
        //    _context.Results.Add(user);
        //     await _context.SaveChangesAsync();
        //     return await _context.Results.ToListAsync();
        //}

        public Task<List<ResultModel>> DeleteResult(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultModel>> GetAllResult()
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultModel>> GetSingleResult(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultModel>> UpdateResult(int id, ResultModel request)
        {
            throw new NotImplementedException();
        }
    }
}
