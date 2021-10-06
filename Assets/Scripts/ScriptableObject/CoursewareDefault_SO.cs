using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoursewareDefault_SO", menuName = "ScriptableObject/课件/默认课件")]
public abstract class CoursewareDefault_SO : ScriptableObject
{

    
    public GameObject CoursewarePrefab;


    public abstract void SetUpCourseware(CoursewarePlayer player);

}




