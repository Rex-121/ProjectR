using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCourseware : CoursewareMono
{
    public override void SelectedGameObject(GameObject obj)
    {
        Debug.Log("fasdfasd");
        DidEndCourseware(this);
    }
}
