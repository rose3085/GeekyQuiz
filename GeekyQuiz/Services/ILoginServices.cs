namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<List<LoginModel>> Register(UserRegisterModel request);
        Task<List<LoginModel>> GetAllUser();
        Task<LoginModel?> GetSingleUser(int id);
       Task<List<LoginModel>?> Login(UserRegisterModel request);
        Task<List<LoginModel>?> UpdateUser(int id, LoginModel request);
        Task<List<LoginModel>?> DeleteUser(int id);
        
    }
}
