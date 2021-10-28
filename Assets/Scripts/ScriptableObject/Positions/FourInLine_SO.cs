using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FourInLine", menuName = "ScriptableObject/排列/四个一列")]
public class FourInLine_SO : ScriptableObject
{

    public Vector2[] list = {
        new Vector2(-6.4f, 0f),
        new Vector2(-2.4f, 0f),
        new Vector2(2.4f, 0f),
        new Vector2(6.4f, 0f),
    };

}
