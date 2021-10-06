public class CWItemChoosePlayer : CWItemPlayer
{

    public CWChoose_SO itemSO;


    public CoursewarePlayer player;

    private void OnMouseDown()
    {
        itemSO?.DidOnMouseDown(player);
    }


}
