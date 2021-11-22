using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioJam;
using UnityEngine.SceneManagement;

public class CineMachineLose : MonoBehaviour
{
    public void Whoosh()
    {
        SoundManager.instance.Play("Woosh2");
    }
    public void Explosion()
    {
        SoundManager.instance.Play("Explode");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Win()
    {
        SoundManager.instance.Play("Win2");
    }
    public void StopAudio()
    {
        SoundManager.instance.Stop("Woosh2");
    }

}
