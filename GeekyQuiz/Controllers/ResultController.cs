using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IResultServices _resultServices;
        public ResultController(IResultServices resultServices)
        {
            _resultServices = resultServices;
        }
        /*
        [HttpGet]
        [Route("GetResult")]
        public async Task<IActionResult> Get()
        {
            var res =await _result.GetResult();
            if (res == null)
            {
                return BadRequest("Not found");
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("AddResult")]
        public async Task<IActionResult> AddResult(int userId, CreateResultDto result)
        {
            var res = await _result.AddResult(userId, result);
            return Ok(res);

        }
        
        [HttpGet]
        [Route("GetByUserName")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var res = await _result.GetByUserName(userName);
            if (res == null)
            {
                return BadRequest("Not found");
            }
            return Ok(res);
        }

        */
        [HttpGet]
        [Route("GetResult")]
        public async Task<ActionResult<List<ResultModel>>> GetResult()
        {
            var res = await _resultServices.GetResult();
            if (res == null)
            {
                return BadRequest("Not found");
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("AddResult")]
        public async Task<ActionResult<string>> AddResult(int userId, CreateResultDto result)
        {
            var res = await _resultServices.AddResult(userId, result);
            return Ok(res);

        }
        

        [HttpGet]
        [Route("GetByUserName")]
        public async Task<ActionResult<List<ResultModel>>> GetByUserName(string userName)
        {
            var res = await _resultServices.GetByUserName(userName);
            if (res == null)
            {
                return BadRequest("Not found");
            }
            return Ok(res);
        }

    }
}
