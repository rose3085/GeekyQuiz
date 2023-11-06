using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public char CorrectOption { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
