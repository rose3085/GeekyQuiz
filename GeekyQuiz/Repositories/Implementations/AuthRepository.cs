using GeekyQuiz.Repositories.Interfaces;

namespace GeekyQuiz.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetByUserNameOrEmail(string usernameOrEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == usernameOrEmail || x.Email == usernameOrEmail);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<string> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "New user added.";
        }
        public async Task<string> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return "User not found.";
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User deleted successfully.";
        }
        public async Task<string> EditUserName(string userName, string newUserName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                return "User not found";
            }
            user.UserName = newUserName;
            await _context.SaveChangesAsync();
            return "Username changed.";
        }
    }
}
