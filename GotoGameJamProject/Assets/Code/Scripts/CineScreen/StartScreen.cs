using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject cinematica;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button estasLocoButton;

    private int count = 0;


    private void Awake()
    {
        skipButton.onClick.AddListener(Skip);
        estasLocoButton.onClick.AddListener(PlayCinematica);
    }


    private void Start()
    {
        AudioJam.SoundManager.instance.Play("CineMusic");
    }


    private void PlayCinematica()
    {
        gameObject.SetActive(false);
        cinematica.SetActive(true);
    }


    private void Skip()
    {
        count++;
        if (count == 1)
        {
            label.text = "¿seguro?, nos costo mucho hacerla";
            skipButton.transform.localPosition += new Vector3(Random.Range(-100f, 300f), Random.Range(-200, 0f) ,0);
        }
        else
        {
            AudioJam.SoundManager.instance.Stop("CineMusic");
            SceneManager.LoadScene("Loading");
        }
    }
}
