using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateAfterXseconds : MonoBehaviour
{
    [SerializeField] private float timerMax;
    private float timer;

    private void OnEnable()
    {
        timer = 0;
    }
    void Update()
    {
        if(timer<timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
