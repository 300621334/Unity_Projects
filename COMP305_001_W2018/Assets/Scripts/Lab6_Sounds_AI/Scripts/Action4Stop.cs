using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Action4Stop")]
public class Action4Stop : Action
{
    public override void Act(CarStateCtrlr controller)
    {
        PlayStopSound(controller);
    }

    private void PlayStopSound(CarStateCtrlr controller)
    {
        ////Stop sound should play right away hence NO if()
        //if (!controller.audioSource.isPlaying)
        //{
        //controller.audioSource.clip = controller.audioClips.StopCar;

        controller.audioSource.Stop();//atop long idling sound track
        controller.audioSource.PlayOneShot(controller.audioClips.StopCar);//play ONLY once
                                                                          //}
    }
}