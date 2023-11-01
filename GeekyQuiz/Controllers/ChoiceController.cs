using GeekyQuiz.Services.ChoiceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceServices _choiceServices;
        public ChoiceController(IChoiceServices choiceServices)
        {
            _choiceServices = choiceServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<ChoiceModel>>> GetAllChoice()
        {
            return await _choiceServices.GetAllChoice();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ChoiceModel>>?> GetSingleChoice(int id)
        {
            var result = await _choiceServices.GetSingleChoice(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<List<ChoiceModel>>> AddChoice(ChoiceModel user)
        {
            var result = await _choiceServices.AddChoice(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ChoiceModel>>?> UpdateChoice(int id, ChoiceModel request)
        {
            var result = await _choiceServices.UpdateChoice(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ChoiceModel>>?> DeleteChoice(int id)
        {
            var result = await _choiceServices.DeleteChoice(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
    }
}