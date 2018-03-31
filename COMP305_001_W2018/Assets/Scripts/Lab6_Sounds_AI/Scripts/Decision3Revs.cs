using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision3Revs")]
public class Decision3Revs : Decision
{
    public override bool Decide(CarStateCtrlr controller)
    {
        if (Input.GetKeyUp("3"))
        {
            return true;
        }
        return false;
    }
}
