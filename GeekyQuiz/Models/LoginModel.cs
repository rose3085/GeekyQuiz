namespace GeekyQuiz.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
