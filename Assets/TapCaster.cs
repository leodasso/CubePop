using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCaster : MonoBehaviour
{
    public float tapTime = .1f;
    
    Camera _camera;
    GameObject _tapped;
    float _tapTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_tapped) _tapTimer += Time.unscaledDeltaTime;
        if (Input.GetButtonDown("Tap")) OnTapDown();
        if (Input.GetButtonUp("Tap")) OnTapUp();
    }

    void OnTapDown()
    {
        _tapTimer = 0;
        
        // Cast a ray to the mouse position to see if anything is tapped
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _tapped = hit.transform.gameObject;
            Tappable tappable = _tapped.GetComponent<Tappable>();
            if (tappable) tappable.onPress.Invoke();
        }
    }

    void OnTapUp()
    {
        if (!_tapped) return;
        Tappable tappable = _tapped.GetComponent<Tappable>();
        if (tappable)
        {
            if (_tapTimer <= tapTime)  tappable.onTap.Invoke();
            else tappable.onTapUp.Invoke();
        }
        _tapped = null;
    }
}