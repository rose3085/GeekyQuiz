using GeekyQuiz.Models.DTOs;
using GeekyQuiz.Repositories.Interfaces;
using System.Text;

namespace GeekyQuiz.Repositories.Implementations
{
    public class OptionRepository : IOptionRepository
    {
        private readonly DataContext _context;
        public OptionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddOptions(QuestionOption questionOption)
        {
            var option = new Option
            {
                OptionA = questionOption.OptionA,
                OptionB = questionOption.OptionB,
                OptionC = questionOption.OptionC,
                OptionD = questionOption.OptionD,
                CorrectOption = questionOption.CorrectOption,
                Question = new Question
                {
                    QuestionText = questionOption.QuestionText,
                }

            };
            _context.Options.Add(option);
            await _context.SaveChangesAsync();
            return "Queston and options added ";
        }
        public async Task<string> EditOptions(int id, Option option)
        {
            var existingOption = await _context.Options.FirstOrDefaultAsync(x=>x.OptionId == id);
            if (existingOption == null)
            {
                return "Optionid not found";
            }
            existingOption.OptionA = option.OptionA;
            existingOption.OptionB = option.OptionB;
            existingOption.OptionC = option.OptionC;
            existingOption.OptionD = option.OptionD;
            existingOption.CorrectOption = option.CorrectOption;
            await _context.SaveChangesAsync();
            return "Edited successfully.";
        }
        public async Task<Option> GetById(int id)
        {
            var options = await _context.Options.FirstOrDefaultAsync(x=>x.OptionId == id);
            return options;
        }
    }
}
