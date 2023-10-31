using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class OptionsModel
    {
        [Key]
        public int OptionId { get; set; }
        public QuestionModel QuestionModel { get; set; }
        public string Option { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
