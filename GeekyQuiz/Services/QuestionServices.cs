namespace GeekyQuiz.Services.QuestionServices
{
    public class QuestionServices : IQuestionServices
    {
        public static List<QuestionModel> questions = new List<QuestionModel>
        {
            new QuestionModel
            {
                QuestionId=1,
                Question = "What does IP stands for?"
            },
            new QuestionModel 
            {
                QuestionId = 2,
                Question = "Which one of the following is not Http Protocol?"
            }
        };
        public List<QuestionModel> AddQuestion(QuestionModel question)
        {
            questions.Add(question);
            return questions;
        }

        public List<QuestionModel> DeleteQuestion(int id)
        {
            var result = questions.Find(x => x.QuestionId == id);
            if (result is null)
            {
                return null;
            }
            questions.Remove(result);
            return questions;
        }

        public List<QuestionModel> GetAllQuestion()
        {
            return questions;
        }

        public QuestionModel GetSingleQuestin(int id)
        {
            var result = questions.Find(x => x.QuestionId == id);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public List<QuestionModel> UpdateQuestion(int id, QuestionModel request)
        {
            var result = questions.Find(x => x.QuestionId == id);
            if (result is null)
            {
                return null;
            }
            result.Question = request.Question;
            return questions;
        }
    }
}
