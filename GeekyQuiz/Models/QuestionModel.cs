using System.ComponentModel.DataAnnotations;
namespace GeekyQuiz.Models
{
    public class QuestionModel
    {
        internal object shuffledChoices;

        [Key]
        public int QuestionId { get; set; }
        
        public string Question { get; set; } = string.Empty;

       public List<ChoiceModel> Choice { get; set; }

        public static implicit operator QuestionModel(int v)
        {
            throw new NotImplementedException();
        }
    }
}
