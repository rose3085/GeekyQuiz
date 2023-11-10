
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
       private readonly TaskSchedulerService _taskSchedulerService;
        public ChatController()
        {
            _taskSchedulerService = new TaskSchedulerService();
        }
        [HttpGet]
        [Route("UseChatGPT")]
        public IActionResult UseChatGPT(TaskSchedulerServices taskSchedulerService)
        {
            object result = Start(_taskSchedulerService);
            return Ok(result);
        }
    }
}
