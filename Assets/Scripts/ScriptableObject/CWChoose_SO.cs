using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public abstract class CWChoose_SO : CoursewareDefault_SO
{
    
    public abstract void DidOnMouseDown(CoursewarePlayer player);

    public abstract void SetValues(CWItemPlayer itemPlayer);
}



public class CWRightChoosen_SO : CWChoose_SO
{
    public override void DidOnMouseDown(CoursewarePlayer player)
    {
        player?.DidChooseRight(this);
    }

    public static CWChoose_SO Create()
    {
        return ScriptableObject.CreateInstance<CWRightChoosen_SO>();

    }

    public override void SetValues(CWItemPlayer itemPlayer)
    {
        var flow = itemPlayer.GetComponent<FlowMachine>();
        if (flow == null) return;

        var variable = flow.GetComponent<Variables>();
        
        variable.declarations.Set("isRightAnswer", true);
    }
}



public class CWWrongChoosen_SO : CWChoose_SO
{
    public override void DidOnMouseDown(CoursewarePlayer player)
    {
        player?.DidChooseWrong(this);
    }

    public static CWChoose_SO Create()
    {
        return ScriptableObject.CreateInstance<CWWrongChoosen_SO>();

    }



    public override void SetValues(CWItemPlayer itemPlayer)
    {
        var flow = itemPlayer.GetComponent<FlowMachine>();
        if (flow == null) return;

        var variable = flow.GetComponent<Variables>();

        variable.declarations.Set("isRightAnswer", false);
    }

}