using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class Decisions_class
    {
    }

    //==============================================
    [System.Serializable]
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(CarStateCtrlr controller);
    }


//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision1Start")]
//    public class Decision1Start : Decision
//    {
//        public override bool Decide(CarStateCtrlr controller)
//        {
//            if (Input.GetKeyUp("1"))
//            {
//                return true;
//            }
//            return false;
//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision2Idle")]
//    public class Decision2Idle : Decision
//    {
//        public override bool Decide(CarStateCtrlr controller)
//        {
//            if (Input.GetKeyUp("2"))
//            {
//                return true;
//            }
//            return false;
//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision3Revs")]
//    public class Decision3Revs : Decision
//    {
//        public override bool Decide(CarStateCtrlr controller)
//        {
//            if (Input.GetKeyUp("3"))
//            {
//                return true;
//            }
//            return false;
//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Decisions/Decision4Stop")]
//    public class Decision4Stop : Decision
//    {
//        public override bool Decide(CarStateCtrlr controller)
//        {
//            if (Input.GetKeyUp("4"))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
    //==============================================

