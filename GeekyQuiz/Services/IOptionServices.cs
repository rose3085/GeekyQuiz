using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.ChoiceServices
{
    public interface IOptionServices
    {
        Task<List<OptionModel>> GetAllOption();
        Task<OptionModel>? GetSingleOption(int id);
        string AddOptions(QuestionOption questionOption);
        string UpdateOption(int id, OptionModel option);
    }
}
