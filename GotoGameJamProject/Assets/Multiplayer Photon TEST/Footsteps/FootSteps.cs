using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private PlayerMovementTOPDOWN playerMovement;
    [SerializeField] private AudioSource stepAudio;

    private void Update()
    {
        if (playerMovement.Movement.x != 0 || playerMovement.Movement.y != 0)
        {
            if (!stepAudio.isPlaying)
            {
                stepAudio.pitch  = Random.Range(1.95f, 2.4f);
                stepAudio.Play();
            }
        }
    }
}
