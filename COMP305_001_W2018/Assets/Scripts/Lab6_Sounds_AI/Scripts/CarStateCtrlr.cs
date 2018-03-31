
using UnityEngine;

public class CarStateCtrlr : MonoBehaviour
{
    [SerializeField]
    private State currentState;//PatrolState initially
    [SerializeField]
    private State sameState;//SameState is a dummy state. If SameState is passed then currentState doesn't change
    [SerializeField]
    public SoundClips audioClips;
    [HideInInspector] public AudioSource audioSource;
    public CarStateCtrlr itself;
   
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(itself);//null err here. Solu is to close Unity & delete "Library" folder & reopen unity:https://stackoverflow.com/questions/34999948/unity-build-and-run-game-error-error-building-player-extracting-referenced-dll?rq=1



        //if (!audioSource.isPlaying)
        //{
        //    TransitionToState(sameState);
        //}
    }

    public void TransitionToState(State nextState /*, State onGoingState*/)//called on ea Update() via State.cs
    {
        if (nextState != sameState)//SameState is a dummy state. If SameState is passed then currentState doesn't change
        {
            currentState = nextState;

            //Thread.Sleep((int)audioSource.clip.length);
            //currentState = onGoingState;
        }
    
    }

}

//==============================================

////==============================================
//[CreateAssetMenu(menuName = "PluggableAI/State")]
//public class State : ScriptableObject
//{
//    //public int test;//even when objs r created from thsi scriptibleObj still modifying original script will apply changes to all of it's objs
//    public Action[] actions;
//    public Transition[] transitions;

//    public void UpdateState(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
//    {
//        // Evaluate all actions and all transitions/decisions
//        DoActions(controller);
//        CheckTransitions(controller);
//    }

//    private void DoActions(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
//    {
//        for (int i = 0; i < actions.Length; i++)
//        {
//            actions[i].Act(controller);//AttackAction
//        }
//    }

//    private void CheckTransitions(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
//    {
//        for (int i = 0; i < transitions.Length; i++)
//        {
//            bool decisionSucceeded = transitions[i].decision.Decide(controller);

//            if (decisionSucceeded)
//            {
//                controller.TransitionToState(transitions[i].trueState /*, transitions[i].onGoingState*/);
//                //controller.TransitionToState(transitions[i].onGoingState);//this state becomes NULL immediately aft above line bcoz a this instance is destroyed!!

//            }
//            else
//            {
//                controller.TransitionToState(transitions[i].falseState/*, transitions[i].falseState*/);
//            }
//        }
//    }
//}
////==============================================

////==============================================
//[System.Serializable]
//public class Transition
//{
//    public Decision decision;
//    public State trueState;
//    public State falseState;
//    public State onGoingState;
//}
////==============================================

////==============================================
//public abstract class Action : ScriptableObject
//{
//    public abstract void Act(CarStateCtrlr controller);
//}
//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action1Start")]
//public class Action1Start : Action
//{
//    public override void Act(CarStateCtrlr controller)
//    {
//        PlayStartSound(controller);
//    }

//    private void PlayStartSound(CarStateCtrlr controller)
//    {
//        if (!controller.audioSource.isPlaying)
//        {
//            //controller.audioSource.clip = controller.audioClips.StartCar;
//            //controller.audioSource.Play();

//            controller.audioSource.PlayOneShot(controller.audioClips.StartCar);

//        }
//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action2Idle")]
//public class Action2Idle : Action
//{
//    public override void Act(CarStateCtrlr controller)
//    {
//        PlayIdleSound(controller);
//    }

//    private void PlayIdleSound(CarStateCtrlr controller)
//    {
//        if (!controller.audioSource.isPlaying)
//        {
//            controller.audioSource.clip = controller.audioClips.IdleCar;
//            controller.audioSource.Play();

//            //controller.audioSource.PlayOneShot(controller.audioClips.IdleCar);
//        }

//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action3Revs")]
//public class Action3Revs : Action
//{
//    public override void Act(CarStateCtrlr controller)
//    {
//        PlayRevSound(controller);
//    }

//    private void PlayRevSound(CarStateCtrlr controller)
//    {
//        if (!controller.audioSource.isPlaying)
//        {
//            //controller.audioSource.clip = controller.audioClips.RevCar;
//            //controller.audioSource.Play();

//            controller.audioSource.PlayOneShot(controller.audioClips.RevCar);
//        }

//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action4Stop")]
//public class Action4Stop : Action
//{
//    public override void Act(CarStateCtrlr controller)
//    {
//        PlayStopSound(controller);
//    }

//    private void PlayStopSound(CarStateCtrlr controller)
//    {
//        ////Stop sound should play right away hence NO if()
//        //if (!controller.audioSource.isPlaying)
//        //{
//        //controller.audioSource.clip = controller.audioClips.StopCar;

//        controller.audioSource.Stop();//atop long idling sound track
//            controller.audioSource.PlayOneShot(controller.audioClips.StopCar);//play ONLY once
//        //}
//    }
//}
////==============================================


////==============================================
//public abstract class Decision : ScriptableObject
//{
//    public abstract bool Decide(CarStateCtrlr controller);
//}
//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision1Start")]
//public class Decision1Start : Decision
//{
//    public override bool Decide(CarStateCtrlr controller)
//    {
//        if(Input.GetKeyUp("1"))
//        {
//            return true;
//        }
//        return false;
//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision2Idle")]
//public class Decision2Idle : Decision
//{
//    public override bool Decide(CarStateCtrlr controller)
//    {
//        if (Input.GetKeyUp("2"))
//        {
//            return true;
//        }
//        return false;
//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision3Revs")]
//public class Decision3Revs : Decision
//{
//    public override bool Decide(CarStateCtrlr controller)
//    {
//        if (Input.GetKeyUp("3"))
//        {
//            return true;
//        }
//        return false;
//    }
//}
//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision4Stop")]
//public class Decision4Stop : Decision
//{
//    public override bool Decide(CarStateCtrlr controller)
//    {
//        if (Input.GetKeyUp("4"))
//        {
//            return true;
//        }
//        return false;
//    }
//}
////==============================================

//[System.Serializable]
//public class SoundClips
//{
//    public AudioClip StartCar;
//    public AudioClip IdleCar;
//    public AudioClip RevCar;
//    public AudioClip StopCar;
//}
////==============================================


////==============================================


////==============================================
