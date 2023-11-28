using GeekyQuiz.Repositories.Interfaces;
using OpenAI_API.Completions;
using OpenAI_API;
using Microsoft.OpenApi.Exceptions;
using GeekyQuiz.DTO;
using Microsoft.Extensions.Logging;
//using GeekyQuiz.Models.DTOs;
using GeekyQuiz.Services;
//using System.Threading.Tasks;
//using System.Collections.Generic;

namespace GeekyQuiz.Cron
{
    public class OpenAICronJob : CronJobService
    {
        private readonly ILogger<OpenAICronJob> _logger;
        private readonly IServiceProvider _serviceProvider;
        public OpenAICronJob(IScheduleConfig<OpenAICronJob> config, ILogger<OpenAICronJob> logger, IServiceProvider serviceProvider)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OpenAI CronJob starts.");
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} OpenAI CronJob is working.");
            try
            {
                //string apiKey = "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";
                string apiKey = "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";
                string ques = " 10 MCQ Quiz computer science question with their 4 options";
                var prompt = $"Q: {ques}\nA:";
                OpenAIAPI openai = new OpenAIAPI(apiKey);
                CompletionRequest completion = new CompletionRequest();
                completion.Prompt = prompt;
                completion.Model = "text-davinci-002";
                completion.MaxTokens = 1024;
                completion.Temperature = 0.5;
                var output = await openai.Completions.CreateCompletionAsync(completion);
                _logger.LogInformation($"OpenAI API Response: {output.Completions.FirstOrDefault()?.Text}");
                var separatedData = SeparateQuestionAndOptions(output.Completions.FirstOrDefault()?.Text);
                string question = separatedData.question;
                string optionA = separatedData.optionA;
                string optionB = separatedData.optionB;
                string optionC = separatedData.optionC;
                string optionD = separatedData.optionD;
                char correctOption = separatedData.correctOption;
                _logger.LogInformation($"Question: {question}");
                _logger.LogInformation($"OptionA : {optionA}");
                _logger.LogInformation($"OptionB : {optionB}");
                _logger.LogInformation($"OptionC : {optionC}");
                _logger.LogInformation($"OptionD : {optionD}");
                _logger.LogInformation($"Correct Option : {correctOption}");
                var questionOptions = new QuestionOption
                {
                    OptionA = optionA,
                    OptionB = optionB,
                    OptionC = optionC,
                    OptionD = optionD,
                    CorrectOption = correctOption,
                    Question = question,
                };
                using (var scope = _serviceProvider.CreateScope())
                {
                    var optionRepository = scope.ServiceProvider.GetRequiredService<IChoiceServices>();
                    var res = await optionRepository.AddChoice(questionOptions);
                    _logger.LogInformation(res);
                }
                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
            }

        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OpenAI CronJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
        private (string question, string optionA, string optionB, string optionC, string optionD, char correctOption) SeparateQuestionAndOptions(string responseText)
        {
            var parts = responseText.Split(new[] { "A.", "B.", "C.", "D.", "a.", "b.", "c.", "d." }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2)
            {
                string question = parts[0].Trim();
                question = question.Remove(0, 3);
                string optionA = parts.ElementAtOrDefault(1)?.Trim() ?? "";
                string optionB = parts.ElementAtOrDefault(2)?.Trim() ?? "";
                string optionC = parts.ElementAtOrDefault(3)?.Trim() ?? "";
                string optionD = parts.ElementAtOrDefault(4)?.Trim() ?? "";
                string correctOption = parts.Last().Trim();
                char correctOptionChar;
                if (correctOption == optionA)
                    correctOptionChar = 'A';
                else if (correctOption == optionB)
                    correctOptionChar = 'B';
                else if (correctOption == optionC)
                    correctOptionChar = 'C';
                else
                    correctOptionChar = 'D';
                return (question, optionA, optionB, optionC, optionD, correctOptionChar);
            }
            throw new InvalidOperationException("Invalid response format");
        }
    }
}