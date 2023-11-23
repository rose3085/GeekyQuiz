using GeekyQuiz.DTO;
using GeekyQuiz.Services.ChoiceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IOptionServices _optionServices;
        public ChoiceController(IOptionServices optionServices)
        {
            _optionServices = optionServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<OptionModel>>> GetAllChoice()
        {
            return await _optionServices.GetAllOption();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleQuestionOption(int id)
        {
            var result = await _optionServices.GetSingleQuestionOption(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> AddOptions(QuestionOption questionOption)
        { 
            var result =await _optionServices.AddOptions(questionOption);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateOption")]
        public async Task<ActionResult> EditOption(int id, OptionModel updateOption)
        {
            if (updateOption == null) return BadRequest(ModelState);
            if (id != updateOption.OptionId) return BadRequest(ModelState);

            var res = _optionServices.UpdateOption(id, updateOption);
            return Ok(res);
        }
        /*
        
        
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
