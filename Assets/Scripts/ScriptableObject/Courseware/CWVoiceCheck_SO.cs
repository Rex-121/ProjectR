using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CWVoiceCheck_SO", menuName = "ScriptableObject/课件/音选图（农场）")]
public class CWVoiceCheck_SO : CoursewareDefault_SO
{


    [SerializeField]
    GameObject itemPrefab;

    public override void SetUpCourseware(CoursewarePlayer player)
    {
        var prefab = player.GetComponent<VoiceCheckCourseware>();
        prefab.itemPre = itemPrefab;
    }
}
