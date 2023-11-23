using AutoMapper;
using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Moderation;
using System.Linq;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        private readonly IQuestionServices _questionServices;
        private readonly IResultServices _resultServices;
        private readonly IOptionServices _optionServices;
        public LoginController(ILoginServices loginServices,
                                IQuestionServices questionServices,
                                IResultServices resultServices)
        {
            _loginServices = loginServices;
            _questionServices = questionServices;
            _resultServices = resultServices;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDetail>> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _loginServices.RegisterUserAsync(model).Result;

                return Ok(result);
            }



            return BadRequest();
        }
        [HttpGet("Login")]
        public async Task<ActionResult<UserDetail>> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var result =_loginServices.LoginUser(email, password);
                if (result == null)
                {
                    return NotFound(email + " is not registered.");
                }
                else
                    return Ok(result);
            }
            return BadRequest();
        }

        /*
        [HttpGet]
        [Route("GetAllQuestion")]
        public async Task<ActionResult<List<QuestionModel>>> GetAllQuestion()
        {
            return await _questionServices.GetAllQuestion();
        }

        [HttpGet("{id}")]
        [Route("GetSingleQuestion")]
        public async Task<IActionResult> GetSingleQuestion(int id)
        {
            var result = await _questionServices.GetSingleQuestion(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);


        }

        [HttpPut("{id}")]
        [Route("UpdateQuestion")]
        public async Task<ActionResult<List<UserDetail>>?> UpdateQuestion(int id, QuestionModel request)
        {
            var result = await _questionServices.UpdateQuestion(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Route("DeleteQuestion")]
        public async Task<ActionResult<List<UserDetail>>?> DeleteQuestion(int id)
        {
            var result = await _questionServices.DeleteQuestion(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }


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
        
        

        [HttpGet]
        [Route("GetAllChoice")]
        public async Task<ActionResult<List<OptionModel>>> GetAllChoice()
        {
            return await _optionServices.GetAllOption();
        }
        [HttpGet("{id}")]
        [Route("GetSingleQuestionOption")]
        public async Task<ActionResult<OptionModel>?> GetSingleQuestionOption(int id)
        {
            var result = await _optionServices.GetSingleQuestionOption(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPost("{id}")]
        [Route("AddOptions")]
        public async Task<ActionResult<string>> AddOptions(QuestionOption questionOption)
        {
            var result = await _optionServices.AddOptions(questionOption);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateOption")]
        public async Task<ActionResult<string>> EditOption(int id, OptionModel updateOption)
        {
            if (updateOption == null) return BadRequest(ModelState);
            if (id != updateOption.OptionId) return BadRequest(ModelState);

            var res = _optionServices.UpdateOption(id, updateOption);
            return Ok(res);
        }
        
        */
    }
}
