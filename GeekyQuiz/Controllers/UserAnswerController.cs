﻿using GeekyQuiz.Services.UserAnswerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerServices _userAnswerServices;
        public UserAnswerController(IUserAnswerServices userAnswerServices)
        {
            _userAnswerServices = userAnswerServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserAnswerModel>>> GetAllAnswer()
        {
            return await _userAnswerServices.GetAllAnswer();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserAnswerModel>>?> GetSingleAnswer(int id)
        {
            var result = await _userAnswerServices.GetSingleAnswer(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<List<UserAnswerModel>>> AddUser(UserAnswerModel userAnswer)
        {
            var result = await _userAnswerServices.AddAnswer(userAnswer);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> UpdateAnswer(int id, UserAnswerModel request)
        {
            var result = await _userAnswerServices.UpdateAnswer(id, request);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LoginModel>>?> DeleteAnswer(int id)
        {
            var result = await _userAnswerServices.DeleteAnswer(id);
            if (result is null)
            {
                return null;
            }
            return Ok(result);
        }
    }
}