using GeekyQuiz.Models.DTOs;
using GeekyQuiz.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private IOptionRepository _optionRepository;
        public OptionController(IOptionRepository _optRepo)
        {
            _optionRepository = _optRepo;
        }
        [HttpPost]
        [Route("AddOptions")]
        public async Task<IActionResult> AddOption(QuestionOption questionopts)
        {
            var res = await _optionRepository.AddOptions(questionopts);

            return Ok(res);
        }
        [HttpPut]
        [Route("EditOptions")]
        public async Task<IActionResult> EditOption(int id, Option updateOption)
        {
            if (updateOption == null) return BadRequest(ModelState);
            if(id != updateOption.OptionId) return BadRequest(ModelState);

            var res = await _optionRepository.EditOptions(id, updateOption);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetByID")]
        public async Task<IActionResult> GetOptions(int id)
        {
            var res = await _optionRepository.GetById(id);
            return Ok(res);
        }
    }
}
