using UnityEngine;

namespace Pixygon.Dialogue {
    [CreateAssetMenu(menuName = "Pixygon/Dialogue/DialogueGeneratorData", fileName = "New NameDialogueData")]
    public class DialogueGeneratorData : ScriptableObject {
        public string[] _personalityFriendly;
        public string[] _personalityGrumpy;
        public string[] _personalityCurious;
        public string[] _personalityLazy;
        public string[] _personalityAdventurous;
        public string[] _personalityWise;
    }
}