﻿namespace GeekyQuiz.Services.QuestionServices
{
    public interface IQuestionServices
    {
        Task<string> AddQuestion(QuestionModel question);
        Task<List<QuestionModel>?> DeleteQuestion(int id);
        Task<List<QuestionModel>> GetAllQuestion();

        Task<QuestionModel?> GetSingleQuestion(int id);
        Task<List<QuestionModel>?> UpdateQuestion(int id, QuestionModel request);


        Task<List<QuestionModel>> GetRandomQuestion(int numberOfQuestions);
       Task<List<ChoiceModel>> GetChoicesForQuestionAsync(int questionId);
    }
}