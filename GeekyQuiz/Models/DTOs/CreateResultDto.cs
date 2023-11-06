namespace GeekyQuiz.Models.DTOs
{
    public class CreateResultDto
    {
        public int Score { get; set; }

        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
