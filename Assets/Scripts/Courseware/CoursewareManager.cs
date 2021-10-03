using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursewareManager : MonoBehaviour
{


    public Transform stage;

    public Transform aboveStage;

    public GameObject ratingStars;

    private Courseware.Type[] coursewares = { Courseware.Type.TapRead, Courseware.Type.Sorting };

    private int currentIndex = -1;

    void Start()
    {

        NextCourse();

    }

    // 下一课
    public Courseware.Type NextCourse()
    {

        currentIndex += 1;

        //ClearStage();

        var type = coursewares[currentIndex];

        var prefab = Resources.Load<GameObject>(Courseware.PathOfPrefab(type));

        AddToStage(Instantiate(prefab));

        return type;
    }


    private void ClearStage() {
        for (int i = 0; i < stage.childCount; i ++)
        {
            var child = stage.GetChild(i);
            child.GetComponent<CoursewareMono>().DidEndCourseware = null;
            Destroy(child.gameObject);
        }
    }



    private CoursewareMono AddToStage(GameObject gameObject)
    {
        var course = gameObject.GetComponent<CoursewareMono>();

        course.DidEndCourseware += DidEndCourseware;

        course.transform.parent = stage;

        return course;
    }


    public void DidEndCourseware(MonoBehaviour b)
    {
        aboveStage.gameObject.SetActive(true);

        var gb = Instantiate<GameObject>(ratingStars);

        gb.GetComponent<RatingStars>().Ranking(3);

        gb.transform.parent = aboveStage;

        DelayController.Standard.DelayToCall(3, () =>
        {
            aboveStage.gameObject.SetActive(false);
            Destroy(gb);
            Destroy(b.gameObject);
            NextCourse();
        });
    }


}


public class Courseware
{

    public enum Type
    {
        TapRead, Sorting
    }

    public static string PathOfPrefab(Courseware.Type type) {

        switch (type)
        {
            case Type.TapRead:
                return "Prefabs/Courseware/TapRead/TapRead";
            case Type.Sorting:
                return "Prefabs/Courseware/Sorting/Sorting";
        }
        return "";
    }


}


public class CoursewareMono : MonoBehaviour
{
    public System.Action<CoursewareMono> DidEndCourseware;

}