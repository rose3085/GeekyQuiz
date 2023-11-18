using GeekyQuiz.Models.DTOs;

namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IOptionRepository
    {
        string AddOptions(QuestionOption questionOption);
        string EditOptions(int id, Option option);
        Option GetById(int id);
    }
}
