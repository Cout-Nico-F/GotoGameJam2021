using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private GameObject transition;
    [SerializeField] private Image image;
    [SerializeField] private float alphaSpeed;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    bool pv;
    private void OnEnable()
    {
        pv = true;
        audioSource.pitch = 0.8f;
        audioSource.PlayOneShot(audioClip);
    }
    private void Update()
    {
        transform.Rotate(0,0,3);
        if (pv)
        {
            var tempColor = image.color;
            tempColor.a += alphaSpeed;
            image.color = tempColor;
            if(image.color.a>=0.5f)
            {
                pv = false;
            }
        }
        else
        {
            var tempColor = image.color;
            tempColor.a -= alphaSpeed;
            image.color = tempColor;
            if (image.color.a <= 0)
            {
                transition.gameObject.SetActive(false);
            }
        }
    }
}
