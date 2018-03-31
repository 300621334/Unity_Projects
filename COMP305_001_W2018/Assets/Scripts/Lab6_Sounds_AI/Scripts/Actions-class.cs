using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class Actions_class
    {
    }
//==============================================
[System.Serializable]
public abstract class Action : ScriptableObject
    {
        public abstract void Act(CarStateCtrlr controller);
    }


//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action1Start")]
//    public class Action1Start : Action
//    {
//        public override void Act(CarStateCtrlr controller)
//        {
//            PlayStartSound(controller);
//        }

//        private void PlayStartSound(CarStateCtrlr controller)
//        {
//            if (!controller.audioSource.isPlaying)
//            {
//                //controller.audioSource.clip = controller.audioClips.StartCar;
//                //controller.audioSource.Play();

//                controller.audioSource.PlayOneShot(controller.audioClips.StartCar);

//            }
//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action2Idle")]
//    public class Action2Idle : Action
//    {
//        public override void Act(CarStateCtrlr controller)
//        {
//            PlayIdleSound(controller);
//        }

//        private void PlayIdleSound(CarStateCtrlr controller)
//        {
//            if (!controller.audioSource.isPlaying)
//            {
//                controller.audioSource.clip = controller.audioClips.IdleCar;
//                controller.audioSource.Play();

//                //controller.audioSource.PlayOneShot(controller.audioClips.IdleCar);
//            }

//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action3Revs")]
//    public class Action3Revs : Action
//    {
//        public override void Act(CarStateCtrlr controller)
//        {
//            PlayRevSound(controller);
//        }

//        private void PlayRevSound(CarStateCtrlr controller)
//        {
//            if (!controller.audioSource.isPlaying)
//            {
//                //controller.audioSource.clip = controller.audioClips.RevCar;
//                //controller.audioSource.Play();

//                controller.audioSource.PlayOneShot(controller.audioClips.RevCar);
//            }

//        }
//    }


//[CreateAssetMenu(menuName = "PluggableAI/Actions/Action4Stop")]
//    public class Action4Stop : Action
//    {
//        public override void Act(CarStateCtrlr controller)
//        {
//            PlayStopSound(controller);
//        }

//        private void PlayStopSound(CarStateCtrlr controller)
//        {
//            ////Stop sound should play right away hence NO if()
//            //if (!controller.audioSource.isPlaying)
//            //{
//            //controller.audioSource.clip = controller.audioClips.StopCar;

//            controller.audioSource.Stop();//atop long idling sound track
//            controller.audioSource.PlayOneShot(controller.audioClips.StopCar);//play ONLY once
//                                                                              //}
//        }
//    }
    //==============================================

