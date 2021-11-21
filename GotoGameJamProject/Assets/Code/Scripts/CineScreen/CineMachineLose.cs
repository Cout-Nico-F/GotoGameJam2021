using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioJam;
using UnityEngine.SceneManagement;

public class CineMachineLose : MonoBehaviour
{
    public void Explosion()
    {
        SoundManager.instance.Play("Explode");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Loading");
    }
}
