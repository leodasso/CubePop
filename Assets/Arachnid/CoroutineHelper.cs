using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arachnid
{
    public class CoroutineHelper : MonoBehaviour
    {
        static CoroutineHelper _coroutineObject;

        public static void NewCoroutine(IEnumerator coroutine)
        {
            if (_coroutineObject == null)
            {
                GameObject coroutineHelper = new GameObject("Coroutine Helper");
                DontDestroyOnLoad(coroutineHelper);
                _coroutineObject = coroutineHelper.AddComponent<CoroutineHelper>();
            }

            _coroutineObject.StartCoroutine(coroutine);
        }
    }
}