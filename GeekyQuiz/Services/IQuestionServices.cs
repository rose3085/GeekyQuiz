namespace GeekyQuiz.Services.QuestionServices
{
    public interface IQuestionServices
    {
        List<QuestionModel> AddQuestion(QuestionModel question);
        List<QuestionModel> DeleteQuestion(int id);
        List<QuestionModel> GetAllQuestion();
        QuestionModel GetSingleQuestin(int id);
        List<QuestionModel> UpdateQuestion(int id, QuestionModel request);
    }
}