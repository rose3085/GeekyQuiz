namespace GeekyQuiz.DTO
{
    public class UserManager
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }

        internal object? Select(Func<object, LoginDto> value)
        {
            throw new NotImplementedException();
        }
    }
}
