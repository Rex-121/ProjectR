using UnityEngine;


public class TapReadItem : MonoBehaviour
{


    //[System.Serializable]
    //public class 
    //{
    //    public string audioUri;

    //    public string imageUri;

    //    public Usage(string audioUri, string imageUri)
    //    {
    //        this.audioUri = audioUri;
    //        this.imageUri = imageUri;
    //    }

    //}

    public System.Action<TapReadItem> DidTapItem;

    [SerializeField]
    public ImageWithAudio_SO item;


    public void SetItem(ImageWithAudio_SO item) {
        this.item = item;
        imageDownload.uri = item.imageUri;
        audioDownload.uri = item.audioUri;
    }

    private void OnMouseDown()
    {
        DidTapItem(this);
    }

    [SerializeField]
    private ImageDownload imageDownload;

    [SerializeField]
    private AudioDownload audioDownload;

    //public SoundDefaultEffect soundDefaultEffect;


    public AudioClip audioClip
    {
        get
        {
            return audioDownload.audioClip;
        }
    }

}
