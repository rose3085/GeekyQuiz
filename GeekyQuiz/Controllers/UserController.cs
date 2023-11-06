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
        public IActionResult GetUsers() { 
            var users = _authRepository.GetAllUsers();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet]
        [Route("GetByUserNameOrEmail")]
        public IActionResult GetByUserNameOrEmail(string usernameOrEmail) {
            var user = _authRepository.GetByUserNameOrEmail(usernameOrEmail);
            if(user == null)
            {
                return NotFound(usernameOrEmail + " not found.");
            }
            return Ok(user);
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            var existingUser = _authRepository.GetByUserNameOrEmail(user.UserName);
            if(existingUser == null)
            {
                var res = _authRepository.CreateUser(user);
                return Ok(res);
            }
            return Conflict("User already exists");
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var res = _authRepository.DeleteUser(id);
            return Ok(res);

        }
        [HttpPut]
        [Route("EditUserName")]
        public IActionResult EditUserName(string userName, string newUserName)
        {
            var res = _authRepository.EditUserName(userName, newUserName);
            return Ok(res);
        }
    }
}
