using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class TapLeftRight : MonoBehaviour
{

    [SerializeField]
    UnityEvent tapEvent;


    private void OnMouseDown()
    {
        tapEvent.Invoke();
    }
}