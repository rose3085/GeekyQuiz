
using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeekyQuiz.Services.QuestionServices
{
    public class QuestionServices : IQuestionServices
    {
        private readonly DataContext _context;
        public QuestionServices(DataContext context)
        {
            _context = context;
        }

        
        public async Task<List<QuestionModel>?> DeleteQuestion(int id)
        {
            var results = await _context.Questions.FindAsync(id);
            if (results is null)
            {
                return null;
            }
            _context.Questions.Remove(results);
            await _context.SaveChangesAsync();
            return await _context.Questions.ToListAsync();
        }

        public async Task<List<QuestionModel>> GetAllQuestion()
        {
            return await _context.Questions.ToListAsync();
        }



        //public Task<List<ChoiceModel>> GetChoicesForQuestionAsync(int questionId)
        //{
        //    return _context.Choices.Any(o => o.QuestionId == questionId).ToList();
        //}

        //public Task<List<ChoiceModel>> GetChoicesForQuestionAsync(int questionId)
        //{
        //    var options = _context.Choices
        //       .Where(o => o.QuestionId == questionId)
        //       .ToList();

        //        return options;
        //}
        public async Task<string> AddQuestion(QuestionModel question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return "New question added successfully";
        }

        public async Task<QuestionModel?> GetSingleQuestion(int id)
        {
            var result = await _context.Questions.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<string> UpdateQuestion(int id, QuestionModel request)
        {
            var result = await _context.Questions.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            result.Question = request.Question;
            await _context.SaveChangesAsync();
            return "Question updated successfully";
        }

       

    }
}