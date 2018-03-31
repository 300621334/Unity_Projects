


using UnityEngine;

class Transitions_class
    {
    }

    //==============================================
    [System.Serializable]
    public class Transition
    {
    [SerializeField]
    public Decision decision;
    [SerializeField]
    public State trueState;
    [SerializeField]
    public State falseState;
    [SerializeField]
    public State onGoingState;
    }
    //==============================================

