using GeekyQuiz.Services.QuestionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using GeekyQuiz.Models;
using Microsoft.EntityFrameworkCore;
using GeekyQuiz.DTO;
//using GeekyQuiz.Models.QuestionModel.Models;


namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices _questionServices;
        //private object? randomQuestion;

        public QuestionController(IQuestionServices questionServices)
        {
            _questionServices = questionServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>> GetAllQuestion()
        {
            return await _questionServices.GetAllQuestion();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<QuestionModel>>?> GetSingleQuestion(int id)
        {
            var result = await _questionServices.GetSingleQuestion(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);


        }
        [HttpGet("Random")]
        public async Task<ActionResult<List<QuestionModel>>?> GetRandomQuestion(int numberOfQuestions)
        {
            var result = await _questionServices.GetRandomQuestion(numberOfQuestions);
            if (result is null)
            {
                return null;
            }
            return Ok(result);


        }
        //[HttpGet("Get Random Question")]
        //public IActionResult? RandomQuestion(QuestionDto model)
        //{
        //    var result = _questionServices.GetRandomQuestions(model);
        //    if (result is null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<ActionResult<List<LoginModel>>> AddQuestion(QuestionModel question)
        {
            var result = await _questionServices.AddQuestion(question);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> UpdateQuestion(int id, QuestionModel request)
        {
            var result = await _questionServices.UpdateQuestion(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> DeleteQuestion(int id)
        {
            var result = await _questionServices.DeleteQuestion(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }

    }
}