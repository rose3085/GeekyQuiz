using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string outputResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            return Ok(outputResult);

        }
    }
}
