using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DelayController : MonoBehaviour
{
    public static DelayController Standard;

    private void Awake()
    {
        if (Standard == null) {
            Standard = this;
            DontDestroyOnLoad(Standard);
        }
    }


    public void DelayToCall(float delay, Action action)
    {
        if (delay <= 0) action();
        StartCoroutine(Delay(action, delay));
    }


     IEnumerator Delay(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

}
