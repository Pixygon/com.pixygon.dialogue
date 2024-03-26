using System;
using UnityEngine;

namespace Pixygon.Dialogue {
    [CreateAssetMenu(menuName = "Pixygon/Dialogue/New DialogueStub")]
    public class DialogueStub : ScriptableObject {
        public Character Character;
        public string EnglishText;
        public string NorwegianText;
        public string UkrainianText;
        public string RussianText;
        public string FrenchText;
        public string SpanishText;

        public string GetText(Languages languages) {
            return languages switch {
                Languages.English => EnglishText,
                Languages.Norwegian => NorwegianText,
                Languages.Ukrainian => UkrainianText,
                Languages.Russian => RussianText,
                Languages.French => FrenchText,
                Languages.Spanish => SpanishText,
                _ => throw new ArgumentOutOfRangeException(nameof(languages), languages, null)
            };
        }
    }
}