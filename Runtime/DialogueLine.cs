using System;
using UnityEngine.Events;

namespace Pixygon.Dialogue {
    [Serializable]
    public class DialogueLine {
        public string _text;
        public DialogueStub _dialogueStub;
        public Character _character;
        public UnityEvent _onFinish;

        public bool HasText => _dialogueStub != null;
        public string Text => _dialogueStub.GetText(Languages.English);
    }
}