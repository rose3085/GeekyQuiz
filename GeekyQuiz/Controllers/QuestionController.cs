using GeekyQuiz.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository _questionRepo;
        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet]
        [Route("GetQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var res = await _questionRepo.GetAllQuestions();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetQuestionById/{id}")]
        public async Task<IActionResult> GetQuestions(int id)
        {
            var res = await _questionRepo.GetById(id);
            return Ok(res);
        }
        /*[HttpPost]
        [Route("AddQuestion")]
        public IActionResult AddQuestion(Question question)
        {
            var res = _questionRepo.AddQuestion(question);
            return Ok(res);
        }*/
        [HttpPut]
        [Route("EditQuestion/{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, Question question)
        {
            if(id!=question.QuestionId)
                return BadRequest(ModelState);
            var res = await _questionRepo.EditQuestion(id, question);
            return Ok(res);
        }
    }
}
