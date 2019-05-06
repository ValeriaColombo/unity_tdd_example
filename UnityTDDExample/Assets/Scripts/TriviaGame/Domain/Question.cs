namespace TriviaGame.Domain
{
    public class Question
    {
        public string QuestionText { get; private set; }
        public string RightAnswer { get; private set; }
        public string[] WrongAnswers { get; private set; }

        public Question() {}
        public Question(string questionText, string rightAnswer, string[] wrongAnswers)
        {
            QuestionText = questionText;
            RightAnswer = rightAnswer;
            WrongAnswers = wrongAnswers;
        }

        public virtual bool IsRightAnswer(string anAnswer)
        {
            return string.Equals(RightAnswer, anAnswer);
        }
    }
}