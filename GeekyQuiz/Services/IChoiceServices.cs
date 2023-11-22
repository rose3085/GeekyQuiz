using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Services.ChoiceServices
{
    public interface IChoiceServices
    {
          Task<List<ChoiceModel>> GetAllChoice();

       // Task<List<ChoiceModel>> GetChoicesForQuestion(int QuestionId);
        Task<ChoiceModel?> GetSingleChoice(int id);
        Task<List<ChoiceModel>> AddChoice(QuestionOption questionOption);
        Task<List<ChoiceModel>?> UpdateChoice(int id, ChoiceModel request);
        Task<List<ChoiceModel>?> DeleteChoice(int id);
       // Task<ActionResult<List<ChoiceModel>>> GetAllChoice();
       // Task<List<ChoiceModel>> GetOptionsForQuestionAsync(int questionId);
    }
}