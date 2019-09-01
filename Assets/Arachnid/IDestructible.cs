using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arachnid
{
    public interface IDestructible
    {
        void Damage (int amount, Vector3 pushForce, Vector3 pos);

        void Kill ();
    }
}
