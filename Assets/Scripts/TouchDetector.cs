using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchDetector : UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable
{
    public GameObject bubbleObject;
    public GameObject bubbleCanon;
    public AudioSource SFXaudio;
    // public ParticleSystem subEmiter; 


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        GameObject.Instantiate(bubbleObject.transform, bubbleCanon.transform.position, gameObject.transform.rotation);
        //subEmiter.Play();
        SFXaudio.Play();
       /* if (subEmiter.isPlaying)
        {
            subEmiter.Stop();

        }*/


    }
}