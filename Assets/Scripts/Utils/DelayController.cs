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
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


    public Coroutine DelayToCall(float delay, Action action)
    {
       return StartCoroutine(Delay(action, delay));
    }


     IEnumerator Delay(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

}
