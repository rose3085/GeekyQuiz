using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; } 

        public string? PhoneNumber { get; set; }
        public string? Password { get; internal set; }

        

    }
}
