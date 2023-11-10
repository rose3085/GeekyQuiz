using OpenAI_API;
using OpenAI_API.Completions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GeekyQuiz.Services
{
    public class BackgroundWorkerServices : BackgroundService
    {
       
            private readonly ILogger<BackgroundWorkerServices> _logger;
           

            public BackgroundWorkerServices(ILogger<BackgroundWorkerServices> logger)
            {
                _logger = logger;
            }

            protected async override  Task ExecuteAsync(CancellationToken stoppingToken)
             {
            
            while (!stoppingToken.IsCancellationRequested)
                {
                
                _logger.LogInformation("Worker running at:{time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }

            }
        
    }
}
