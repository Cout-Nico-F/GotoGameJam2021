using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace AudioJam
{
    public class DialogSystem : MonoBehaviour
    {
        [Header("Personalize Text")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        [SerializeField] private float delay;
        [SerializeField] private int textSize;
        [SerializeField] private string nameFXsound;
        private Text TextHolder;

        public void Start()
        {
            TextHolder = GetComponent<Text>();
            StartCoroutine(WriteText(input, TextHolder, textColor, textFont, delay, textSize,nameFXsound));
        }

        public IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, int textSize,string nameFXsound)
        {
            textHolder.font = textFont;
            textHolder.color = textColor;
            textHolder.fontSize = textSize;
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.Play(nameFXsound);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}