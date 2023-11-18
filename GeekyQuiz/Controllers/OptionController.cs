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
        public IActionResult AddOption(QuestionOption questionopts)
        {
            var res = _optionRepository.AddOptions(questionopts);

            return Ok(res);
        }
        [HttpPut]
        [Route("EditOptions")]
        public IActionResult EditOption(int id, Option updateOption)
        {
            if (updateOption == null) return BadRequest(ModelState);
            if(id != updateOption.OptionId) return BadRequest(ModelState);

            var res = _optionRepository.EditOptions(id, updateOption);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetOptions(int id)
        {
            var res = _optionRepository.GetById(id);
            return Ok(res);
        }
    }
}
