using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekyQuiz.Models
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }

        public string Question { get; set; } = string.Empty;

        public List<ChoiceModel> Choices { get; set; }
    }
}