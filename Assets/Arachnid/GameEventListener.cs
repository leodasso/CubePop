using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace Arachnid {

    public class GameEventListener : MonoBehaviour 
    {

        [AssetsOnly, Tooltip("When any of these game events happen, the below response will happen!")]
        public List<GameEvent> gameEvents = new List<GameEvent>();
        public UnityEvent response;
        
        [MultiLineProperty(5), HideLabel, FoldoutGroup("Comments")]
        public string comment;

        void OnEnable()
        {
            foreach (var e in gameEvents) e.RegisterListener(this);
        }

        void OnDisable()
        {
            foreach (var e in gameEvents) e.UnregisterListener(this);
        }

        public void OnEventRaised ()
        {
            response.Invoke();
        }
    }
}