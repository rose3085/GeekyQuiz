using GeekyQuiz.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeekyQuiz.Services.ChoiceServices
{
    public class OptionServices : IOptionServices
    {
       // private const string v = "Option added succcessfully";
        private readonly DataContext _context;
        public OptionServices(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddOptions(QuestionOption questionOption)
        {
            var option = new OptionModel
            {
                OptionA = questionOption.OptionA,
                OptionB = questionOption.OptionB,
                OptionC = questionOption.OptionC,
                OptionD = questionOption.OptionD,
                CorrectOption = questionOption.CorrectOption,
                Question = new QuestionModel
                {
                    Question = questionOption.Question,
                }

            };
            await _context.AddAsync(option);
            await _context.SaveChangesAsync();
            return "Option added sucessfully";
        }

        public async Task<List<OptionModel>> GetAllOption()
        {
            var users = await _context.Options.ToListAsync();
            return users;
        }
        public async Task<OptionModel>? GetSingleQuestionOption(int id)
        {
            var user = await _context.Options.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<string> UpdateOption(int id, OptionModel option)
        {
            var existingOption = _context.Options.FirstOrDefault(x => x.OptionId == id);
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

    }
}
