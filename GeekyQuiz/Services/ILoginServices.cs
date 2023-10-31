namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        List<LoginModel> GetAllUser();
        LoginModel GetSingleUser(int Userid);
        List<LoginModel> AddUser(LoginModel user);
        List<LoginModel> UpdateUser(int Userid, LoginModel request);
        List<LoginModel> DeleteUser(int Userid);
    }
}
