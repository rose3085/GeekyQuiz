﻿using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.DTO
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; }    = string.Empty;
    }
}
