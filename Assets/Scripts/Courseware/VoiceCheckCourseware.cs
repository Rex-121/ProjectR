using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

// 音选图Farm
public class VoiceCheckCourseware : CoursewarePlayer
{


    [SerializeField]
    Vector2[] flatPosition;

    [HideInInspector]
    public GameObject itemPre;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < flatPosition.Length; i++)
        {
            var position = flatPosition[i];

            var flatItem = Instantiate(itemPre);
            var flow = flatItem.GetComponent<Variables>();

            if (i == 2)
            {
                flow.declarations.Set("isRightAnswer", i == 2);
                flow.declarations.Set("CoursewareHandler", this);
            }


            flatItem.transform.parent = transform;
            flatItem.transform.position = position;
        }


    }

    public override void SelectedGameObject(GameObject obj)
    {
        DidEndCourseware(this);
    }

}
