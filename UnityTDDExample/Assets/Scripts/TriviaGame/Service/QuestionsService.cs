using System.Collections.Generic;
using TriviaGame.Domain;
using Random = UnityEngine.Random;

namespace TriviaGame.Service
{
    public class QuestionsService
    {
        private List<Question> _allQuestions;

        public QuestionsService()
        {
            _allQuestions = new List<Question>()
            {
                new Question("How many months are there in a year?", "12", new[] {"10", "15", "30"}),
                new Question("How many days are there in a week?", "7", new[] {"12", "6", "5"}),
                new Question("Witch of these is not an insect", "Cow", new[] {"Worm", "Fly", "Spider"}),
                new Question("Witch of these is not a country", "Paris", new[] {"England", "Argentina", "Spain"}),
                new Question("Witch of these is not a city", "Uruguay", new[] {"Tokyo", "Buenos Aires", "Madrid"})
            };
        }

        public Question[] GetQuestions(int amount)
        {
            _allQuestions.Sort((a,b)=> Random.Range(0,2) == 0 ? 1 : -1);
            return _allQuestions.GetRange(0, amount).ToArray();
        }
    }
}