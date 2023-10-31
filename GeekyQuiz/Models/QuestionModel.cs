using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class QuestionModel
    {
        
        public int QuestionId { get; set; }
        
        public string Question { get; set; } = string.Empty;
        
        
    }
}
