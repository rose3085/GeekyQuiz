﻿using GeekyQuiz.DTO;
using OpenAI_API.Moderation;

namespace GeekyQuiz.Services.ResultServices
{
    public interface IResultServices 
    {
        Task<List<ResultModel>> GetResult();
        Task<string> AddResult(int userId, CreateResultDto result);
        Task<List<ResultModel>> GetByUserName(string userName);
    }
}
