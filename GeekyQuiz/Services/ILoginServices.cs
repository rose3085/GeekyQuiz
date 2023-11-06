using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<UserManager> RegisterUserAsync(RegisterDto model);
        Task<UserManager> LoginUserAsync(LoginDto model);
    }
}
