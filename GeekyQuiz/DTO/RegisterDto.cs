using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.DTO
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email{ get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword {  get; set; } = string.Empty;
    }
}
