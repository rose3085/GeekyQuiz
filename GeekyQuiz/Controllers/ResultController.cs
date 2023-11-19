using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IResultServices _result;
        public ResultController(IResultServices result)
        {
            _result = result;
        }
        [HttpGet]
        [Route("GetResult")]
        public IActionResult Get()
        {
            var res = _result.GetResult();
            return Ok(res);
        }

        [HttpPost]
        [Route("AddResult")]
        public IActionResult AddResult(int userId, CreateResultDto result)
        {
            var res = _result.AddResult(userId, result);
            return Ok(res);

        }
        [HttpGet]
        [Route("GetByUserName")]
        public IActionResult GetByUserName(string userName)
        {
            var res = _result.GetByUserName(userName);
            return Ok(res);
        }

    }
}
