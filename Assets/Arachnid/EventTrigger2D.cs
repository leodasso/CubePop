using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace Arachnid {

    [RequireComponent(typeof(Collider2D))]
    [TypeInfoBox("When the attached 2D Collider is triggered, will Invoke the events contained below.")]
    public class EventTrigger2D : FilteredTrigger2D
    {
        [AssetsOnly]
        public List<GameEvent> events = new List<GameEvent>();
        public UnityEvent uEvent;

        protected override void OnTriggered(Collider2D triggerer)
        {
            uEvent.Invoke();
            foreach (var e in events) e.Raise();
        }
    }
}