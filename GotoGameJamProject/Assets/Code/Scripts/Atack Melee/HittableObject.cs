using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{
    [SerializeField] private int life=3;
    void Update()
    {
        if(life<=0)
        {
            Debug.Log("Destruido");
        }
    }
}
