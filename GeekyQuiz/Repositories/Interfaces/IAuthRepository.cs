namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetByUserNameOrEmail(string usernameOrEmail);
        Task<string> CreateUser(User user);
        Task<string> EditUserName(string userName, string newUserName);
        Task<string> DeleteUser(int id);
        

    }
}
