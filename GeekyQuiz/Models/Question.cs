using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
    }
}
