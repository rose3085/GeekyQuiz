
using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class UserRegisterModel
    {


         [Key]
         public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
