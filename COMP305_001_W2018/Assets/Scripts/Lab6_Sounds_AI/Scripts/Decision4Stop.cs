using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision4Stop")]
public class Decision4Stop : Decision
{
    public override bool Decide(CarStateCtrlr controller)
    {
        if (Input.GetKeyUp("4"))
        {
            return true;
        }
        return false;
    }
}