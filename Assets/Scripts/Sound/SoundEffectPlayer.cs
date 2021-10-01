using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectPlayer : MonoBehaviour
{

    public enum Effect
    {
        right, wrong
    }

    public AudioSource audioSource;

    public AudioClip right, wrong;

    public void Play(Effect effect)
    {

        switch (effect)
        {
            case Effect.right:
                audioSource.clip = right;
                break;
            case Effect.wrong:
                audioSource.clip = wrong;
                break;
        }

        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
