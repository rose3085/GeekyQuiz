using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ChoiceModel
    {
        [Key]
        public int ChoiceId { get; set; }
        public QuestionModel? QuestionId { get; set; }
        public string ChoiceA { get; set; } = string.Empty;
        public string ChoiceB { get; set; } = string.Empty;
        public string ChoiceC { get; set;} = string.Empty;
        public string ChoiceD { get; set;} = string.Empty;
        public bool IsCorrect { get; set; }

        public static implicit operator ChoiceModel(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
