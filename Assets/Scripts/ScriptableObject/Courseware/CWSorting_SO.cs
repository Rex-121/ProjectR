using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CWSorting_SO", menuName = "ScriptableObject/课件/听音排序")]
public class CWSorting_SO : CoursewareDefault_SO
{


    [SerializeField]
    GameObject flatPrefab;


    [SerializeField]
    GameObject sortPrefab;

    public override void SetUpCourseware(CoursewarePlayer player)
    {
        var sorting = player.GetComponent<SortingCourseware>();

        sorting.flatPrefab = flatPrefab;
        sorting.sortPrefab = sortPrefab;
    }


}
