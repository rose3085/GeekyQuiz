namespace GeekyQuiz.Services.LoginServices
{
    public class LoginServices : ILoginServices
    {
        public static List<LoginModel> participant = new List<LoginModel>
        {
            new LoginModel
            {
                UserId = 1,
                UserName= "Rabina",
                Email = "rabina@gmail.com",
                PhoneNumber = 98009383827,
                Password="fdhddbvbhd"
            },
            new LoginModel
            {
                UserId = 1,
                UserName= "Rose",
                Email = "rose@gmail.com",
                PhoneNumber = 9883938937,
                Password="fssdddcsev"
            }
};
        private readonly DataContext _context;
        public LoginServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<LoginModel>> AddUser(LoginModel user)
        {
           _context.Logins.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Logins.ToListAsync();
        }

        public async Task<List<LoginModel>?> DeleteUser(int id)
        {
            var users = await _context.Logins.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _context.Logins.Remove(users);
            await _context.SaveChangesAsync();
            return await _context.Logins.ToListAsync() ;
        }
           

        public async Task<List<LoginModel>> GetAllUser()
        {
            var users = await _context.Logins.ToListAsync();
            return users;
        }

        public async Task<LoginModel?> GetSingleUser(int id)
        {
            var user = await _context.Logins.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<LoginModel>?> UpdateUser(int id, LoginModel request)
        {
            var user = await _context.Logins.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Password = request.Password;

            await _context.SaveChangesAsync();
            return await _context.Logins.ToListAsync();
        }
    }
}
