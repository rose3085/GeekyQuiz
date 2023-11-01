using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ResultModel
    {
        [Key]
        public int ScoreId { get; set; }

        public PlayedModel PlayedModel { get; set; }

        public int Score { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
