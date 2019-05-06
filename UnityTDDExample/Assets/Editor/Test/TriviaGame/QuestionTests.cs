using NUnit.Framework;
using TriviaGame.Domain;

namespace Test.TriviaGame
{
    [TestFixture]
    public class QuestionTests
    {
        private Question _question;

        [SetUp]
        public void SetUp()
        {
            _question = new Question("question text", "correct", new []{"incorrect 1", "incorrect 2", "incorrect 3"});
        }

        [Test]
        public void CheckCorrectAnswerReturnsCorrect()
        {
            Assert.IsTrue(_question.IsRightAnswer("correct"));
        }
        
        [Test]
        public void CheckIncorrectAnswerReturnsIncorrect()
        {
            Assert.IsFalse(_question.IsRightAnswer("incorrect 1"));            
        }
    }
}