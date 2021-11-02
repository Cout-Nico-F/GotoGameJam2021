using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using AudioJam;

namespace DialogueJam
{
    public class DialogueSystem : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float delayBetweenDialogues;
        [SerializeField] private TextoValues[] textValues;
        private TextMeshProUGUI textHolder;

        [System.Serializable]
        public class TextoValues
        {
            
            [Header("Personalize Text")]
            [SerializeField] public Color textColor;
            [SerializeField] public TMP_FontAsset textFont;
            [SerializeField] public float delay;
            [SerializeField] public int fontSize;
            [SerializeField] public string nameFXsound;
            [Header("Dialogue")]
            [SerializeField] public string input;
        };

        public void Start()
        {
            textHolder = GetComponentInChildren<TextMeshProUGUI>();
            StartCoroutine(RecibeText());
        }
        public IEnumerator RecibeText()
        {
            for (int i = 0; i < textValues.Length; i++)
            {
                StartCoroutine(WriteText(textValues[i].input, textHolder, textValues[i].textColor, textValues[i].textFont, textValues[i].delay, textValues[i].fontSize, textValues[i].nameFXsound));
                yield return new WaitForSeconds(delayBetweenDialogues);
            }
        }
        public IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset textFont, float delay, int textSize, string nameFXsound)
        {
            textHolder.text = "";
            textHolder.font = textFont;
            textHolder.color = textColor;
            textHolder.fontSize = textSize;
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.Play(nameFXsound);
                yield return new WaitForSeconds(delay / Random.Range(0.2f, 1f));
            }
        }
    }
}