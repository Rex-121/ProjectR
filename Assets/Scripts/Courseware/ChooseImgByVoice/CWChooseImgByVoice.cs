using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音选图
/// </summary>
public class CWChooseImgByVoice : CoursewarePlayer
{
    public CWChooseImgByVoice_Template_SO itemSO;

    [SerializeField]
    public FourInLine_SO inLine;

    private void Start()
    {
        foreach (var position in inLine.list)
        {
            var item = Instantiate(itemSO.template);
            item.transform.localPosition = position;
            item.transform.parent = transform;

            var itemPlayer = item.GetComponent<CWItemChoosePlayer>();

            itemPlayer.player = this;
            itemPlayer.itemSO = CWWrongChoosen_SO.Create();
        }

    }
}
