
using UnityEngine;


    //==============================================
    [CreateAssetMenu(menuName = "PluggableAI/State")]
    public class State : ScriptableObject
    {
        //public int test;//even when objs r created from thsi scriptibleObj still modifying original script will apply changes to all of it's objs
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
        {
            // Evaluate all actions and all transitions/decisions
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller);//AttackAction
            }
        }

        private void CheckTransitions(CarStateCtrlr controller)//called on ea Update() of ctrlr-scr
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = transitions[i].decision.Decide(controller);

                if (decisionSucceeded)
                {
                    controller.TransitionToState(transitions[i].trueState /*, transitions[i].onGoingState*/);
                    //controller.TransitionToState(transitions[i].onGoingState);//this state becomes NULL immediately aft above line bcoz a this instance is destroyed!!

                }
                else
                {
                    controller.TransitionToState(transitions[i].falseState/*, transitions[i].falseState*/);
                }
            }
        }
    }
    //==============================================

