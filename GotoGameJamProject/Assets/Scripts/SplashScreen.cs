using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private float waitingTime = 5;

    private void Start()
    {
        StartCoroutine(WaitAndChange());
    }

    IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(waitingTime);
        NextScene();
    }

    //contar X segundos atras
    private void CountDownSecs(int secs)
    {

    }
   
    //decirle al game manager que pase de escena.
    private void NextScene()
    {
        GameManager.instance.NextScene();
    }
}
