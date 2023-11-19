using GeekyQuiz.DTO;

namespace GeekyQuiz.Services.ChoiceServices
{
    public class OptionServices : IOptionServices
    {
       
        private readonly DataContext _context;
        public OptionServices(DataContext context)
        {
            _context = context;
        }
        public string AddOptions(QuestionOption questionOption)
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
            _context.Options.Add(option);
            _context.SaveChanges();
            return "Question and options added ";
        }
       

        public async Task<List<OptionModel>> GetAllOption()
        {
            var users = await _context.Options.ToListAsync();
            return users;
        }
        public async Task<OptionModel>? GetSingleOption(int id)
        {
            var user = await _context.Options.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public string UpdateOption(int id, OptionModel option)
        {
            var existingOption = _context.Options.FirstOrDefault(x => x.OptionId == id);
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

    }
}
