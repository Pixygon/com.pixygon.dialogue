using Pixygon.Micro;
using UnityEngine;

namespace Pixygon.Dialogue {
    public class DialogueTrigger : LevelObject {
        [SerializeField] private DialogueLine[] _lines;
        [SerializeField] private bool _resetOnRespawn;
        public bool IsTriggered;
        public DialogueLine[] Lines => _lines;

        public override void Reset() {
            base.Reset();
            if(_resetOnRespawn)
                IsTriggered = false;
        }
    }
}