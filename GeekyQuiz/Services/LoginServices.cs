namespace GeekyQuiz.Services.LoginServices
{
    public class LoginServices : ILoginServices
    {
        public static List<LoginModel> participant = new List<LoginModel>
        {
            new LoginModel
            {
                Id = 1,
                UserName= "Rabina",
                Email = "rabina@gmail.com",
                PhoneNumber = 98009383827,
                Password="fdhddbvbhd"
            },
            new LoginModel
            {
                Id = 1,
                UserName= "Rose",
                Email = "rose@gmail.com",
                PhoneNumber = 9883938937,
                Password="fssdddcsev"
            }
};
        public List<LoginModel> AddUser(LoginModel user)
        {
            participant.Add(user);
            return participant;
        }

        public List<LoginModel> DeleteUser(int id)
        {
            var user = participant.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            participant.Remove(user);
            return participant;
        }
           

        public List<LoginModel> GetAllUser()
        {
            return participant;
        }

        public LoginModel GetSingleUser(int id)
        {
            var user = participant.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public List<LoginModel> UpdateUser(int id, LoginModel request)
        {
            var user = participant.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Password = request.Password;
            return participant;
        }
    }
}
