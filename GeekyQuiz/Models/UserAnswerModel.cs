using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class UserAnswerModel
    {
        [Key]
        public int AnswerId{ get; set; }
        [Required]
        public int PlayId { get; set; }
        public QuestionModel QuestionId { get; set; }
        public string UserAnswer { get; set; } = string.Empty;
        public ChoiceModel IsCorrect { get; set; }
    }
}
