using GeekyQuiz.Models.DTOs;

namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IOptionRepository
    {
        Task<string> AddOptions(QuestionOption questionOption);
        Task<string> EditOptions(int id, Option option);
        Task<Option> GetById(int id);
    }
}
