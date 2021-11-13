using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //ser unico y existir en todo momento
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //manejar el cambio de escenas
    public void NextScene()
    {
        //cambia a la proxima escena segun el orden del build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }


}
