using NUnit.Framework;
using TriviaGame.Service;

namespace Test.TriviaGame
{
    [TestFixture]
    public class QuestionsServiceTests
    {
        private QuestionsService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new QuestionsService();
        }        

        [Test]
        public void ReturnsTheRequiredAmountOfQuestions()
        {
            var amount = 3;            
            var questions = _service.GetQuestions(amount);
            Assert.AreEqual(amount, questions.Length);            
        }
    }
}