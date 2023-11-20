using GeekyQuiz.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAuthRepository _authRepository;
        public UserController(IAuthRepository authRepo) 
        {
            _authRepository = authRepo;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetUsers() { 
            var users = await _authRepository.GetAllUsers();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet]
        [Route("GetByUserNameOrEmail")]
        public async Task<IActionResult> GetByUserNameOrEmail(string usernameOrEmail) {
            var user = await _authRepository.GetByUserNameOrEmail(usernameOrEmail);
            if(user == null)
            {
                return NotFound(usernameOrEmail + " not found.");
            }
            return Ok(user);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var existingUser = await _authRepository.GetByUserNameOrEmail(user.UserName);
            if(existingUser == null)
            {
                var res = _authRepository.CreateUser(user);
                return Ok(res);
            }
            return Conflict("User already exists");
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _authRepository.DeleteUser(id);
            return Ok(res);

        }
        [HttpPut]
        [Route("EditUserName")]
        public async Task<IActionResult> EditUserName(string userName, string newUserName)
        {
            var res = await _authRepository.EditUserName(userName, newUserName);
            return Ok(res);
        }
    }
}
