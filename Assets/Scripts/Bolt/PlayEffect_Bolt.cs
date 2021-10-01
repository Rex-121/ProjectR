using Bolt;
using Ludiq;



[UnitTitle("PlayEffect")]
[UnitCategory("Sound Mananger")]
public class PlayEffect_Bolt : Unit
{
    [DoNotSerialize]
    public ValueInput valueInput { get; private set; }

    [DoNotSerialize]
    public ControlOutput controlOutput { get; private set; }

    [DoNotSerialize]
    public ControlInput controlInput { get; private set; }



    protected override void Definition()
    {

        valueInput = ValueInput<SoundEffectPlayer.Effect>("Effect Type");

        controlOutput = ControlOutput("output");

        controlInput = ControlInput("input", Play);

    }


    public ControlOutput Play(Flow flow)
    {

        var value = flow.GetValue<SoundEffectPlayer.Effect>(valueInput);

        SoundManager.Standard.PlayEffect(value);

        return controlOutput;
    }
}
