using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTravelEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    public void TravelEffect()
    {
        effect.SetActive(true);
    }
}
