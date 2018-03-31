using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Action3Revs")]
public class Action3Revs : Action
{
    public override void Act(CarStateCtrlr controller)
    {
        PlayRevSound(controller);
    }

    private void PlayRevSound(CarStateCtrlr controller)
    {
        if (!controller.audioSource.isPlaying)
        {
            //controller.audioSource.clip = controller.audioClips.RevCar;
            //controller.audioSource.Play();

            controller.audioSource.PlayOneShot(controller.audioClips.RevCar);
        }

    }
}
