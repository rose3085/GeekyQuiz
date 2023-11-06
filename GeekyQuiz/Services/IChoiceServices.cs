using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.ChoiceServices
{
    public interface IChoiceServices
    {
        Task<List<ChoiceModel>> GetAllChoice();
        Task<ChoiceModel?> GetSingleChoice(int id);
        Task<List<ChoiceModel>> AddChoice(ChoiceModel user);
        Task<List<ChoiceModel>?> UpdateChoice(int id,ChoiceModel request);
        Task<List<ChoiceModel>?> DeleteChoice(int id);
        //Task<ChoiceManager> GetChoices(QuestionDto model)
    }
}
