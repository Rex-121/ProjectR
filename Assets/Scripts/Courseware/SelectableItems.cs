

using Bolt;
using Ludiq;
[UnitTitle("SelectableState")]
[UnitCategory("SelectableState")]
public class SelectableItem_Bolt : Unit
{
    [DoNotSerialize]
    public ValueInput valueInput { get; private set; }



    [DoNotSerialize]
    public ControlInput controlInput { get; private set; }


    [DoNotSerialize]
    public ControlOutput idleOutput { get; private set; }

    [DoNotSerialize]
    public ControlOutput rightOutput { get; private set; }


    [DoNotSerialize]
    public ControlOutput wrongOutput { get; private set; }


    [DoNotSerialize]
    public ControlOutput unSelectedOutput { get; private set; }


    protected override void Definition()
    {

        valueInput = ValueInput<SelectableState>("State");

        idleOutput = ControlOutput("idle");
        rightOutput = ControlOutput("right");
        wrongOutput = ControlOutput("wrong");
        unSelectedOutput = ControlOutput("unSelected");

        controlInput = ControlInput("input", Play);

        Requirement(valueInput, controlInput);

        //Succession(controlInput, controlOutput);

    }


    public ControlOutput Play(Flow flow)
    {

        var value = flow.GetValue<SelectableState>(valueInput);

        switch (value)
        {
            case SelectableState.Idle:
                Succession(controlInput, idleOutput);
                return idleOutput;
            case SelectableState.Right:
                Succession(controlInput, rightOutput);
                return rightOutput;
            case SelectableState.Wrong:
                Succession(controlInput, wrongOutput);
                return wrongOutput;
            case SelectableState.UnSelected:
                Succession(controlInput, unSelectedOutput);
                return unSelectedOutput;
        }

        return idleOutput;
    }
}

//public class SelectedItem : MonoBehaviour
//{

//[Serializable]

public enum SelectableState
{

    Idle, Wrong, Right, UnSelected

}




//}
