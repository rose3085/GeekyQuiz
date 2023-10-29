using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class QuestionModel
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Question { get; set; } = string.Empty;
        
        
    }
}
