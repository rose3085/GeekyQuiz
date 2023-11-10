
using OpenAI_API.Completions;
using OpenAI_API;
using System.Threading;

namespace GeekyQuiz.Services.TaskSchedulerService
{
    public class TaskSchedulerServices : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        //private readonly TaskSchedulerService _openAiTaskScheduler;
        public TaskSchedulerServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
           // _openAiTaskScheduler = openAiTaskScheduler;

        }
        private Timer _timer;
        private string query;

        public void start()
        {

            TimeSpan interval = TimeSpan.FromMinutes(5);
            _timer = new Timer(Callback, null, TimeSpan.Zero, interval);
        }
        public async void Callback(object state)
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
            return await _serviceProvider

        }
        public void Stop()
        {
            //stop timer when program is closed
            _timer?.Change(Timeout.Infinite, 0);
        }
       
        public void Dispose()
        {
            Stop();
        }
    }
}
