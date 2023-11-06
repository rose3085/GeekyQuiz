﻿using AutoMapper;
using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;

        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _loginServices.RegisterUserAsync(model).Result;

                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _loginServices.LoginUserAsync(model);
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
