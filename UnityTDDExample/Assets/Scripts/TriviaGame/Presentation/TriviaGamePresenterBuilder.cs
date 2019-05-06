using TriviaGame.Delivery;
using TriviaGame.Service;

namespace TriviaGame.Presentation
{
    public class TriviaGamePresenterBuilder
    {
        public static TriviaGamePresenter BuildTriviaGamePresenter(TriviaGameView view)
        {
            return new TriviaGamePresenter(view, ServicesProvider.QuestionsService().GetQuestions(3));
        }
    }
}