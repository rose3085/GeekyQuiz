using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekyQuiz.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
