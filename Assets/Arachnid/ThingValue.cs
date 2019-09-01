using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{

    public class ThingValue : MonoBehaviour
    {
        [AssetsOnly]
        public FloatValue valuePool;
        public float myValue = 1;

        void OnEnable()
        {
            valuePool.Value += myValue;
        }

        void OnDisable()
        {
            valuePool.Value -= myValue;
        }
    }
}