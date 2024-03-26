using System.Collections.Generic;
using UnityEngine;

namespace Pixygon.Dialogue {
    [CreateAssetMenu(menuName = "Pixygon/Dialogue/NameGeneratorData", fileName = "New NameGeneratorData")]
    public class NameGeneratorData : ScriptableObject {
        public List<string> _firstNames;
        public List<string> _lastNames;
        
        public bool _useMiddleName = false;
        public List<string> _middleNames;

        public bool _useTitle = false;
        public List<string> _titles;
        
        public bool _useNickname = false;
        public List<string> _nicknames;
    }
}