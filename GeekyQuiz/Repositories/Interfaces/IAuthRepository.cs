namespace GeekyQuiz.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        List<User> GetAllUsers();
        User GetByUserNameOrEmail(string usernameOrEmail);
        string CreateUser(User user);
        string EditUserName(string userName, string newUserName);
        string DeleteUser(int id);
        

    }
}
