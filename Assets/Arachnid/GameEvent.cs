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
        public bool enabled = true;
        
        [ToggleLeft]
        public bool debug;
        [ShowInInspector]
        List<GameEventListener> listeners = new List<GameEventListener>();

        public float delay;

        [DrawWithUnity]
        public UnityEvent onEventRaised;

        [MultiLineProperty, HideLabel, Title("Description")]
        public string description;

        [Button]
        public void Raise()
        {
            if (!enabled)
            {
                if (debug) 
                    Debug.Log(name + " event was raised, but it is not enabled.");
                
                return;
            }
            
            if (debug)
                Debug.Log(name + " event was raised at " + Time.unscaledTime, this);

            if (delay > 0)
            {
                if (debug)
                    Debug.Log(name + " has a delay of " + delay + " seconds.", this);
                
                CoroutineHelper.NewCoroutine(DelayedRaise());
            }
            
            else RaiseInternal();
        }

        void RaiseInternal()
        {
            onEventRaised.Invoke();

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners [i].OnEventRaised();
            }
        }

        IEnumerator DelayedRaise()
        {
            yield return new WaitForSecondsRealtime(delay);
            RaiseInternal();
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