using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCube : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BePressed()
    {
        transform.localScale = Vector3.one * .8f;
    }

    public void BeUnPressed()
    {
        transform.localScale = Vector3.one;
    }
}
