using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid {

    [RequireComponent(typeof(Collider))]
    public class EventTrigger : MonoBehaviour
    {
        [AssetsOnly]
        public List<GameEvent> events = new List<GameEvent>();

        [ToggleLeft, Tooltip("Only allow triggers from objects of a particular collection")]
        public bool filterTriggers = true;

        [ShowIf("filterTriggers"), Tooltip("Any object in one of these collections can trigger this."), AssetsOnly]
        public List<Collection> triggerers = new List<Collection>();


        void OnTriggerEnter(Collider other)
        {
            if (!filterTriggers)
            {
                Trigger();
                return;
            }

            foreach (var c in triggerers)
            {
                if (c.ContainsGameObject(other.gameObject))
                {
                    Trigger();
                    return;
                }
            }
        }

        void Trigger()
        {
            foreach (var e in events) e.Raise();
        }
    }
}