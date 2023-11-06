using Azure.Identity;
using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GeekyQuiz.Services.LoginServices
{
    public class LoginServices : ILoginServices
    {
        private readonly DataContext _context;
        public LoginServices(DataContext context)
        {
            _context = context;
        }

        public async Task<UserManager> LoginUserAsync(LoginDto model)
        {
            var user = new LoginDto()
            {
                Email = model.Email,
                Password = model.Password,
            };
            if (CheckUserData(model.Email, model.Password) is false)
            {
                return new UserManager()
                {
                    IsSuccess = false,
                    Message = "Please register the user"
                };
            }
            return new UserManager()
            { IsSuccess = true };
        }

        public async Task<UserManager> RegisterUserAsync(RegisterDto model)
        {
            var user = new RegisterDto()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
            };
            if (CheckUserData(model.Email, model.Password) == true)

                return new UserManager()
                {
                    IsSuccess = false,
                    Message = "User already exist"
                };

            if (model.Password != model.ConfirmPassword)
                return new UserManager()
                {
                    IsSuccess = false,
                    Message = "Password did not match.",
                };

            return new UserManager()
            {
                IsSuccess = true,
                Message = "User created"

            };

        }
        private bool CheckUserData(string Email, string Password)
        {
            var result = _context.Users.Where(x => x.Email == Email && x.Password == Password);
            if (result is null)
            {
                return false;
            }
            return true;
        }

    } 
}
