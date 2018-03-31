using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision1Start")]
public class Decision1Start : Decision
{
    public override bool Decide(CarStateCtrlr controller)
    {
        if (Input.GetKeyUp("1"))
        {
            return true;
        }
        return false;
    }
}
