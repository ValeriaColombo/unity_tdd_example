using System;
using TMPro;
using UnityEngine;

namespace TriviaGame.Delivery
{
    public class AnswerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _answerText;
        
        private Action<string> _onAnswerSelected;
        
        public void Initialize(Action<string> onAnswerSelected)
        {
            _onAnswerSelected = onAnswerSelected;
        }
        
        public void FillData(string answerText)
        {
            _answerText.text = answerText;
        }

        public void OnClick()
        {
            _onAnswerSelected?.Invoke(_answerText.text);
        }
    }
}