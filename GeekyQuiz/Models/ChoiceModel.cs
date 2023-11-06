using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ChoiceModel
    {
        [Key]
        public int ChoiceId { get; set; }
        public QuestionModel? QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public static implicit operator ChoiceModel(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
