using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Invisible : MonoBehaviour
{
    [ToggleLeft]
    public bool invisibleOnPlay = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer _renderer = GetComponent<Renderer>();
        if (_renderer != null) _renderer.enabled = !invisibleOnPlay;
    }
}
