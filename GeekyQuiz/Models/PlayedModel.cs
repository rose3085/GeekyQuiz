using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class PlayedModel
    {
        [Key]
        public int PlayId { get; set; }

        public LoginModel LoginModel { get; set; }

        public DateTime Time { get; set; }
    }
}
