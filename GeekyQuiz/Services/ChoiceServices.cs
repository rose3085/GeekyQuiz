using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GeekyQuiz.Services.ChoiceServices
{
    public class ChoiceServices : IChoiceServices
    {
        private readonly DataContext _context;
        public ChoiceServices(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddChoice(QuestionOption questionOption)
        {
            var option = new ChoiceModel
            {
                OptionA = questionOption.OptionA,
                OptionB = questionOption.OptionB,
                OptionC = questionOption.OptionC,
                OptionD = questionOption.OptionD,
                CorrectOption = questionOption.CorrectOption,
                QuestionId = new QuestionModel
                {
                    Question = questionOption.Question,
                }

            };
             await _context.AddAsync(option);
            await _context.SaveChangesAsync();
            return "new question added successfully ";
        }

      
        public async Task<List<ChoiceModel>?> DeleteChoice(int id)
        {
            var users = await _context.Choices.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _context.Choices.Remove(users);
            await _context.SaveChangesAsync();
            return await _context.Choices.ToListAsync();
        }

        public async Task<List<ChoiceModel>> GetAllChoice()
        {
            var users = await _context.Choices.ToListAsync();
            return users;
        }



        public async Task<ChoiceModel?> GetSingleChoice(int id)
        {
            var user = await _context.Choices.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public Task<List<ChoiceModel>?> UpdateChoice(int id, ChoiceModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateOption(int id, ChoiceModel option)
        {
            var existingOption = _context.Choices.FirstOrDefault(x => x.ChoiceId == id);
            if (existingOption == null)
            {
                return null;
            }
            existingOption.OptionA = option.OptionA;
            existingOption.OptionB = option.OptionB;
            existingOption.OptionC = option.OptionC;
            existingOption.OptionD = option.OptionD;
            existingOption.CorrectOption = option.CorrectOption;
            await _context.SaveChangesAsync();
            return "Updated sucessfully";
        }

        Task<string> IChoiceServices.AddChoice(QuestionOption questionOption)
        {
            throw new NotImplementedException();
        }


        //Task<ActionResult<List<ChoiceModel>>> IChoiceServices.GetAllChoice()
        //{
        //    throw new NotImplementedException();
        //}
    }
}