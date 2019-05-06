using NSubstitute;
using NUnit.Framework;
using TriviaGame.Delivery;
using TriviaGame.Domain;
using TriviaGame.Presentation;

namespace Test.TriviaGame
{
    [TestFixture]
    public class TriviaGamePresenterTests
    {
        private TriviaGameView _view;
        private TriviaGamePresenter _presenter;

        private Question _firstQuestion = Substitute.For<Question>();
        private Question _secondQuestion = Substitute.For<Question>();
        private Question _thirdQuestion = Substitute.For<Question>();
        
        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<TriviaGameView>();
            _presenter = new TriviaGamePresenter(_view, new Question[]{_firstQuestion, _secondQuestion, _thirdQuestion});

            _firstQuestion.IsRightAnswer("ok").Returns(true);
            _firstQuestion.IsRightAnswer("nope").Returns(false);
            
            _secondQuestion.IsRightAnswer("ok").Returns(true);
            _secondQuestion.IsRightAnswer("nope").Returns(false);
            
            _thirdQuestion.IsRightAnswer("ok").Returns(true);
            _thirdQuestion.IsRightAnswer("nope").Returns(false);
        }
        
        [Test]
        public void ANewTriviaGameStartsWithZeroScore()
        {
            ThenScoreIsZero();
        }

        [Test]
        public void ANewGameShowsTheFirstQuestion()
        {
            ThenViewIsShowingTheFirstQuestion();
        }

        [Test]
        public void WhenRightAnswerScoreIncreases()
        {
            var initialScore = _presenter.Score;
            WhenRightAnswer();
            ThenScoreIncreasedByOne(initialScore);
        }

        [Test]
        public void WhenRightAnswerShowsPositiveFeedback()
        {
            WhenRightAnswer();
            ThenShowsPositiveFeedback();
        }

        [Test]
        public void WhenRightAnswerShowsUpdatedScore()
        {
            WhenRightAnswer();
            ThenShowsCurrentScore(_presenter.Score);
        }

        [Test]
        public void WhenRightAnswerShowsNextQuestiion()
        {
            WhenRightAnswer();
            ThenViewIsShowingTheSecondQuestion();
        }

        [Test]
        public void When3RightAnswersWin()
        {
            When3RightAnswers();
            ThenShowsWinningFeedback();
        }
        
        [Test]
        public void WhenWrongAnswerScoreDoesntChange()
        {
            var initialScore = _presenter.Score;
            WhenWrongAnswer();
            ThenScoreDoesntChange(initialScore);
        }

        [Test]
        public void WhenWrongAnswerGameOver()
        {
            WhenWrongAnswer();
            ThenShowsLosingFeedback();
        }

        private void WhenWrongAnswer()
        {
            _presenter.ReceiveAnswer("nope");
        }

        private void WhenRightAnswer()
        {
            _presenter.ReceiveAnswer("ok");
        }
        
        private void When3RightAnswers()
        {
            WhenRightAnswer();
            WhenRightAnswer();
            WhenRightAnswer();
        }

        private void ThenScoreIsZero()
        {
            Assert.AreEqual(0, _presenter.Score);
        }

        private void ThenShowsPositiveFeedback()
        {
            _view.Received(1).ShowPositiveFeedback();
        }
        
        private void ThenScoreIncreasedByOne(int initialScore)
        {
            Assert.AreEqual(initialScore + 1, _presenter.Score);
        }
        
        private void ThenScoreDoesntChange(int initialScore)
        {
            Assert.AreEqual(initialScore, _presenter.Score);
        }

        private void ThenViewIsShowingTheFirstQuestion()
        {
            _view.Received(1).ShowNextQuestion(_firstQuestion);
        }
        
        private void ThenViewIsShowingTheSecondQuestion()
        {
            _view.Received(1).ShowNextQuestion(_secondQuestion);
        }

        private void ThenShowsWinningFeedback()
        {
            _view.Received(1).ShowWinFeedback();
        }

        private void ThenShowsLosingFeedback()
        {
            _view.Received(1).ShowLoseFeedback();
        }        
        
        private void ThenShowsCurrentScore(int currentScore)
        {
            _view.Received().UpdateScore(currentScore);
        }
    }
}