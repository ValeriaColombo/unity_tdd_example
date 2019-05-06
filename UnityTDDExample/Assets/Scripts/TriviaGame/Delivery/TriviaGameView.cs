using TriviaGame.Domain;

namespace TriviaGame.Delivery
{
    public class TriviaGameView
    {        
        public virtual void ShowNextQuestion(Question question)
        {
        }
        
        public virtual void ShowPositiveFeedback()
        {
        }

        public virtual void ShowWinFeedback()
        {
        }

        public virtual void ShowLoseFeedback()
        {
        }
        
        public virtual void UpdateScore(int currentScore)
        {
        }
    }
}