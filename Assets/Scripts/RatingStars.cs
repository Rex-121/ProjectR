using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using DG.Tweening;

public class RatingStars : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private AudioSource audioClip;

    [SerializeField]
    private DOTweenAnimation[] stars;


    public System.Action DidEndRating;


    private void OnMouseDown()
    {

        Ranking(2);

    }


    // 评级
    public void Ranking(int to)
    {

        PlayAddition();

        foreach (var item in stars)
        {
            //item.DORewind();
        }

        if (stars.Length == 0)
        {
            return;
        }

        for (int i = 0; i < to; i++)
        {
            stars[i].DOPlay();
        }
    }


    Coroutine cor;

    // 播放其他
    private void PlayAddition()
    {
        particle.Play();

        StartCoroutine(EndParticle(particle, DidEndParticle));

        PlayAudio();
    }

    // 播放音频
    private void PlayAudio()
    {
        audioClip.Play();

        if (cor != null)
        {
            StopCoroutine(cor);
        }

        cor = StartCoroutine(AudioCallBack(audioClip, EndAudio));
    }

    // 粒子停止
    private void DidEndParticle()
    {
        //Destroy(particle);
    }

    private IEnumerator EndParticle(ParticleSystem particle, UnityAction action)
    {

        yield return new WaitForSeconds(particle.main.duration + 0.1f);//延迟零点一秒执行
        action();
    }


    // 音频停止
    void EndAudio()
    {
        Debug.Log("音频停止");
    }

    private IEnumerator AudioCallBack(AudioSource AudioObject, UnityAction action)
    {
        while (AudioObject.isPlaying)
        {
            yield return new WaitForSecondsRealtime(0.1f);//延迟零点一秒执行
        }
        action();
    }

}
