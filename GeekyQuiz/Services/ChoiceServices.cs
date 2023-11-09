namespace GeekyQuiz.Services.ChoiceServices
{
    public class ChoiceServices : IChoiceServices
    {
        public static List<ChoiceModel> choice = new List<ChoiceModel>
        {
            new ChoiceModel
            {
                ChoiceId = 1,
                QuestionId = 2,
                IsCorrect = true,   
            }
        };
        private readonly DataContext _context;
        public ChoiceServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ChoiceModel>> AddChoice(ChoiceModel user)
        {
            _context.Choices.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Choices.ToListAsync();
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

        public async Task<List<ChoiceModel>?> UpdateChoice(int id, ChoiceModel request)
        {
            var user = await _context.Choices.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            user.QuestionId = request.QuestionId;
            //user.ChoiceA = request.ChoiceA;
            //user.ChoiceB = request.ChoiceB;
            //user.ChoiceC = request.ChoiceC;
            //user.ChoiceD = request.ChoiceD;
            //user.IsCorrect = request.IsCorrect;

            await _context.SaveChangesAsync();
            return await _context.Choices.ToListAsync();
        }
    }
}
