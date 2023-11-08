using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekyQuiz.Services;
using GeekyQuiz.Services.LoginServices;
using GeekyQuiz.DTO;
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

        //[HttpGet]
        //public async Task<ActionResult<List<LoginModel>>> GetAllUser()
        //{
        //    return await _loginServices.GetAllUser();
        //    // return Ok(result);
        //} [HttpGet("{id}")]
        //public async Task<ActionResult<List<LoginModel>>?> GetSingleUser(int id)
        //{
        //    var result = await _loginServices.GetSingleUser(id);
        //    if (result is null)
        //    {
        //        return null;
        //    }
        //    return Ok(result);
        //}
        //[HttpPost]
        //public async Task<ActionResult<List<LoginModel>>> AddUser(LoginDto user)
        //{
        //    var result = await _loginServices.AddUser(user);
        //    return Ok(result);
        //}


        //[HttpPut("{id}")]
        //public async Task<ActionResult<List<LoginModel>>?> UpdateUser(int id, LoginModel request)
        //{
        //    var result = await _loginServices.UpdateUser(id, request);
        //    if (result is null)
        //    {
        //        return null;
        //    }
        //    return Ok(result);
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<LoginModel>>?> DeleteUser(int id)
        //{
        //    var result = await _loginServices.DeleteUser(id);
        //    if (result is null)
        //    {
        //        return null;
        //    }
        //    return Ok(result);
        //}

        //[HttpPost("Register")]
        //public IActionResult Register(RegisterDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _loginServices.RegisterUserAsync(model).Result;

        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
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