using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.ChoiceServices
{
    public interface IOptionServices
    {
        Task<List<OptionModel>> GetAllOption();
        Task<OptionModel>? GetSingleQuestionOption(int id);
        Task<List<OptionModel>> AddOptions(QuestionOption questionOption);
        Task<List<OptionModel>> UpdateOption(int id, OptionModel option);
    }
}
