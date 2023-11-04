using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekyQuiz.Services;
using GeekyQuiz.Services.LoginServices;

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
        [HttpPost("register")]
        public async Task<ActionResult<List<LoginModel>>?> Register(UserRegisterModel request)
        { 
            var result = await _loginServices.Register(request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<LoginModel>>> GetAllUser()
        {
            return await _loginServices.GetAllUser();
           // return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> GetSingleUser(int id)
        {
            var result = await _loginServices.GetSingleUser(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> UpdateUser(int id, LoginModel request)
        {
            var result = await _loginServices.UpdateUser(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> DeleteUser(int id)
        {
            var result =await _loginServices.DeleteUser(id);
            if (result is null) 
            {
                return null;
            }
            return Ok(result);
        }
    }
}
