using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TapReadCourseware : MonoBehaviour
{


    [SerializeField]
    private Transform boardItemPoint;

    AudioSource audioSource;

    public GameObject itemPre;

    public System.Action<TapReadCourseware> DidEndCourseware;

    private TapReadItem _selectedItem;
    private TapReadItem selectedItem
    {
        get
        {
            return _selectedItem;
        }

        set
        {
            _selectedItem = value;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        list = new TapItemFakeData().list;

    }

    /// <summary>
    /// 播放音乐特效
    /// </summary>
    [SerializeField]
    SoundDefaultEffect soundDefaultEffect;


    TapReadItem.Usage[] list;


    Dictionary<int, GameObject> listDic = new Dictionary<int, GameObject>();

    int currentIndex = 0;

    void Start()
    {

        MakeItem();
    }

    void MakeItem()
    {

        StopPlayingAudio();

        GameObject old;

        foreach(var item in listDic.Values)
        {
            item.SetActive(false);
        }

        listDic.TryGetValue(currentIndex, out old);

        if (old == null)
        {
            old = Instantiate(itemPre);
            listDic.Add(currentIndex, old);

            var item = list[currentIndex];

            TapReadItem pre = old.GetComponent<TapReadItem>();
            pre.SetItem(item);
        }
        else
        {
            old.SetActive(true);
        }

        old.transform.parent = boardItemPoint;
        old.GetComponent<TapReadItem>().DidTapItem += DidTapItem;
        selectedItem = old.GetComponent<TapReadItem>();
    }

    void DidTapItem(TapReadItem item)
    {
        PlayAudio(item);
    }

    // Update is called once per frame
    void Update()
    {
        /// 是否需要隐藏音效
        HideSoundEffectIfNeeded();
    }


    Coroutine cor;


    public void DidSelectedNextOrPreItem(string value)
    {
        int c = currentIndex;

        switch (value)
        {
            case "left":
                currentIndex = Mathf.Max(0, currentIndex - 1);
                break;
            case "right":

                var nowValue = currentIndex + 1;

                if (nowValue > list.Length - 1)
                {
                    DidEndCourseware(this);
                }
                else
                {
                    currentIndex = nowValue;
                }




                break;
        }


        MakeItem();
    }

    void PlayAudio(TapReadItem item)
    {

        StopPlayingAudio();

        audioSource.clip = item.audioClip;
        audioSource.Play();
        soundDefaultEffect.Play();

   

        cor = StartCoroutine(SoundDidEndPlay(item.audioClip.length));

    }

    void StopPlayingAudio()
    {
        if (audioSource.isPlaying) audioSource.Stop();

        if (cor != null)
        {
            StopCoroutine(cor);
        }
    }


    IEnumerator SoundDidEndPlay(float second)
    {
        yield return new WaitForSeconds(second);
        soundDefaultEffect.Stop();
    }





    /// -------------
    void HideSoundEffectIfNeeded()
    {
        soundDefaultEffect.gameObject.SetActive(CheckAudioIsAvaiable());
    }

    bool CheckAudioIsAvaiable()
    {
        return selectedItem != null && selectedItem?.audioClip != null;
    }
    /// -------------
}


class TapItemFakeData
{


    public TapReadItem.Usage[] list
    {
        get
        {
            var item = new TapReadItem.Usage("https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-22/c55gk2et0gb0jnjrog3g.wav", "https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-07-16/c3on1jln4qt6t4tcobrg.png");

            var i = new TapReadItem.Usage("https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-30/c5anlcvfnhdbg6qujelg.wav", "https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-14/c501doibfca5a8elfodg.jpeg");


            return new[] { item, i };
        }
    }

}