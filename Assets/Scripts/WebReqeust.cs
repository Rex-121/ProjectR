using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public static class WebReqeust
{

    private class WebRequestsMonoBehaviour : MonoBehaviour { }

    private static WebRequestsMonoBehaviour webRequestsMonoBehaviour;


    private static void Init()
    {
        if (webRequestsMonoBehaviour == null)
        {
            GameObject gameObj = new GameObject("WebReqeust");
            webRequestsMonoBehaviour = gameObj.AddComponent<WebRequestsMonoBehaviour>();
        }
    }

    public static void Get(string url, Action<string> onSuccess, Action<string> onError)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutine(url, onSuccess, onError));
    }



    private static IEnumerator GetCoroutine(string url, Action<string> onSuccess, Action<string> onError)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();


            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError || unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }

        }
    }

    public static void GetTexture(string url, Action<Texture2D> onSuccess, Action<string> onError)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetTextureCoroutine(url, onSuccess, onError));
    }


    private static IEnumerator GetTextureCoroutine(string url, Action<Texture2D> onSuccess, Action<string> onError)
    {

        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();


            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError || unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess(downloadHandlerTexture.texture);
            }

        }
    }


    public static void GetAudio(string url, Action<AudioClip> onSuccess, Action<string> onError)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetAudioCoroutine(url, onSuccess, onError));
    }


    private static IEnumerator GetAudioCoroutine(string url, Action<AudioClip> onSuccess, Action<string> onError)
    {

        using (UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return unityWebRequest.SendWebRequest();


            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError || unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerAudioClip downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerAudioClip;
                onSuccess(downloadHandlerTexture.audioClip);
            }

        }
    }
}
