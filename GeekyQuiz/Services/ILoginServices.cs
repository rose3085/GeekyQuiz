using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<UserManager> RegisterUserAsync(RegisterDto model);
        UserDetail LoginUser(string email, string password);
    }
}
