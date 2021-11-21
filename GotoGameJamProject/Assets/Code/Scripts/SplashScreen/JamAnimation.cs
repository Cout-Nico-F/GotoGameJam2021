using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamAnimation : MonoBehaviour
{
    public void PlayWoosh1()
    {
        AudioJam.SoundManager.instance.Play("Woosh1");
    }
    public void PlayWoosh2()
    {
        AudioJam.SoundManager.instance.Play("Woosh2");
    }
    public void PlayGotouu()
    {
        AudioJam.SoundManager.instance.Play("Gotouu");
    }
    public void PlayPimm()
    {
        AudioJam.SoundManager.instance.Play("Pimm");
    }

}
