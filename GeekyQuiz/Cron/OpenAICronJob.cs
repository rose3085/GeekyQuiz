using GeekyQuiz.Repositories.Interfaces;
using OpenAI_API.Completions;
using OpenAI_API;
using Microsoft.OpenApi.Exceptions;

namespace GeekyQuiz.Cron
{
    public class OpenAICronJob : CronJobService
    {
        private readonly ILogger<OpenAICronJob> _logger;

        public OpenAICronJob(IScheduleConfig<OpenAICronJob> config, ILogger<OpenAICronJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OpenAI CronJob starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} OpenAI CronJob is working.");
            return Task.CompletedTask;
            //try
            //{
            //    string apiKey = "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";
            //    string input = "Quiz question about computer science";
            //    OpenAIAPI openai = new OpenAIAPI(apiKey);
            //    CompletionRequest completion = new CompletionRequest();
            //    completion.Prompt = input;
            //    completion.Model = "gpt-3.5-turbo";
            //    completion.MaxTokens = 1024;
            //    completion.Temperature = 0.5;
            //    var output = await openai.Completions.CreateCompletionAsync(completion);
            //    _logger.LogInformation($"OpenAI API Response: {output.Completions.FirstOrDefault()?.Text}");
            //    return await Task.CompletedTask;

            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"An error occurred: {ex.Message}");
            //}
            
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OpenAI CronJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }

}
