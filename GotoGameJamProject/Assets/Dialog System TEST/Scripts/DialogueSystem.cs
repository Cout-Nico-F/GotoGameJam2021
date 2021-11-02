using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using AudioJam;

public class DialogueSystem : MonoBehaviour
{
    [Header("Personalize Text")]
    [SerializeField] private string input;
    [SerializeField] private Color textColor;
    [SerializeField] private Font textFont;
    [SerializeField] private float delay;
    [SerializeField] private int fontSize;
    [SerializeField] private string nameFXsound;
    private Text textHolder;

    public void Start()
    {
        textHolder = GetComponent<Text>();
        StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, fontSize, nameFXsound));       
    }

    public IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, int textSize, string nameFXsound)
    {
        textHolder.font = textFont;
        textHolder.color = textColor;
        textHolder.fontSize = textSize;
        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.Play(nameFXsound);
            yield return new WaitForSeconds(delay / Random.Range(0.2f, 0.5f) );
        }
    }
}