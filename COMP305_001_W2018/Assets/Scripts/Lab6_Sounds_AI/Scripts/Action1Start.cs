


using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Action1Start")]
public class Action1Start : Action
{
    public override void Act(CarStateCtrlr controller)
    {
        PlayStartSound(controller);
    }

    private void PlayStartSound(CarStateCtrlr controller)
    {
        if (!controller.audioSource.isPlaying)
        {
            //controller.audioSource.clip = controller.audioClips.StartCar;
            //controller.audioSource.Play();

            controller.audioSource.PlayOneShot(controller.audioClips.StartCar);

        }
    }
}

