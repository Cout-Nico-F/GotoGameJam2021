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
        [SerializeField] private TextMeshProUGUI textHolder;
        [SerializeField] private Image imgageHolder;
        private bool NextText;

        [System.Serializable]
        public class TextoValues
        {
            [Header("Character Sprite")]
            [SerializeField] public Sprite characterSprite;
            [Header("Personalize Text")]
            [SerializeField] public Color textColor;
            [SerializeField] public TMP_FontAsset textFont;
            [SerializeField] public float delay;
            [SerializeField] public int fontSize;
            [SerializeField] public string nameFXsound;
            [Header("Dialogue")]
            [SerializeField] public string input;
        };
        public void OnEnable()
        {
            StartCoroutine(RecibeText());
        }
        public IEnumerator RecibeText()
        {
            for (int i = 0; i < textValues.Length; i++)
            {
                StartCoroutine(WriteText(textValues[i].input, textHolder, textValues[i].textColor, textValues[i].textFont, textValues[i].delay, textValues[i].fontSize, textValues[i].nameFXsound,textValues[i].characterSprite));
                yield return new WaitUntil(() => NextText == true);
                yield return new WaitForSeconds(delayBetweenDialogues);
            }
            gameObject.SetActive(false);
        }
        public IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset textFont, float delay, int textSize, string nameFXsound,Sprite characterSprite)
        {
            NextText = false;
            imgageHolder.sprite = characterSprite;
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
            NextText = true;
        }
    }
}