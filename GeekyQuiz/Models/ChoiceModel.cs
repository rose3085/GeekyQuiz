using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ChoiceModel
    {
        [Key]
        public int ChoiceId { get; set; }
        public QuestionModel QuestionId { get; set; }
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public char CorrectOption { get; set; }

        

    }
}