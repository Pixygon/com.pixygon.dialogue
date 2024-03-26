using System.Collections.Generic;
using UnityEngine;

namespace Pixygon.Dialogue {
    public class DialogueGenerator : MonoBehaviour {
        [SerializeField] private DialogueGeneratorData _data;
        public enum Personality {
            Friendly = 0,
            Grumpy = 1,
            Curious = 2,
            Lazy = 3,
            Adventurous = 4,
            Wise = 5
        };

        private static Dictionary<Personality, string[]> _dialogueOptions;

        private void Awake() {
            _dialogueOptions = new Dictionary<Personality, string[]>();
            InitializeDialogueOptions();
        }

        private void InitializeDialogueOptions() {
            _dialogueOptions.Add(Personality.Friendly, _data._personalityFriendly);
            _dialogueOptions.Add(Personality.Grumpy, _data._personalityGrumpy);
            _dialogueOptions.Add(Personality.Curious, _data._personalityCurious);
            _dialogueOptions.Add(Personality.Lazy, _data._personalityLazy);
            _dialogueOptions.Add(Personality.Adventurous, _data._personalityAdventurous);
            _dialogueOptions.Add(Personality.Wise, _data._personalityWise);
        }

        public static string GenerateRandomDialogue(Personality personality) {
            var options = _dialogueOptions[personality];
            return options[Random.Range(0, options.Length)];
        }
    }
}