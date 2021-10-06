using UnityEngine;

/// <summary>
/// 点读SO
/// </summary>
[CreateAssetMenu(fileName = "CoursewareTapRead_SO", menuName = "ScriptableObject/课件/点读")]
public class CoursewareTapRead_SO : CoursewareDefault_SO
{
    /// <summary>
    /// 图片+音频
    /// </summary>
    [SerializeField]
    public ImageWithAudio_SO[] items;


    public override void SetUpCourseware(CoursewarePlayer player)
    {

        var tapRead = player.GetComponent<TapReadCourseware>();

        tapRead.list = items;

    }
}
