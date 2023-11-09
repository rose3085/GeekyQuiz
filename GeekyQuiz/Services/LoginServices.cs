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

        public UserDetail LoginUser(string email, string password)
        {
            
            if (CheckUserData(email, password) is false)
            {
                return null;
            }
            var user = _context.User.FirstOrDefault(x => x.Email ==email);
            return user;

            
        }

        public async Task<UserManager> RegisterUserAsync(RegisterDto model)
        {
            var user = new UserDetail()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
            };
            if (CheckUserData(model.Email, model.Password) == true)
            {
                return new UserManager()
                { 
                    IsSuccess = false,
                    Message = "User already exist"
                };
                    }

            if (model.Password != model.ConfirmPassword)
            { 
                return new UserManager()
                    { 
                        IsSuccess = false,
                        Message = "Password didn't match"
                    };
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new UserManager()
            {
                Message = "User registered successfully.",
                IsSuccess = true,
            };
           

        }
        private bool CheckUserData(string Email, string Password)
        {
            var result = _context.User.Any(x =>x.Email == Email && x.Password == Password);
            if (result == false)
            {
                return false;
            }
            return true;
        }

    } 
}
