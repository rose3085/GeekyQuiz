
using GeekyQuiz.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultServices _resultServices;

        public ResultController(IResultServices resultServices)
        {
            _resultServices = resultServices;
        }

        [HttpGet]

        public async Task<ActionResult<List<ResultModel>>> GetAllResult()
        {
            return await _resultServices.GetAllResult();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<List<ResultModel>>> GetSingleResult(int id)
        {
            var result = await _resultServices.GetSingleResult(id);
            if (result == null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPost("{id}")]

        public async Task<ActionResult<List<ResultModel>>> AddUser(ResultModel userResult)
        {
            var result = await _resultServices.AddResult(userResult);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<ResultModel>>?> UpdateAnswer(int id, ResultModel request)
        {
            var result = await _resultServices.UpdateResult(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ResultModel>>?> DeleteAnswer(int id)
        {
            var result = await _resultServices.DeleteResult(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
    }
}