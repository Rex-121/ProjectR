using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDownload : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public string uri;

    public System.Action<Texture2D> DidLoadItem;


    public Vector2 imageSize = Vector2.zero;


    void Start()
    {
        WebReqeust.GetTexture(uri, (Texture2D texture2D) =>
        {
            Debug.Log(texture2D.texelSize);
            Debug.Log(texture2D.width);
            Debug.Log(texture2D.height);

            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(.5f, .5f));

            spriteRenderer.sprite = sprite;

            if (DidLoadItem != null)
            {
                DidLoadItem(texture2D);
            }

        }, (string error) =>
        {
            Debug.Log("rrrrr");
            Debug.Log(error);
        });
    }


    Vector2 trueSize(Vector2 size, Texture2D texture2D)
    {
        if (size == Vector2.zero)
        {
            return new Vector2(texture2D.width, texture2D.height);
        }
        return size;
    }

}
