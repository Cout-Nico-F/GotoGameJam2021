using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    [SerializeField] public float goalNumber;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    void Start()
    {
        
    }
    private void Update()
    {
        if (minutes >= 0 && seconds >= 0)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0)
            {
                minutes--;
                seconds = 60;
            }
        }
        else
        {
            minutes = 0;
            seconds = 0;
        }
        textMeshPro.text = minutes + ":" + Mathf.Round(seconds);
    }
}
