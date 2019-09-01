using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class Tappable : MonoBehaviour
{
    [Tooltip("When a finger goes down and up quickly enough to be considered a tap")]
    public UnityEvent onTap;
    public UnityEvent onPress;
    public UnityEvent onTapUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    void Tap()
    {
        onTap.Invoke();
    }
}
