using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Action2Idle")]
public class Action2Idle : Action
{
    public override void Act(CarStateCtrlr controller)
    {
        PlayIdleSound(controller);
    }

    private void PlayIdleSound(CarStateCtrlr controller)
    {
        if (!controller.audioSource.isPlaying)
        {
            controller.audioSource.clip = controller.audioClips.IdleCar;
            controller.audioSource.Play();

            //controller.audioSource.PlayOneShot(controller.audioClips.IdleCar);
        }

    }
}

