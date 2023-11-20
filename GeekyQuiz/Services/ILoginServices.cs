﻿using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.LoginServices
{
    public interface ILoginServices
    {
        //Task<List<LoginModel>> GetAllUser();
        //Task<List<LoginModel>> GetSingleUser(int id);
        //Task<List<LoginModel>> AddUser(LoginModel user);
        //Task<List<LoginModel>> UpdateUser(int id, LoginModel request);
        //Task<List<LoginModel>> DeleteUser(int id);
        //object LoginUserAsync(LoginDto model);
        //object RegisterUserAsync(RegisterDto model);

        Task<UserManager> RegisterUserAsync(RegisterDto model);
        LoginModel LoginUser(string email, string password);
    }
}