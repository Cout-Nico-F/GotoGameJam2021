using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInitialCinematic : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    public void TravelEffect()
    {
        effect.SetActive(true);
    }

    public void PlayCineMusic()
    {
        AudioJam.SoundManager.instance.Play("CineMusic");
    }

    public void PlayExplosion()
    {
        AudioJam.SoundManager.instance.Play("Explode");
    }
    
    public void PlayAura()
    {
        AudioJam.SoundManager.instance.Stop("CineMusic");
        AudioJam.SoundManager.instance.Play("Aura");
    }
}
