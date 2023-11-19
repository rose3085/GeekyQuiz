namespace GeekyQuiz.DTO
{
    public class CreateResultDto
    {
        public int Score { get; set; }
        public int Users { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
