using UnityEngine;
using System;
using System.Collections;

public class SoundDefaultEffect : MonoBehaviour
{

    public Color color = Color.white;


    [SerializeField]
    private SpriteRenderer[] mainRenderers;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        RemadeColor();
    }


    private void RemadeColor()
    {
        foreach (var item in mainRenderers)
        {
            item.color = color;
        }
    }


    public void Play()
    {
        PlayOrPause(true);
    }

    public void Stop()
    {
        PlayOrPause(false);
    }

    private void PlayOrPause(bool isPlay)
    {
        animator.SetBool("isPlaying", isPlay);
    }


}
