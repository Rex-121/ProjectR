using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RenderHeads.Media.AVProVideo;

public class VideoCache : MonoBehaviour
{

    [SerializeField] MediaPlayer _mediaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (_mediaPlayer.Cache.IsMediaCachingSupported())
        {
            Debug.Log("-------support");
            _mediaPlayer.Cache.AddMediaToCache("https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/video/2021-09-14/c5068d53hct220o5lq10.mp4_PKG/Video.m3u8", null, null);
        }
        else
        {
            Debug.Log("-------not-support");
        }

        //"".Split()
    }

}
