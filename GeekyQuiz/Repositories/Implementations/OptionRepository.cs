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
        public string AddOptions(QuestionOption questionOption)
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
            _context.SaveChanges();
            return "Queston and options added ";
        }
        public string EditOptions(int id, Option option)
        {
            var existingOption = _context.Options.FirstOrDefault(x=>x.OptionId == id);
            if (existingOption == null)
            {
                return "Optionid not found";
            }
            existingOption.OptionA = option.OptionA;
            existingOption.OptionB = option.OptionB;
            existingOption.OptionC = option.OptionC;
            existingOption.OptionD = option.OptionD;
            existingOption.CorrectOption = option.CorrectOption;
            _context.SaveChanges();
            return "Edited successfully.";
        }
        public Option GetById(int id)
        {
            var options = _context.Options.FirstOrDefault(x=>x.OptionId == id);
            return options;
        }
    }
}
