using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class LoginModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; } 

        public long PhoneNumber { get; set; }
        [Required, MinLength(6)]
        public string? Password { get; set; }
        

       
    }
}
