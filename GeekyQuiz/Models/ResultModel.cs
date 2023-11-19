using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeekyQuiz.Models
{
    public class ResultModel
    {
        [Key]
        public int ResultId { get; set; }
        [ForeignKey("UserId")]
        public UserDetail Users { get; set; }
        public int Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
