using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arachnid
{

    public enum UpdateMode { Update = 0, FixedUpdate = 1, LateUpdate = 2}

    [ExecuteInEditMode]
    [AddComponentMenu("Arachnid/Transform/Set Rotation")]
    public class SetRotation : MonoBehaviour
    {
        public UpdateMode updateMode;
        public Space rotationSpace;
        public Vector3 eulers;

        // Use this for initialization
        void Start ()
        {

        }

        void Update()
        {
            if (updateMode != UpdateMode.Update) return;
            DoRotate();
        }


        void LateUpdate ()
        {
            if (updateMode != UpdateMode.LateUpdate) return;
            DoRotate();
        }

        void FixedUpdate()
        {
            if (updateMode != UpdateMode.FixedUpdate) return;
            DoRotate();
        }

        void DoRotate()
        {
            if (rotationSpace == Space.Self)
            {
                transform.localEulerAngles = eulers;
            }

            if (rotationSpace == Space.World)
            {
                transform.eulerAngles = eulers;
            }
        }
    }
}