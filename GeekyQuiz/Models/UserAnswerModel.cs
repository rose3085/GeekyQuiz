using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class UserAnswerModel
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        public PlayedModel PlayId { get; set; }
        public QuestionModel QuestionId { get; set; }
        public string UserAnswer { get; set; } = string.Empty;
       // public ChoiceModel ChoiceId { get; set; }
        public bool IsCorrect { get; set; }
    }
}