using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class OptionModel
    {
        [Key]
        public int OptionId { get; set; }
        public QuestionModel QuestionModel { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public char CorrectOption { get; set; }

       
    }
}
