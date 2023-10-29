using GeekyQuiz.Services.QuestionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices questionServices;
        public QuestionController(IQuestionServices questionServices)
        {
            this.questionServices = questionServices;   
        }
        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>
    }
}
