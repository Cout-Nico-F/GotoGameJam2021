using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivator : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject letterE;
    [SerializeField] private GameObject dialog;
    void Update()
    {
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance < maxDistance)
        {
            letterE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialog.SetActive(true);
            }
        }
        else
        {
            letterE.SetActive(false);
            dialog.SetActive(false);
        }
    }
}
