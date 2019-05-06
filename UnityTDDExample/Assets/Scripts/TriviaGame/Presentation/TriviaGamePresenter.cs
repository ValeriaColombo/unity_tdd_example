using TriviaGame.Delivery;
using TriviaGame.Domain;

namespace TriviaGame.Presentation
{
    public class TriviaGamePresenter
    {
        private TriviaGameView _view;
        private Question[] _questions;        
        private int _currentQuestion;
        
        public int Score { get; private set; }

        public TriviaGamePresenter(TriviaGameView view, Question[] questions)
        {
            _view = view;
            _questions = questions;

            Score = 0;
            _currentQuestion = 0;
            
            _view.ShowNextQuestion(_questions[_currentQuestion]);

        }

        public void ReceiveAnswer(string anAnswer)
        {
            if (_questions[_currentQuestion].IsRightAnswer(anAnswer))
            {
                OnRightAnswerReceived();
            }
            else
            {
                OnWrongAnswerReceived();
            }
        }

        private void OnWrongAnswerReceived()
        {
            _view.ShowLoseFeedback();
        }

        private void OnRightAnswerReceived()
        {
            Score++;
            _currentQuestion++;

            _view.UpdateScore(Score);
            
            if (Score == 3)
            {
                _view.ShowWinFeedback();
            }
            else
            {
                _view.ShowPositiveFeedback();
                _view.ShowNextQuestion(_questions[_currentQuestion]);
            }
        }
    }
}