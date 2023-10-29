namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        List<LoginModel> GetAllUser();
        LoginModel GetSingleUser(int id);
        List<LoginModel> AddUser(LoginModel user);
        List<LoginModel> UpdateUser(int id, LoginModel request);
        List<LoginModel> DeleteUser(int id);
    }
}
