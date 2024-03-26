using TMPro;
using UnityEngine;

namespace Pixygon.Dialogue {
    public class DialogueMenu : MonoBehaviour {
        [SerializeField] private TextMeshPro _titleText;
        [SerializeField] private TextMeshPro _dialogueText;
        public void StartDialogue(string title, string text) {
            _titleText.text = title;
            _dialogueText.text = text;
            gameObject.SetActive(true);
        }

        public void CloseDialogue() {
            gameObject.SetActive(false);
        }
    }
}