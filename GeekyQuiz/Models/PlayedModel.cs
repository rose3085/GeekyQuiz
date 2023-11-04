using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class PlayedModel
    {
        [Key]
        public int PlayId { get; set; }

        public LoginModel UserId { get; set; }

        public DateTime Time { get; set; }
    }
}
