using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekyQuiz.Models
{
    public class UserAnswerModel
    {
        [Key]
        public int AnswerId { get; set; }
        
        public QuestionModel QuestionModel { get; set; }
        public OptionModel OptionModel { get; set; }
        public string UserAnswer { get; set; } = string.Empty;
        
    }
}
