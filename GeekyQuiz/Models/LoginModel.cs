using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class LoginModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
