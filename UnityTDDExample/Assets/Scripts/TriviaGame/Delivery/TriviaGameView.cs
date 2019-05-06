using System.Linq;
using TMPro;
using TriviaGame.Domain;
using TriviaGame.Presentation;
using UnityEngine;

namespace TriviaGame.Delivery
{
    public class TriviaGameView : MonoBehaviour
    {
        private TriviaGamePresenter _presenter;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private AnswerView[] _answers;
        [SerializeField] private Animator _feedbackAnimations;
        
        private void Start()
        {
            _presenter = TriviaGamePresenterBuilder.BuildTriviaGamePresenter(this);

            foreach (var answerView in _answers)
            {
                answerView.Initialize(OnAnswerSelected);
            }
        }

        public virtual void ShowNextQuestion(Question question)
        {
            _questionText.text = question.QuestionText;

            var allAnswers = question.WrongAnswers.Concat(new string[]{question.RightAnswer}).ToList();
            allAnswers.Sort((a, b) => Random.Range(0, 2) > 0 ? 1 : -1);

            for (var i = 0; i < _answers.Length; i++)
            {
                _answers[i].FillData(allAnswers[i]);
            }
        }
        
        public virtual void ShowPositiveFeedback()
        {
            _feedbackAnimations.Play("RightAnswer");
        }

        public virtual void ShowWinFeedback()
        {
            _feedbackAnimations.Play("Win");            
        }

        public virtual void ShowLoseFeedback()
        {
            _feedbackAnimations.Play("Lose");
        }
        
        public virtual void UpdateScore(int currentScore)
        {
            _scoreText.text = currentScore.ToString("000");
        }

        private void OnAnswerSelected(string selectedAnswer)
        {
            _presenter.ReceiveAnswer(selectedAnswer);
        }

    }
}