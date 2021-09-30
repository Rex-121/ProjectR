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
    }

    /// <summary>
    /// 播放音乐特效
    /// </summary>
    [SerializeField]
    SoundDefaultEffect soundDefaultEffect;

    void Start()
    {
        var item = new TapReadItem.Usage("https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-09-22/c55gk2et0gb0jnjrog3g.wav", "https://roobo-test.oss-cn-beijing.aliyuncs.com/appcourse/manager/2021-07-16/c3on1jln4qt6t4tcobrg.png");

        TapReadItem pre = Instantiate(itemPre).GetComponent<TapReadItem>();
        pre.SetItem(item);
        pre.transform.parent = boardItemPoint;
        pre.DidTapItem += DidTapItem;
        selectedItem = pre;
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


    void PlayAudio(TapReadItem item)
    {
        audioSource.clip = item.audioClip;
        audioSource.Play();
        soundDefaultEffect.Play();

        if (cor != null)
        {
            StopCoroutine(cor);
        }

        cor = StartCoroutine(SoundDidEndPlay(item.audioClip.length));
       
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
