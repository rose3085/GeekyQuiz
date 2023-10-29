using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class UserAnswerModel
    {
        [Key]
        public int AnswerId{ get; set; }
    }
}
