using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TapReadItem : MonoBehaviour
{


    [System.Serializable]
    public class Usage
    {
        public string audioUri;

        public string imageUri;

        public Usage(string audioUri, string imageUri)
        {
            this.audioUri = audioUri;
            this.imageUri = imageUri;
        }
    }

    [SerializeField]
    private Usage item;


    public void SetItem(Usage item) {
        this.item = item;
        imageDownload.uri = item.imageUri;
        audioDownload.uri = item.audioUri;
    }


    [SerializeField]
    private ImageDownload imageDownload;

    [SerializeField]
    private AudioDownload audioDownload;

    public SoundDefaultEffect soundDefaultEffect;


    public AudioClip audioClip
    {
        get
        {
            return audioDownload.audioClip;
        }
    }


    void Start()
    {
        soundDefaultEffect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioClip != null)
        {
            soundDefaultEffect.gameObject.SetActive(true);
        }
    }


    public void Play()
    {
        if (audioClip != null)
        {
            soundDefaultEffect.Play();
        }
    }
}
