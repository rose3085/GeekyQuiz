using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekyQuiz.Models
{
    public class UserAnswerModel
    {
        [Key]
        public int AnswerId { get; set; }
        [ForeignKey("QuestionId")]
        public QuestionModel? QuestionId { get; set; }
        public OptionModel OptionId { get; set; }
        public string UserAnswer { get; set; } = string.Empty;
        
    }
}
