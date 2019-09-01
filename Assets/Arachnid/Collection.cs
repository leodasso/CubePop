using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Arachnid
{

    [CreateAssetMenu(menuName ="Arachnid/Collection")]
    public class Collection : ScriptableObject
    {
        public enum LimitType { RemoveFirst, RemoveLast, RemoveRandom}

        [TabGroup("main", "Main"), ToggleLeft, Tooltip("Log whenever an element is added / removed to collection.")]
        public bool debug;

        [TabGroup("main", "Main"),MultiLineProperty, SerializeField, ShowInInspector, HideLabel, Title("Description")]
        string description;

        [TabGroup("main", "Main"),ToggleLeft]
        public bool limitSize;

        [TabGroup("main", "Main"), MinValue(1), ShowIf("limitSize"), Indent]
        public int maxSize = 1;

        [TabGroup("main", "Main"), Tooltip("If the limit is surpassed, what element should be destroyed?"), ShowIf("limitSize"), Indent]
        public LimitType limitAction = LimitType.RemoveFirst;

        /// <summary>
        /// All the elements that are currently active.
        /// </summary>
        [TabGroup("main", "Main")]
        public List<CollectionElement> elements = new List<CollectionElement>();


        [TabGroup("main", "Events")]
        public UnityEvent onElementAdded;
        
        [TabGroup("main", "Events")]
        public UnityEvent onElementRemoved;

        [TabGroup("main", "Events")]
        public UnityEvent onListBecomeEmpty;

        /// <summary>
        /// Add the given element to this collection.
        /// </summary>
        public void Add (CollectionElement element)
        {
            if (elements.Contains(element)) return;
            elements.Add(element);

            onElementAdded.Invoke();

            if (debug) Debug.Log(element.name + " was added to " + name + " at " + Time.unscaledTime);

            Limit();
        }

        /// <summary>
        /// Remove the given element from this collection. 
        /// </summary>
        public void Remove (CollectionElement element)
        {
            if (!elements.Remove(element)) return;
            
            onElementRemoved.Invoke();
            if (elements.Count < 1) 
                onListBecomeEmpty.Invoke();
                
            if (debug) Debug.Log(element.name + " was removed from " + name + " at " + Time.unscaledTime);
        }

        /// <summary>
        /// Returns if the given game object is in this collection.
        /// </summary>
        public bool ContainsGameObject(GameObject query)
        {
            foreach (var e in elements)
                if (e.gameObject == query) return true;
            return false;
        }

        
        /// <summary>
        /// Destroy all elements of this collection.
        /// </summary>
        [Button]
        public void DestroyAll()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                Destroy(elements[i].gameObject);
            }
        }

        /// <summary>
        /// Checks if the size needs to be limited. If so, destroys an element from the collection 
        /// if it exceeds the max size.
        /// </summary>
        void Limit()
        {
            if (!limitSize) return;
            if (elements.Count <= maxSize) return;

            if (limitAction == LimitType.RemoveFirst)
                Destroy(elements.First().gameObject);

            else if (limitAction == LimitType.RemoveLast)
                Destroy(elements.Last().gameObject);

            else
            {
                CollectionElement e;
                if (GetRandom(out e)) Destroy(e.gameObject);
            }
        }

        /// <summary>
        /// Tries to get a random element from the list.
        /// </summary>
        /// <param name="randomElement">The selected random element</param>
        /// <returns>True if an element was found, false if not (if list is empty or full of nulls)</returns>
        public bool GetRandom(out CollectionElement randomElement)
        {
            randomElement = null;
            if (elements.Count < 1) return false;

            int i = Random.Range(0, elements.Count);
            randomElement = elements [i];
            return true;
        }

        /// <summary>
        /// Tries to get the element at the given index. If none is at that index, finds the nearest element.
        /// </summary>
        public CollectionElement GetElement(int elementIndex)
        {
            elementIndex = Mathf.Clamp(elementIndex, 0, elements.Count - 1);
            return elements [elementIndex];
        }

        /// <summary>
        /// Returns a list of components of the given type that are elements in this list.
        /// </summary>
        public List<T> GetElementsOfType<T>() where T : Component
        {
            List<T> typeElements = new List<T>();

            foreach (var e in elements)
            {
                typeElements.Add(e.GetComponent<T>());
            }

            typeElements = typeElements.Where(t => t != null).ToList();
            return typeElements;
        }

        public CollectionElement GetLastElement()
        {
            if (elements.Count < 1) return null;
            return elements.Last();
        }

        public CollectionElement GetFirstElement()
        {
            if (elements.Count < 1) return null;
            return elements.First();
        }
    }
}