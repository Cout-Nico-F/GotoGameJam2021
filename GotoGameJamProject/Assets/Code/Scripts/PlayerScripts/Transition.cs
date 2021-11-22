using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float alphaSpeed;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    bool pv;
    private void OnEnable()
    {
        Debug.Log("OnEnable Transition");
        pv = true;
        audioSource.pitch = 0.8f;
        audioSource.PlayOneShot(audioClip);
    }
    private void FixedUpdate()
    {
        transform.Rotate(0,0,10);
        if (pv)
        {
            var tempColor = image.color;
            tempColor.a += alphaSpeed*2;
            image.color = tempColor;
            if(image.color.a>=0.5f)
            {
                pv = false;
            }
        }
        else
        {
            var tempColor = image.color;
            tempColor.a -= alphaSpeed/3;
            image.color = tempColor;
            if (image.color.a <= 0)
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
