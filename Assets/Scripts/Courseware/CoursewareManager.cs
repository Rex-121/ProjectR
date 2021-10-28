using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bolt;
using Ludiq;

public class CoursewareManager : MonoBehaviour
{

    public static CoursewareManager Standard;

    public Transform stage;

    public Transform aboveStage;

    public GameObject ratingStars;

    [SerializeField]
    private CoursewareDefault_SO[] coursewares;//= { Courseware.Type.TapRead, Courseware.Type.Sorting };

    private int currentIndex = -1;

    [SerializeField]
    private CoursewareMono currentCourseware;

    [SerializeField]
    private bool findCoursewareInEditor = false;

    private void Awake()
    {
        if (Standard == null)
        {
            Standard = this;
            //DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    void Start()
    {

        currentIndex = -1;

        if (findCoursewareInEditor)
        {
            currentCourseware = FindObjectOfType<CoursewareMono>();
            currentCourseware.DidEndCourseware += DidEndCourseware;
        }

        NextCourse();

    }

    // 下一课
    public void NextCourse()
    {

        currentIndex += 1;

        //ClearStage();
        if (NoMoreCourseware()) return;

        var type = coursewares[currentIndex];

        var prefab = Instantiate(type.CoursewarePrefab);

        type.SetUpCourseware(prefab.GetComponent<CoursewarePlayer>());

        AddToStage(prefab);

        return;
    }

    private bool NoMoreCourseware()
    {
        if (currentIndex >= coursewares.Length)
        {
            return true;
        }
        return false;
    }


    private void ClearStage()
    {
        for (int i = 0; i < stage.childCount; i++)
        {
            var child = stage.GetChild(i);
            child.GetComponent<CoursewareMono>().DidEndCourseware = null;
            Destroy(child.gameObject);
        }
    }



    private CoursewareMono AddToStage(GameObject gameObject)
    {
        var course = gameObject.GetComponent<CoursewareMono>();

        currentCourseware = course;

        course.DidEndCourseware += DidEndCourseware;

        course.transform.parent = stage;

        return course;
    }

    Coroutine cor;

    public void DidEndCourseware(MonoBehaviour b)
    {
        aboveStage.gameObject.SetActive(true);

        var gb = Instantiate<GameObject>(ratingStars);

        gb.GetComponent<RatingStars>().Ranking(3);

        gb.transform.parent = aboveStage;

        cor = StartCoroutine(DestroyNative(b, gb));

    }

    IEnumerator DestroyNative(MonoBehaviour b, GameObject gb)
    {
        yield return new WaitForSeconds(3);

        aboveStage.gameObject.SetActive(false);
        Destroy(gb);
        Destroy(b.gameObject);
        NextCourse();

    }


    private void OnDestroy()
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
    }

    public void SelectedGameObject(GameObject obj)
    {
        currentCourseware?.SelectedGameObject(obj);
    }
}


public class Courseware
{

    public enum Type
    {
        TapRead, Sorting, VoiceCheck, Choice
    }

    public static string PathOfPrefab(Courseware.Type type)
    {

        switch (type)
        {
            case Type.TapRead:
                return "Prefabs/Courseware/TapRead/TapRead";
            case Type.Sorting:
                return "Prefabs/Courseware/Sorting/Sorting";
            case Type.VoiceCheck:
                return "Prefabs/Courseware/VoiceCheck";
            case Type.Choice:
                return "Prefabs/Courseware/Choice";
        }
        return "";
    }


}


public class CoursewareMono : MonoBehaviour
{

    public System.Action<CoursewareMono> DidEndCourseware;


    public virtual void SelectedGameObject(GameObject obj) { }

}



[UnitCategory("Courseware")]
[UnitTitle("CoursewareDidSelectItem")]
public class CoursewareManager_Bolt : Unit
{
    [DoNotSerialize]
    public ControlInput controlInput;

    [DoNotSerialize]
    public ControlOutput controlOutput;

    [DoNotSerialize]
    public ValueInput gameObject;

    protected override void Definition()
    {
        controlInput = ControlInput("input", DidSelectItem);

        controlOutput = ControlOutput("out");

        gameObject = ValueInput(typeof(GameObject), "gameObject");

        Requirement(gameObject, controlInput);

        Succession(controlInput, controlOutput);
    }


    ControlOutput DidSelectItem(Flow flow)
    {

        CoursewareManager.Standard.SelectedGameObject(flow.GetValue<GameObject>(gameObject));

        return controlOutput;
    }


}
