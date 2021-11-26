using UnityEngine;

public class Radio : MonoBehaviour, Interactable
{
    public AudioSource audioSource;
    public void Interact(GameObject gameObject)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
