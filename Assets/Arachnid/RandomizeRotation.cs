using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{

    public class RandomizeRotation : MonoBehaviour
    {
        [ToggleLeft]
        public bool randomizeOnStart = true;
        [ToggleLeft]
        public bool randomizeOnEnable;

        [Range(0, 360)]
        public float randomizeRotX = 5;
        [Range(0, 360)]
        public float randomizeRotY = 5;
        [Range(0, 360)]
        public float randomizeRotZ = 5;

        // Use this for initialization
        void Start ()
        {
            if (randomizeOnStart) Randomize();
        }

        void OnEnable()
        {
            if (randomizeOnEnable) Randomize();
        }

        void Randomize()
        {
            Vector3 randEulers = new Vector3(
            Random.Range(-randomizeRotX, randomizeRotX),
            Random.Range(-randomizeRotY, randomizeRotY),
            Random.Range(-randomizeRotZ, randomizeRotZ));

            transform.Rotate(randEulers);
        }
    }
}