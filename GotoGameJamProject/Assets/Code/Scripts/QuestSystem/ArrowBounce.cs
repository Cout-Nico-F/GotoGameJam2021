using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    [SerializeField] private float amount;
    [SerializeField] private float velocity;
    private Vector2 destination;
    private Vector2 originPosition;
    private float t;

    private void OnEnable()
    {
        originPosition = transform.localPosition;
        destination = originPosition + new Vector2(0, amount);
        t = 0;
    }


    private void Update()
    {
        transform.localPosition = new Vector3(0, Mathf.Lerp(originPosition.y, destination.y, t), 0);
        t += velocity * Time.deltaTime;
        if (t > 1f)
        {
            var temp = destination;
            destination = originPosition;
            originPosition = temp;
            t = 0;
        }
    }
}
