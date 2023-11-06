namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IOptionRepository
    {
        string AddOptions(Option option);
        string EditOptions(int id, Option option);
        Option GetById(int id);
    }
}
