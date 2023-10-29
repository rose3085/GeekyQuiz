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
        private readonly ILoginServices loginServices;
        public LoginController(ILoginServices loginServices)
        {
            this.loginServices = loginServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<LoginModel>>> GetAllUser()
        {
            var result = this.loginServices.GetAllUser();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LoginModel>>> GetSingleUser(int id)
        {
            var result = this.loginServices.GetSingleUser(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<LoginModel>>> AddUser(LoginModel user)
        {
            var result = this.loginServices.AddUser(user);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<LoginModel>>> UpdateUser(int id, LoginModel request)
        {
            var result = this.loginServices.UpdateUser(id, request);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LoginModel>>> DeleteUser(int id)
        {
            var result = this.loginServices.DeleteUser(id);
            return Ok(result);
        }
    }
}
