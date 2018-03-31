using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision2Idle")]
public class Decision2Idle : Decision
{
    public override bool Decide(CarStateCtrlr controller)
    {
        if (Input.GetKeyUp("2"))
        {
            return true;
        }
        return false;
    }
}
