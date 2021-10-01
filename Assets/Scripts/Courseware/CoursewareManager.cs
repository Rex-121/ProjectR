using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursewareManager : MonoBehaviour
{

    public Transform stage;

    public Transform aboveStage;

    public GameObject ratingStars;

    void Start()
    {

        var g = Resources.Load<GameObject>("Prefabs/Courseware/TapRead/TapRead");

        var go = Instantiate(g);

        go.GetComponent<TapReadCourseware>().DidEndCourseware += DidEndCourseware;

        go.transform.parent = stage;



    }




    public void DidEndCourseware(MonoBehaviour b)
    {

        var gb = Instantiate<GameObject>(ratingStars);

        gb.GetComponent<RatingStars>().Ranking(3);

        gb.transform.parent = aboveStage;

        DelayController.Standard.DelayToCall(3, () =>
        {
            Destroy(gb);
        });
    }


}
