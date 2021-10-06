using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCourseware : CoursewarePlayer
{
    public override void SelectedGameObject(GameObject obj)
    {
        DidEndCourseware(this);
    }
}
