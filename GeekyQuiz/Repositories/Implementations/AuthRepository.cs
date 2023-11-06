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
        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
        public User GetByUserNameOrEmail(string usernameOrEmail)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == usernameOrEmail || x.Email == usernameOrEmail);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public string CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return "New user added.";
        }
        public string DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return "User not found.";
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return "User deleted successfully.";
        }
        public string EditUserName(string userName, string newUserName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return "User not found";
            }
            user.UserName = newUserName;
            _context.SaveChanges();
            return "Username changed.";
        }
    }
}
