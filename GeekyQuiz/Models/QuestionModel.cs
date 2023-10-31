using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }
        
        public string Question { get; set; } = string.Empty;

        public static implicit operator QuestionModel(int v)
        {
            throw new NotImplementedException();
        }
    }
}
