using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{

    [CreateAssetMenu(menuName = "Arachnid/Localization Term")]
    public class LocTerm : ScriptableObject
    {
        [MultiLineProperty(5), HideLabel, Title("Text")]
        public string text;

        public string LocText()
        {
            return text;
        }
    }
}