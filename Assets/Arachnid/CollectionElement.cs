using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{
    public class CollectionElement : MonoBehaviour
    {
        [AssetsOnly]
        public Collection collection;

        void OnEnable ()
        {
            collection.Add(this);
        }

        void OnDisable ()
        {
            collection.Remove(this);
        }
    }
}