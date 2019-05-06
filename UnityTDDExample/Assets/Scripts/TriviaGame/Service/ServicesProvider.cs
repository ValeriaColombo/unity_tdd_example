namespace TriviaGame.Service
{
    public class ServicesProvider
    {
        private static QuestionsService _questionsService = new QuestionsService();

        public static QuestionsService QuestionsService()
        {
            return _questionsService;
        }
    }
}