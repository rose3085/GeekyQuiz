namespace GeekyQuiz.DTO
{
    public class UserDetailsDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; internal set; }
    }
}
