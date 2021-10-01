using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static public SoundManager Standard;

    private void Awake()
    {
        if (Standard == null)
        {
            Standard = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this); }
    }


    /// <summary>
    /// 播放音效
    /// </summary>
    public SoundEffectPlayer effect
    {
        get
        {
            return _effectSource;
        }
    }

    [SerializeField]
    private SoundEffectPlayer _effectSource;


    public void PlayEffect(SoundEffectPlayer.Effect value)
    {
        effect.Play(value);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
