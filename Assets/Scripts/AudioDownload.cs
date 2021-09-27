using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDownload : MonoBehaviour
{
    /// <summary>
    /// https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-22/c55gk2et0gb0jnjrog3g.wav
    /// </summary>
    // Start is called before the first frame update

    public string uri;

    public AudioClip audioClip;

    void Start()
    {
        LoadAudio();
    }

    void LoadAudio()
    {
        WebReqeust.GetAudio(uri, (AudioClip audio) =>
        {
          
            DidLoadAudio(audio);

        }, (string error) => {


        });
    }

    void DidLoadAudio(AudioClip audio)
    {
        audioClip = audio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
