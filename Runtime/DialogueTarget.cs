using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pixygon.Dialogue {
    public class DialogueTarget : MonoBehaviour {
        [SerializeField] private bool _isRandomized;
        [SerializeField] private string _name;
        [SerializeField] private string _dialogue;
        [SerializeField] private DialogueGenerator.Personality _personality;
        //[SerializeField] private MicroActorAI _actor;
        [SerializeField] private NameGeneratorData _nameGenData;

        private Action<bool> _action;

        public string Title => _name;
        public string CurrentDialouge { get; private set; }
        
        private void Start() {
            if (!_isRandomized) return;
            var bearNameGenerator = new NameGenerator();
            _name = bearNameGenerator.GenerateRandomName(_nameGenData);
            _personality = (DialogueGenerator.Personality)Random.Range(0, 5);
        }

        public void StartDialogue() {
            //Stop walking
            if (_isRandomized) {
                CurrentDialouge = DialogueGenerator.GenerateRandomDialogue(_personality);
            }
            else {
                CurrentDialouge = _dialogue;
            }
            //_actor.GetComponent<AIMover>().SetPause(true);
            _action.Invoke(true);
        }

        public void EndDialogue() {
            //_actor.GetComponent<AIMover>().SetPause(false);
            _action.Invoke(false);
        }
    }
}
