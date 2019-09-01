using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace Arachnid
{
    [CreateAssetMenu(menuName ="Arachnid/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [ToggleLeft]
        public bool debug;
        [ShowInInspector]
        List<GameEventListener> listeners = new List<GameEventListener>();

        [DrawWithUnity]
        public UnityEvent onEventRaised;

        [MultiLineProperty, HideLabel, Title("Description")]
        public string description;

        [Button]
        public void Raise()
        {
            if (debug)
                Debug.Log(name + " event was raised at " + Time.unscaledTime);
            
            onEventRaised.Invoke();

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners [i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener instance)
        {
            if (listeners.Contains(instance)) return;
            listeners.Add(instance);
        }

        public void UnregisterListener(GameEventListener instance)
        {
            listeners.Remove(instance);
        }
    }
}