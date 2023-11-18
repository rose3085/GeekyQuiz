using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("GetAnswer")]
        public async Task<IActionResult> GetResult(string input)
        {
            string apiKey = "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";
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 1024;
            completion.Temperature = 0.5;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response += item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}


