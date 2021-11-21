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
}
