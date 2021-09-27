using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDownload : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public string uri;

    void Start()
    {
        Debug.Log("fadsgasdf");
        Debug.Log(uri.ToString());
        WebReqeust.GetTexture(uri, (Texture2D texture2D) =>
        {
            Debug.Log("fffffff");
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(.5f, .5f));

            spriteRenderer.sprite = sprite;

        }, (string error) =>
        {
            Debug.Log("rrrrr");
            Debug.Log(error);
        });
    }


}
