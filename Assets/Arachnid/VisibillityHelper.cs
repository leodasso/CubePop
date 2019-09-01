using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{
    [RequireComponent(typeof(Camera))]
    /// <summary>
    /// Attaches to any camera. Can cast to each item in any collection, and will attempt to make them visible
    /// at all times by setting any objects between the target and the camera transparent.
    /// </summary>
    public class VisibillityHelper : MonoBehaviour
    {
        [Tooltip("Any objects within this collection will be casted to from the attached camera. If any objects are between the " +
            "camera and the target object, they will be made transparent.")]
        public Collection targetObjects;

        [Tooltip("Any objects in these layers will be made transparent if objects of the visibility collection are behind it.")]
        public LayerMask props;

        [MinValue(0), Tooltip("The lifetime of the transparenters created. If they go this many seconds without being in the way, they return to opaque.")]
        public float transparencyLifetime = 1;

        [Tooltip("The speed objects will transition between opaque and transparent.")]
        public float transitionSpeed = 1;

        [Range(0, 1), Tooltip("When objects are made transparent, they will have this alpha.")]
        public float minAlpha = .3f;

        List<Transparenter> allTrancparenters = new List<Transparenter>();

        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {
            if (targetObjects == null) return;

            foreach (var element in targetObjects.elements)
            {
                if (element == null) continue;
                CastToElement(element.gameObject);
            }
        }

        List<RaycastHit> hits = new List<RaycastHit>();
        Ray ray;

        void CastToElement(GameObject element)
        {
            float dist = Vector3.Distance(transform.position, element.transform.position);
            ray = new Ray(transform.position, (element.transform.position - transform.position).normalized);

            hits.Clear();
            hits.AddRange(Physics.RaycastAll(ray, dist, props, QueryTriggerInteraction.Collide));
            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;
                UpdateTransparentComponent(hit.collider.gameObject);
            }

        }

        /// <summary>
        /// Checks if the given object has a transparency component. Adds one & inits it if it doesn't.
        /// </summary>
        void UpdateTransparentComponent(GameObject target)
        {
            Transparenter t = target.GetComponent<Transparenter>();
            if (t)
            {
                t.Refresh();
                return;
            }

            t = GetComponentInParent<Transparenter>();
            if (t)
            {
                t.Refresh();
                return;
            }

            t = target.AddComponent<Transparenter>();
            t.TakeStats(this);
        }
    }
}