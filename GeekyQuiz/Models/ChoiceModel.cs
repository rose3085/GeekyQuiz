using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ChoiceModel
    {
        [Key]
        public int ChoiceId { get; set; }
        public QuestionModel QuestionId { get; set; }
        public string optionA { get; set; } = string.Empty;
        public string optionB { get; set; } = string.Empty;
        public string optionC { get; set; } = string.Empty;
        public string optionD { get; set; } = string.Empty;
        public char CorrectOption { get; set; }

        

    }
}