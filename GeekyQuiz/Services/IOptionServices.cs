using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.ChoiceServices
{
    public interface IOptionServices
    {
        Task<List<OptionModel>> GetAllOption();
        Task<OptionModel>? GetSingleQuestionOption(int id);
        Task<string> AddOptions(QuestionOption questionOption);
        Task<string> UpdateOption(int id, OptionModel option);
    }
}
